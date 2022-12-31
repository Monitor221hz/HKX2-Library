using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkaMeshBinding Signatire: 0x81d9950b size: 72 flags: FLAGS_NONE

    // m_mesh m_class: hkxMesh Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_originalSkeletonName m_class:  Type.TYPE_STRINGPTR Type.TYPE_VOID arrSize: 0 offset: 24 flags: FLAGS_NONE enum: 
    // m_skeleton m_class: hkaSkeleton Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    // m_mappings m_class: hkaMeshBindingMapping Type.TYPE_ARRAY Type.TYPE_STRUCT arrSize: 0 offset: 40 flags: FLAGS_NONE enum: 
    // m_boneFromSkinMeshTransforms m_class:  Type.TYPE_ARRAY Type.TYPE_TRANSFORM arrSize: 0 offset: 56 flags: FLAGS_NONE enum: 
    public partial class hkaMeshBinding : hkReferencedObject
    {
        public hkxMesh m_mesh;
        public string m_originalSkeletonName;
        public hkaSkeleton m_skeleton;
        public List<hkaMeshBindingMapping> m_mappings;
        public List<Matrix4x4> m_boneFromSkinMeshTransforms;

        public override uint Signature => 0x81d9950b;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_mesh = des.ReadClassPointer<hkxMesh>(br);
            m_originalSkeletonName = des.ReadStringPointer(br);
            m_skeleton = des.ReadClassPointer<hkaSkeleton>(br);
            m_mappings = des.ReadClassArray<hkaMeshBindingMapping>(br);
            m_boneFromSkinMeshTransforms = des.ReadTransformArray(br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteClassPointer(bw, m_mesh);
            s.WriteStringPointer(bw, m_originalSkeletonName);
            s.WriteClassPointer(bw, m_skeleton);
            s.WriteClassArray<hkaMeshBindingMapping>(bw, m_mappings);
            s.WriteTransformArray(bw, m_boneFromSkinMeshTransforms);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClassPointer(xe, nameof(m_mesh), m_mesh);
            xs.WriteString(xe, nameof(m_originalSkeletonName), m_originalSkeletonName);
            xs.WriteClassPointer(xe, nameof(m_skeleton), m_skeleton);
            xs.WriteClassArray<hkaMeshBindingMapping>(xe, nameof(m_mappings), m_mappings);
            xs.WriteTransformArray(xe, nameof(m_boneFromSkinMeshTransforms), m_boneFromSkinMeshTransforms);
        }
    }
}

