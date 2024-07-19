﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    public class XmlSerializer
    {
        private int _index = 0050;
        private HKXHeader _header;
        private Dictionary<IHavokObject, string> _serializedObjectsLookup;
        private XDocument _document;
        private XContainer _dataSection;

        public XmlSerializer()
        {
            _serializedObjectsLookup = new Dictionary<IHavokObject, string>();
        }
        private string GetIndex()
        {
            return "#" + _index++.ToString("D4");
        }

        private static string FormatSignature(uint signature)
        {
            return "0x" + signature.ToString("x8");
        }

        public void Serialize(IHavokObject rootObject, HKXHeader header, Stream stream)
        {

            _header = header;
            _serializedObjectsLookup = new Dictionary<IHavokObject, string>(ReferenceEqualityComparer.Instance);

            var index = GetIndex();

            _document = new XDocument(
                new XDeclaration("1.0", "ascii", null),
                new XElement("hkpackfile",
                    new XAttribute("classversion", header.FileVersion),
                    new XAttribute("contentsversion", header.ContentsVersionString),
                    new XAttribute("toplevelobject", index),
                    new XElement("hksection",
                        new XAttribute("name", "__data__"))));

            _dataSection = _document.Element("hkpackfile").Element("hksection");

            var hkrootcontainer = WriteNode(rootObject, index);
            rootObject.WriteXml(this, hkrootcontainer);

            _document.Save(stream);
        }

        private XElement WriteNode<T>(T hkobject, string nodeName) where T : IHavokObject
        {
            XElement ele = new("hkobject",
                new XAttribute("name", nodeName),
                new XAttribute("class", hkobject.GetType().Name),
                new XAttribute("signature", FormatSignature(hkobject.Signature)));
            _dataSection?.Add(ele);
            return ele;
        }
        public XElement WriteRegisteredNode<T>(T hkNode) where T :hkbNode
        {            
            string name = hkNode.m_name;
			XElement ele = new("hkobject");
            lock(_serializedObjectsLookup)
            {
				if (!_serializedObjectsLookup.TryGetValue(hkNode, out string? existingName))
				{
                    if (_dataSection != null)
                    {
						lock (_dataSection)
						{
							_dataSection?.Add(ele);
						}
					}
					_serializedObjectsLookup.Add(hkNode, name);
				}
				else
				{
					name = existingName;
				}
			}

            ele.Add(new XAttribute("name", name), new XAttribute("class", hkNode.GetType().Name), new XAttribute("signature", FormatSignature(hkNode.Signature)));
			return ele;
		}
		public XElement WriteRegisteredNamedObject<T>(T hkObject, string name) where T : IHavokObject
		{
			XElement ele = new("hkobject");
            lock(_serializedObjectsLookup)
            {
				if (!_serializedObjectsLookup.TryGetValue(hkObject, out string? existingName))
				{
                    if (_dataSection != null)
                    {
						lock (_dataSection)
						{
							_dataSection?.Add(ele);
						}
					}
					_serializedObjectsLookup.Add(hkObject, name);
				}
				else
				{
					name = existingName;
				}
			}

			ele.Add(new XAttribute("name", name), new XAttribute("class", hkObject.GetType().Name), new XAttribute("signature", FormatSignature(hkObject.Signature)));
			return ele;
		}
		/// <summary>
		/// Deprecated. Use "WriteRegisteredNode" instead to prevent key conflicts and missing references. NOT THREAD SAFE.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="hkobject"></param>
		/// <param name="nodeName"></param>
		/// <returns></returns>
		public XElement WriteDetachedNode<T>(T hkobject, string nodeName) where T: IHavokObject
        {
			XElement ele = new("hkobject",
	            new XAttribute("name", nodeName),
	            new XAttribute("class", hkobject.GetType().Name),
	            new XAttribute("signature", FormatSignature(hkobject.Signature)));
			_dataSection?.Add(ele);
            _serializedObjectsLookup.Add(hkobject, nodeName);
			return ele;
		}
        public void WriteClassPointer<T>(XElement xe, string paramName, T? value) where T : IHavokObject
        {
            if (value is null)
            {
                WriteString(xe, paramName, "null");
                return;
            }
            if (_serializedObjectsLookup.ContainsKey(value))
            {
                var index = _serializedObjectsLookup[value];
                var hkparam = WriteString(xe, paramName, index);
            }
            else
            {
                var defaultName = value is hkbNode node ? node.m_name : GetIndex();
				_serializedObjectsLookup.Add(value, defaultName);
                WriteString(xe, paramName, defaultName);
                var element = WriteNode(value, defaultName);
                value.WriteXml(this, element);
            }
        }

        public void WriteClassPointerArray<T>(XElement xe, string paramName, IList<T?> values) where T : IHavokObject
        {
            var nameIds = new List<string>();
            var hkparam = WriteParam(xe, paramName);
            hkparam.Add(new XAttribute("numelements", values.Count));
            foreach (var item in values)
            {
                if (item is null)
                {
                    nameIds.Add("null");
                    continue;
                }
                if (_serializedObjectsLookup.ContainsKey(item))
                {
                    nameIds.Add(_serializedObjectsLookup[item]);
                    continue;
                }
                var defaultName = item is hkbNode node ? node.m_name : GetIndex();
                _serializedObjectsLookup.Add(item, defaultName);
                nameIds.Add(defaultName);
                var element = WriteNode(item, defaultName);
                item.WriteXml(this, element);
            }
            hkparam.Add(new XText(string.Join(" ", nameIds)));
        }

        public void WriteClass<T>(XElement xe, string paramName, T value) where T : IHavokObject
        {
            var hkobject = new XElement("hkobject");
            WriteObject(xe, paramName, hkobject);
            value.WriteXml(this, hkobject);
        }

        public void WriteClassArray<T>(XElement xe, string paramName, IList<T> values) where T : IHavokObject
        {
            var hkparam = WriteParam(xe, paramName);
            hkparam.Add(new XAttribute("numelements", values.Count));
            foreach (var item in values)
            {
                var hkobject = new XElement("hkobject");
                hkparam.Add(hkobject);
                item.WriteXml(this, hkobject);
            }
        }


        public void WriteSerializeIgnored(XElement xe, string prop)
        {
            if (prop.StartsWith("m_"))
            {
                prop = prop[2..];
            }
            WriteComment(xe, prop + " SERIALIZE_IGNORED");
        }

        private static void WriteComment(XElement xe, string value)
        {
            xe.Add(new XComment(value));
        }

        private XElement WriteParam(XElement xe, string paramName, params object[] value)
        {
            if (paramName.StartsWith("m_"))
            {
                paramName = paramName[2..];
            }
            var hkparam = new XElement("hkparam", new XAttribute("name", paramName), value);
            xe.Add(hkparam);
            return hkparam;
        }

        private XElement WriteParam(XElement xe, string paramName)
        {
            return WriteParam(xe, paramName, "");
        }

        public XElement WriteObject(XElement xe, string paramName, XElement value)
        {
            return WriteParam(xe, paramName, value);
        }

        public XElement WriteBoolean(XElement xe, string paramName, bool value)
        {
            return WriteParam(xe, paramName, value ? "true" : "false");
        }

        public XElement WriteBooleanArray(XElement xe, string paramName, IList<bool> value)
        {
            var formated = value.Select(x => x ? "true" : "false")
                                .Chunk(16)
                                .Select(x => string.Join(" ", x));

            return WriteParam(xe, paramName, new XText(string.Join(" ", formated)), new XAttribute("numelements", value.Count));
        }

        public XElement WriteNumber<T>(XElement xe, string paramName, T value) where T : IBinaryInteger<T>
        {
            return WriteParam(xe, paramName, value);
        }

        public XElement WriteNumberArray<T>(XElement xe, string paramName, IList<T> value) where T : IBinaryInteger<T>
        {
            var formated = value.Chunk(16)
                                .Select(x => string.Join(" ", x));

            return WriteParam(xe, paramName, string.Join(" ", formated), new XAttribute("numelements", value.Count));
        }

        public XElement WriteFloat<T>(XElement xe, string paramName, T value) where T : IFloatingPoint<T>
        {
            return WriteParam(xe, paramName, value.ToString("F6", null));
        }

        public XElement WriteFloatArray<T>(XElement xe, string paramName, IList<T> value) where T : IFloatingPoint<T>
        {
            var formated = value.Select(x => x.ToString("F6", null))
                                .Chunk(16)
                                .Select(x => string.Join(" ", x));

            return WriteParam(xe, paramName, string.Join(" ", formated), new XAttribute("numelements", value.Count));
        }

        public XElement WriteVector4(XElement xe, string paramName, Vector4 value)
        {
            return WriteParam(xe, paramName, $"({value.X:F6} {value.Y:F6} {value.Z:F6} {value.W:F6})");
        }

        public XElement WriteVector4Array(XElement xe, string paramName, IList<Vector4> value)
        {
            var formated = value.Select(x => $"({x.X:F6} {x.Y:F6} {x.Z:F6} {x.W:F6})")
                                .Select(x => string.Join(" ", x));
            return WriteParam(xe, paramName, formated, new XAttribute("numelements", value.Count));
        }

        public XElement WriteQuaternion(XElement xe, string paramName, Quaternion value)
        {
            return WriteParam(xe, paramName, $"({value.X:F6} {value.Y:F6} {value.Z:F6} {value.W:F6})");
        }

        public XElement WriteQuaternionArray(XElement xe, string paramName, IList<Quaternion> value)
        {
            var formated = value.Select(x => $"({x.X:F6} {x.Y:F6} {x.Z:F6} {x.W:F6})")
                                .Select(x => string.Join(" ", x));
            return WriteParam(xe, paramName, formated, new XAttribute("numelements", value.Count));
        }

        public XElement WriteMatrix3(XElement xe, string paramName, Matrix4x4 value)
        {
            return WriteParam(xe, paramName, $"({value.M11:F6} {value.M12:F6} {value.M13:F6})({value.M21:F6} {value.M22:F6} {value.M23:F6})({value.M31:F6} {value.M32:F6} {value.M33:F6})");
        }

        public XElement WriteMatrix3Array(XElement xe, string paramName, IList<Matrix4x4> value)
        {
            var formated = value.Select(value => $"({value.M11:F6} {value.M12:F6} {value.M13:F6})({value.M21:F6} {value.M22:F6} {value.M23:F6})({value.M31:F6} {value.M32:F6} {value.M33:F6})")
                                .Select(x => string.Join(" ", x));
            return WriteParam(xe, paramName, formated, new XAttribute("numelements", value.Count));
        }

        public XElement WriteRotation(XElement xe, string paramName, Matrix4x4 value)
        {
            return WriteMatrix3(xe, paramName, value);
        }

        public XElement WriteRotationArray(XElement xe, string paramName, IList<Matrix4x4> value)
        {
            var formated = value.Select(value => $"({value.M11:F6} {value.M12:F6} {value.M13:F6})({value.M21:F6} {value.M22:F6} {value.M23:F6})({value.M31:F6} {value.M32:F6} {value.M33:F6})")
                                .Select(x => string.Join(" ", x));
            return WriteParam(xe, paramName, formated, new XAttribute("numelements", value.Count));
        }

        public XElement WriteQSTransform(XElement xe, string paramName, Matrix4x4 value)
        {
            return WriteParam(xe, paramName, $"({value.M11:F6} {value.M12:F6} {value.M13:F6})({value.M21:F6} {value.M22:F6} {value.M23:F6} {value.M24:F6})({value.M31:F6} {value.M32:F6} {value.M33:F6})");
        }

        public XElement WriteQSTransformArray(XElement xe, string paramName, IList<Matrix4x4> value)
        {
            var formated = value.Select(value => $"({value.M11:F6} {value.M12:F6} {value.M13:F6})({value.M21:F6} {value.M22:F6} {value.M23:F6} {value.M24:F6})({value.M31:F6} {value.M32:F6} {value.M33:F6})")
                                .Select(x => string.Join(" ", x));
            return WriteParam(xe, paramName, formated, new XAttribute("numelements", value.Count));
        }

        public XElement WriteMatrix4(XElement xe, string paramName, Matrix4x4 value)
        {
            // TODO: verify
            return WriteParam(xe, paramName, $"({value.M11:F6} {value.M12:F6} {value.M13:F6} {value.M14:F6})({value.M21:F6} {value.M22:F6} {value.M23:F6} {value.M24:F6})({value.M31:F6} {value.M32:F6} {value.M33:F6} {value.M34:F6})({value.M41:F6} {value.M42:F6} {value.M43:F6} {value.M44:F6})");
        }

        public XElement WriteMatrix4Array(XElement xe, string paramName, IList<Matrix4x4> value)
        {
            // TODO: verify
            var formated = value.Select(value => $"({value.M11:F6} {value.M12:F6} {value.M13:F6} {value.M14:F6})({value.M21:F6} {value.M22:F6} {value.M23:F6} {value.M24:F6})({value.M31:F6} {value.M32:F6} {value.M33:F6} {value.M34:F6})({value.M41:F6} {value.M42:F6} {value.M43:F6} {value.M44:F6})")
                                .Select(x => string.Join(" ", x));
            return WriteParam(xe, paramName, formated, new XAttribute("numelements", value.Count));
        }

        public XElement WriteTransform(XElement xe, string paramName, Matrix4x4 value)
        {
            return WriteParam(xe, paramName, $"({value.M11:F6} {value.M12:F6} {value.M13:F6})({value.M21:F6} {value.M22:F6} {value.M23:F6})({value.M31:F6} {value.M32:F6} {value.M33:F6})({value.M41:F6} {value.M42:F6} {value.M43:F6})");
        }

        public XElement WriteTransformArray(XElement xe, string paramName, IList<Matrix4x4> value)
        {
            var formated = value.Select(value => $"({value.M11:F6} {value.M12:F6} {value.M13:F6})({value.M21:F6} {value.M22:F6} {value.M23:F6})({value.M31:F6} {value.M32:F6} {value.M33:F6})({value.M41:F6} {value.M42:F6} {value.M43:F6})")
                                .Select(x => string.Join(" ", x));
            return WriteParam(xe, paramName, formated, new XAttribute("numelements", value.Count));
        }

        public XElement WriteString(XElement xe, string paramName, string? value)
        {
            return WriteParam(xe, paramName, value is null ? '\u2400' : value);
        }

        public XElement WriteStringArray(XElement xe, string paramName, IList<string> values)
        {
            var hkparam = WriteParam(xe, paramName);
            hkparam.Add(new XAttribute("numelements", values.Count));
            foreach (var item in values)
            {
                hkparam.Add(new XElement("hkcstring", item));
            }
            return hkparam;
        }

        public XElement WriteFlag<TEnum, TValue>(XElement xe, string paramName, TValue value) where TEnum : Enum where TValue : IBinaryInteger<TValue>
        {
            return WriteParam(xe, paramName, value.ToFlagString<TEnum, TValue>());
        }

        public XElement WriteEnum<TEnum, TValue>(XElement xe, string paramName, TValue value) where TEnum : Enum where TValue : IBinaryInteger<TValue>
        {

            return WriteParam(xe, paramName, value.ToEnumName<TEnum, TValue>());
        }

    }

}
