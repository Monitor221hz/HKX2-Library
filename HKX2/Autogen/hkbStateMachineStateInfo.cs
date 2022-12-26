using System;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    // hkbStateMachineStateInfo Signatire: 0xed7f9d0 size: 120 flags: FLAGS_NONE

    // m_listeners m_class: hkbStateListener Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 48 flags:  enum: 
    // m_enterNotifyEvents m_class: hkbStateMachineEventPropertyArray Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 64 flags:  enum: 
    // m_exitNotifyEvents m_class: hkbStateMachineEventPropertyArray Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 72 flags:  enum: 
    // m_transitions m_class: hkbStateMachineTransitionInfoArray Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 80 flags:  enum: 
    // m_generator m_class: hkbGenerator Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 88 flags:  enum: 
    // m_name m_class:  Type.TYPE_STRINGPTR Type.TYPE_VOID arrSize: 0 offset: 96 flags:  enum: 
    // m_stateId m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 104 flags:  enum: 
    // m_probability m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 108 flags:  enum: 
    // m_enable m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 112 flags:  enum: 
    
    public class hkbStateMachineStateInfo : hkbBindable
    {

        public List<hkbStateListener> m_listeners;
        public hkbStateMachineEventPropertyArray /*pointer struct*/ m_enterNotifyEvents;
        public hkbStateMachineEventPropertyArray /*pointer struct*/ m_exitNotifyEvents;
        public hkbStateMachineTransitionInfoArray /*pointer struct*/ m_transitions;
        public hkbGenerator /*pointer struct*/ m_generator;
        public string m_name;
        public int m_stateId;
        public float m_probability;
        public bool m_enable;

        public override uint Signature => 0xed7f9d0;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {

            base.Read(des, br);
            m_listeners = des.ReadClassPointerArray<hkbStateListener>(br);
            m_enterNotifyEvents = des.ReadClassPointer<hkbStateMachineEventPropertyArray>(br);
            m_exitNotifyEvents = des.ReadClassPointer<hkbStateMachineEventPropertyArray>(br);
            m_transitions = des.ReadClassPointer<hkbStateMachineTransitionInfoArray>(br);
            m_generator = des.ReadClassPointer<hkbGenerator>(br);
            m_name = des.ReadStringPointer(br);
            m_stateId = br.ReadInt32();
            m_probability = br.ReadSingle();
            m_enable = br.ReadBoolean();
            br.Position += 7;

            // throw new NotImplementedException("code generated. check first");
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {

            base.Write(s, bw);
            s.WriteClassPointerArray<hkbStateListener>(bw, m_listeners);
            s.WriteClassPointer(bw, m_enterNotifyEvents);
            s.WriteClassPointer(bw, m_exitNotifyEvents);
            s.WriteClassPointer(bw, m_transitions);
            s.WriteClassPointer(bw, m_generator);
            s.WriteStringPointer(bw, m_name);
            bw.WriteInt32(m_stateId);
            bw.WriteSingle(m_probability);
            bw.WriteBoolean(m_enable);
            bw.Position += 7;

            // throw new NotImplementedException("code generated. check first");
        }
    }
}

