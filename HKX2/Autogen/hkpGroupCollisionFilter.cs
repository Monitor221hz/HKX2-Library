using System.Collections.Generic;
using System.Xml.Linq;

namespace HKX2
{
    // hkpGroupCollisionFilter Signatire: 0x5cc01561 size: 208 flags: FLAGS_NONE

    // m_noGroupCollisionEnabled m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 72 flags: FLAGS_NONE enum: 
    // m_collisionGroups m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 32 offset: 76 flags: FLAGS_NONE enum: 
    public partial class hkpGroupCollisionFilter : hkpCollisionFilter
    {
        public bool m_noGroupCollisionEnabled;
        public List<uint> m_collisionGroups;

        public override uint Signature => 0x5cc01561;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_noGroupCollisionEnabled = br.ReadBoolean();
            br.Position += 3;
            m_collisionGroups = des.ReadUInt32CStyleArray(br, 32);
            br.Position += 4;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteBoolean(m_noGroupCollisionEnabled);
            bw.Position += 3;
            s.WriteUInt32CStyleArray(bw, m_collisionGroups);
            bw.Position += 4;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteBoolean(xe, nameof(m_noGroupCollisionEnabled), m_noGroupCollisionEnabled);
            xs.WriteNumberArray(xe, nameof(m_collisionGroups), m_collisionGroups);
        }
    }
}

