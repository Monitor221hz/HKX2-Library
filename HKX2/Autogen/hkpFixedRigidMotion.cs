using System.Xml.Linq;

namespace HKX2
{
    // hkpFixedRigidMotion Signatire: 0x64abf85c size: 320 flags: FLAGS_NONE


    public partial class hkpFixedRigidMotion : hkpKeyframedRigidMotion
    {


        public override uint Signature => 0x64abf85c;

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

