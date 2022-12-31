using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkbBlendingTransitionEffectInternalState Signatire: 0xb18c70c2 size: 48 flags: FLAGS_NONE

    // m_characterPoseAtBeginningOfTransition m_class:  Type.TYPE_ARRAY Type.TYPE_QSTRANSFORM arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_timeRemaining m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    // m_timeInTransition m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 36 flags: FLAGS_NONE enum: 
    // m_applySelfTransition m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 40 flags: FLAGS_NONE enum: 
    // m_initializeCharacterPose m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 41 flags: FLAGS_NONE enum: 
    public partial class hkbBlendingTransitionEffectInternalState : hkReferencedObject
    {
        public List<Matrix4x4> m_characterPoseAtBeginningOfTransition;
        public float m_timeRemaining;
        public float m_timeInTransition;
        public bool m_applySelfTransition;
        public bool m_initializeCharacterPose;

        public override uint Signature => 0xb18c70c2;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_characterPoseAtBeginningOfTransition = des.ReadQSTransformArray(br);
            m_timeRemaining = br.ReadSingle();
            m_timeInTransition = br.ReadSingle();
            m_applySelfTransition = br.ReadBoolean();
            m_initializeCharacterPose = br.ReadBoolean();
            br.Position += 6;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteQSTransformArray(bw, m_characterPoseAtBeginningOfTransition);
            bw.WriteSingle(m_timeRemaining);
            bw.WriteSingle(m_timeInTransition);
            bw.WriteBoolean(m_applySelfTransition);
            bw.WriteBoolean(m_initializeCharacterPose);
            bw.Position += 6;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteQSTransformArray(xe, nameof(m_characterPoseAtBeginningOfTransition), m_characterPoseAtBeginningOfTransition);
            xs.WriteFloat(xe, nameof(m_timeRemaining), m_timeRemaining);
            xs.WriteFloat(xe, nameof(m_timeInTransition), m_timeInTransition);
            xs.WriteBoolean(xe, nameof(m_applySelfTransition), m_applySelfTransition);
            xs.WriteBoolean(xe, nameof(m_initializeCharacterPose), m_initializeCharacterPose);
        }
    }
}

