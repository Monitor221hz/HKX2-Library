using System;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    // hkxVertexVectorDataChannel Signatire: 0x2ea63179 size: 32 flags: FLAGS_NONE

    // m_perVertexVectors m_class:  Type.TYPE_ARRAY Type.TYPE_VECTOR4 arrSize: 0 offset: 16 flags:  enum: 
    
    public class hkxVertexVectorDataChannel : hkReferencedObject
    {

        public List<Vector4> m_perVertexVectors;

        public override uint Signature => 0x2ea63179;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {

            base.Read(des, br);
            m_perVertexVectors = des.ReadVector4Array(br);

            // throw new NotImplementedException("code generated. check first");
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {

            base.Write(s, bw);
            s.WriteVector4Array(bw, m_perVertexVectors);

            // throw new NotImplementedException("code generated. check first");
        }
    }
}

