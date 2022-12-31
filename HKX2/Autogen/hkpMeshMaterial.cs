using System.Xml.Linq;

namespace HKX2
{
    // hkpMeshMaterial Signatire: 0x886cde0c size: 4 flags: FLAGS_NONE

    // m_filterInfo m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 0 flags: FLAGS_NONE enum: 
    public partial class hkpMeshMaterial : IHavokObject
    {
        public uint m_filterInfo;

        public virtual uint Signature => 0x886cde0c;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_filterInfo = br.ReadUInt32();
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            bw.WriteUInt32(m_filterInfo);
        }

        public virtual void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public virtual void WriteXml(XmlSerializer xs, XElement xe)
        {
            xs.WriteNumber(xe, nameof(m_filterInfo), m_filterInfo);
        }
    }
}

