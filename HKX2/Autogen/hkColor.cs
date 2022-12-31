using System.Xml.Linq;

namespace HKX2
{
    // hkColor Signatire: 0x106b96ce size: 1 flags: FLAGS_NONE


    public partial class hkColor : IHavokObject
    {
        public byte[] unk0;

        public virtual uint Signature => 0x106b96ce;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            unk0 = br.ReadBytes(1);
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            bw.WriteBytes(unk0);
        }

        public virtual void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public virtual void WriteXml(XmlSerializer xs, XElement xe)
        {

        }
    }
}

