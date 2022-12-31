using System.Collections.Generic;
using System.Xml.Linq;

namespace HKX2
{
    // hkbVariableBindingSet Signatire: 0x338ad4ff size: 40 flags: FLAGS_NONE

    // m_bindings m_class: hkbVariableBindingSetBinding Type.TYPE_ARRAY Type.TYPE_STRUCT arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_indexOfBindingToEnable m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    // m_hasOutputBinding m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 36 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    public partial class hkbVariableBindingSet : hkReferencedObject
    {
        public List<hkbVariableBindingSetBinding> m_bindings;
        public int m_indexOfBindingToEnable;
        public bool m_hasOutputBinding;

        public override uint Signature => 0x338ad4ff;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_bindings = des.ReadClassArray<hkbVariableBindingSetBinding>(br);
            m_indexOfBindingToEnable = br.ReadInt32();
            m_hasOutputBinding = br.ReadBoolean();
            br.Position += 3;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteClassArray<hkbVariableBindingSetBinding>(bw, m_bindings);
            bw.WriteInt32(m_indexOfBindingToEnable);
            bw.WriteBoolean(m_hasOutputBinding);
            bw.Position += 3;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClassArray<hkbVariableBindingSetBinding>(xe, nameof(m_bindings), m_bindings);
            xs.WriteNumber(xe, nameof(m_indexOfBindingToEnable), m_indexOfBindingToEnable);
            xs.WriteSerializeIgnored(xe, nameof(m_hasOutputBinding));
        }
    }
}

