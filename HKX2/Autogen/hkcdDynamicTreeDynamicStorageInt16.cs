namespace HKX2
{
    public class hkcdDynamicTreeDynamicStorageInt16 : hkcdDynamicTreeDefaultDynamicStoragehkcdDynamicTreeCodecInt16
    {
        public override uint Signature => 0;


        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
        }
    }
}