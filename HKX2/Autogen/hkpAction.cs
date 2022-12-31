using System.Xml.Linq;

namespace HKX2
{
    // hkpAction Signatire: 0xbdf70a51 size: 48 flags: FLAGS_NONE

    // m_world m_class:  Type.TYPE_POINTER Type.TYPE_VOID arrSize: 0 offset: 16 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_island m_class:  Type.TYPE_POINTER Type.TYPE_VOID arrSize: 0 offset: 24 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_userData m_class:  Type.TYPE_ULONG Type.TYPE_VOID arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    // m_name m_class:  Type.TYPE_STRINGPTR Type.TYPE_VOID arrSize: 0 offset: 40 flags: FLAGS_NONE enum: 
    public partial class hkpAction : hkReferencedObject
    {
        public dynamic m_world;
        public dynamic m_island;
        public ulong m_userData;
        public string m_name;

        public override uint Signature => 0xbdf70a51;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            des.ReadEmptyPointer(br);
            des.ReadEmptyPointer(br);
            m_userData = br.ReadUInt64();
            m_name = des.ReadStringPointer(br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteVoidPointer(bw);
            s.WriteVoidPointer(bw);
            bw.WriteUInt64(m_userData);
            s.WriteStringPointer(bw, m_name);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteSerializeIgnored(xe, nameof(m_world));
            xs.WriteSerializeIgnored(xe, nameof(m_island));
            xs.WriteNumber(xe, nameof(m_userData), m_userData);
            xs.WriteString(xe, nameof(m_name), m_name);
        }
    }
}

