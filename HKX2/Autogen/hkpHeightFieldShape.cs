using System.Xml.Linq;

namespace HKX2
{
    // hkpHeightFieldShape Signatire: 0xe7eca7eb size: 32 flags: FLAGS_NONE


    public partial class hkpHeightFieldShape : hkpShape
    {


        public override uint Signature => 0xe7eca7eb;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
        }
    }
}

