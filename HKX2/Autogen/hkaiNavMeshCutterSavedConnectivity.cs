namespace HKX2
{
    public class hkaiNavMeshCutterSavedConnectivity : IHavokObject
    {
        public hkSetUint32 m_storage;
        public virtual uint Signature => 0;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_storage = new hkSetUint32();
            m_storage.Read(des, br);
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            m_storage.Write(s, bw);
        }
    }
}