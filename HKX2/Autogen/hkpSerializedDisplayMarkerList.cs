using System.Collections.Generic;
using System.Xml.Linq;

namespace HKX2
{
    // hkpSerializedDisplayMarkerList Signatire: 0x54785c77 size: 32 flags: FLAGS_NONE

    // m_markers m_class: hkpSerializedDisplayMarker Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    public partial class hkpSerializedDisplayMarkerList : hkReferencedObject
    {
        public List<hkpSerializedDisplayMarker> m_markers;

        public override uint Signature => 0x54785c77;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_markers = des.ReadClassPointerArray<hkpSerializedDisplayMarker>(br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteClassPointerArray<hkpSerializedDisplayMarker>(bw, m_markers);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClassPointerArray<hkpSerializedDisplayMarker>(xe, nameof(m_markers), m_markers);
        }
    }
}

