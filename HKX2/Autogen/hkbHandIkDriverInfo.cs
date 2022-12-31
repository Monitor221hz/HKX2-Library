using System.Collections.Generic;
using System.Xml.Linq;

namespace HKX2
{
    // hkbHandIkDriverInfo Signatire: 0xc299090a size: 40 flags: FLAGS_NONE

    // m_hands m_class: hkbHandIkDriverInfoHand Type.TYPE_ARRAY Type.TYPE_STRUCT arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_fadeInOutCurve m_class:  Type.TYPE_ENUM Type.TYPE_INT8 arrSize: 0 offset: 32 flags: FLAGS_NONE enum: BlendCurve
    public partial class hkbHandIkDriverInfo : hkReferencedObject
    {
        public List<hkbHandIkDriverInfoHand> m_hands;
        public sbyte m_fadeInOutCurve;

        public override uint Signature => 0xc299090a;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_hands = des.ReadClassArray<hkbHandIkDriverInfoHand>(br);
            m_fadeInOutCurve = br.ReadSByte();
            br.Position += 7;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteClassArray<hkbHandIkDriverInfoHand>(bw, m_hands);
            s.WriteSByte(bw, m_fadeInOutCurve);
            bw.Position += 7;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClassArray<hkbHandIkDriverInfoHand>(xe, nameof(m_hands), m_hands);
            xs.WriteEnum<BlendCurve, sbyte>(xe, nameof(m_fadeInOutCurve), m_fadeInOutCurve);
        }
    }
}

