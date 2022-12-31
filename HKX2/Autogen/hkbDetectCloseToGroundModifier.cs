using System.Xml.Linq;

namespace HKX2
{
    // hkbDetectCloseToGroundModifier Signatire: 0x981687b2 size: 120 flags: FLAGS_NONE

    // m_closeToGroundEvent m_class: hkbEventProperty Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 80 flags: FLAGS_NONE enum: 
    // m_closeToGroundHeight m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 96 flags: FLAGS_NONE enum: 
    // m_raycastDistanceDown m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 100 flags: FLAGS_NONE enum: 
    // m_collisionFilterInfo m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 104 flags: FLAGS_NONE enum: 
    // m_boneIndex m_class:  Type.TYPE_INT16 Type.TYPE_VOID arrSize: 0 offset: 108 flags: FLAGS_NONE enum: 
    // m_animBoneIndex m_class:  Type.TYPE_INT16 Type.TYPE_VOID arrSize: 0 offset: 110 flags: FLAGS_NONE enum: 
    // m_isCloseToGround m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 112 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    public partial class hkbDetectCloseToGroundModifier : hkbModifier
    {
        public hkbEventProperty m_closeToGroundEvent;
        public float m_closeToGroundHeight;
        public float m_raycastDistanceDown;
        public uint m_collisionFilterInfo;
        public short m_boneIndex;
        public short m_animBoneIndex;
        public bool m_isCloseToGround;

        public override uint Signature => 0x981687b2;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_closeToGroundEvent = new hkbEventProperty();
            m_closeToGroundEvent.Read(des, br);
            m_closeToGroundHeight = br.ReadSingle();
            m_raycastDistanceDown = br.ReadSingle();
            m_collisionFilterInfo = br.ReadUInt32();
            m_boneIndex = br.ReadInt16();
            m_animBoneIndex = br.ReadInt16();
            m_isCloseToGround = br.ReadBoolean();
            br.Position += 7;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            m_closeToGroundEvent.Write(s, bw);
            bw.WriteSingle(m_closeToGroundHeight);
            bw.WriteSingle(m_raycastDistanceDown);
            bw.WriteUInt32(m_collisionFilterInfo);
            bw.WriteInt16(m_boneIndex);
            bw.WriteInt16(m_animBoneIndex);
            bw.WriteBoolean(m_isCloseToGround);
            bw.Position += 7;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClass<hkbEventProperty>(xe, nameof(m_closeToGroundEvent), m_closeToGroundEvent);
            xs.WriteFloat(xe, nameof(m_closeToGroundHeight), m_closeToGroundHeight);
            xs.WriteFloat(xe, nameof(m_raycastDistanceDown), m_raycastDistanceDown);
            xs.WriteNumber(xe, nameof(m_collisionFilterInfo), m_collisionFilterInfo);
            xs.WriteNumber(xe, nameof(m_boneIndex), m_boneIndex);
            xs.WriteNumber(xe, nameof(m_animBoneIndex), m_animBoneIndex);
            xs.WriteSerializeIgnored(xe, nameof(m_isCloseToGround));
        }
    }
}

