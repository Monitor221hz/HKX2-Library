using System.Xml.Linq;

namespace HKX2
{
    // hkbCameraShakeEventPayload Signatire: 0x64136982 size: 24 flags: FLAGS_NONE

    // m_amplitude m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_halfLife m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 20 flags: FLAGS_NONE enum: 
    public partial class hkbCameraShakeEventPayload : hkbEventPayload
    {
        public float m_amplitude;
        public float m_halfLife;

        public override uint Signature => 0x64136982;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_amplitude = br.ReadSingle();
            m_halfLife = br.ReadSingle();
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteSingle(m_amplitude);
            bw.WriteSingle(m_halfLife);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteFloat(xe, nameof(m_amplitude), m_amplitude);
            xs.WriteFloat(xe, nameof(m_halfLife), m_halfLife);
        }
    }
}

