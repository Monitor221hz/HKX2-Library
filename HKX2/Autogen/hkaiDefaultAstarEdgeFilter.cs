namespace HKX2
{
    public class hkaiDefaultAstarEdgeFilter : hkaiAstarEdgeFilter
    {
        public uint m_cellMaskLookupTable;

        public uint m_edgeMaskLookupTable_0;
        public uint m_edgeMaskLookupTable_1;
        public uint m_edgeMaskLookupTable_10;
        public uint m_edgeMaskLookupTable_11;
        public uint m_edgeMaskLookupTable_12;
        public uint m_edgeMaskLookupTable_13;
        public uint m_edgeMaskLookupTable_14;
        public uint m_edgeMaskLookupTable_15;
        public uint m_edgeMaskLookupTable_16;
        public uint m_edgeMaskLookupTable_17;
        public uint m_edgeMaskLookupTable_18;
        public uint m_edgeMaskLookupTable_19;
        public uint m_edgeMaskLookupTable_2;
        public uint m_edgeMaskLookupTable_20;
        public uint m_edgeMaskLookupTable_21;
        public uint m_edgeMaskLookupTable_22;
        public uint m_edgeMaskLookupTable_23;
        public uint m_edgeMaskLookupTable_24;
        public uint m_edgeMaskLookupTable_25;
        public uint m_edgeMaskLookupTable_26;
        public uint m_edgeMaskLookupTable_27;
        public uint m_edgeMaskLookupTable_28;
        public uint m_edgeMaskLookupTable_29;
        public uint m_edgeMaskLookupTable_3;
        public uint m_edgeMaskLookupTable_30;
        public uint m_edgeMaskLookupTable_31;
        public uint m_edgeMaskLookupTable_4;
        public uint m_edgeMaskLookupTable_5;
        public uint m_edgeMaskLookupTable_6;
        public uint m_edgeMaskLookupTable_7;
        public uint m_edgeMaskLookupTable_8;
        public uint m_edgeMaskLookupTable_9;
        public uint m_faceMaskLookupTable_0;
        public uint m_faceMaskLookupTable_1;
        public uint m_faceMaskLookupTable_10;
        public uint m_faceMaskLookupTable_11;
        public uint m_faceMaskLookupTable_12;
        public uint m_faceMaskLookupTable_13;
        public uint m_faceMaskLookupTable_14;
        public uint m_faceMaskLookupTable_15;
        public uint m_faceMaskLookupTable_16;
        public uint m_faceMaskLookupTable_17;
        public uint m_faceMaskLookupTable_18;
        public uint m_faceMaskLookupTable_19;
        public uint m_faceMaskLookupTable_2;
        public uint m_faceMaskLookupTable_20;
        public uint m_faceMaskLookupTable_21;
        public uint m_faceMaskLookupTable_22;
        public uint m_faceMaskLookupTable_23;
        public uint m_faceMaskLookupTable_24;
        public uint m_faceMaskLookupTable_25;
        public uint m_faceMaskLookupTable_26;
        public uint m_faceMaskLookupTable_27;
        public uint m_faceMaskLookupTable_28;
        public uint m_faceMaskLookupTable_29;
        public uint m_faceMaskLookupTable_3;
        public uint m_faceMaskLookupTable_30;
        public uint m_faceMaskLookupTable_31;
        public uint m_faceMaskLookupTable_4;
        public uint m_faceMaskLookupTable_5;
        public uint m_faceMaskLookupTable_6;
        public uint m_faceMaskLookupTable_7;
        public uint m_faceMaskLookupTable_8;
        public uint m_faceMaskLookupTable_9;
        public override uint Signature => 0;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_edgeMaskLookupTable_0 = br.ReadUInt32();
            m_edgeMaskLookupTable_1 = br.ReadUInt32();
            m_edgeMaskLookupTable_2 = br.ReadUInt32();
            m_edgeMaskLookupTable_3 = br.ReadUInt32();
            m_edgeMaskLookupTable_4 = br.ReadUInt32();
            m_edgeMaskLookupTable_5 = br.ReadUInt32();
            m_edgeMaskLookupTable_6 = br.ReadUInt32();
            m_edgeMaskLookupTable_7 = br.ReadUInt32();
            m_edgeMaskLookupTable_8 = br.ReadUInt32();
            m_edgeMaskLookupTable_9 = br.ReadUInt32();
            m_edgeMaskLookupTable_10 = br.ReadUInt32();
            m_edgeMaskLookupTable_11 = br.ReadUInt32();
            m_edgeMaskLookupTable_12 = br.ReadUInt32();
            m_edgeMaskLookupTable_13 = br.ReadUInt32();
            m_edgeMaskLookupTable_14 = br.ReadUInt32();
            m_edgeMaskLookupTable_15 = br.ReadUInt32();
            m_edgeMaskLookupTable_16 = br.ReadUInt32();
            m_edgeMaskLookupTable_17 = br.ReadUInt32();
            m_edgeMaskLookupTable_18 = br.ReadUInt32();
            m_edgeMaskLookupTable_19 = br.ReadUInt32();
            m_edgeMaskLookupTable_20 = br.ReadUInt32();
            m_edgeMaskLookupTable_21 = br.ReadUInt32();
            m_edgeMaskLookupTable_22 = br.ReadUInt32();
            m_edgeMaskLookupTable_23 = br.ReadUInt32();
            m_edgeMaskLookupTable_24 = br.ReadUInt32();
            m_edgeMaskLookupTable_25 = br.ReadUInt32();
            m_edgeMaskLookupTable_26 = br.ReadUInt32();
            m_edgeMaskLookupTable_27 = br.ReadUInt32();
            m_edgeMaskLookupTable_28 = br.ReadUInt32();
            m_edgeMaskLookupTable_29 = br.ReadUInt32();
            m_edgeMaskLookupTable_30 = br.ReadUInt32();
            m_edgeMaskLookupTable_31 = br.ReadUInt32();
            m_faceMaskLookupTable_0 = br.ReadUInt32();
            m_faceMaskLookupTable_1 = br.ReadUInt32();
            m_faceMaskLookupTable_2 = br.ReadUInt32();
            m_faceMaskLookupTable_3 = br.ReadUInt32();
            m_faceMaskLookupTable_4 = br.ReadUInt32();
            m_faceMaskLookupTable_5 = br.ReadUInt32();
            m_faceMaskLookupTable_6 = br.ReadUInt32();
            m_faceMaskLookupTable_7 = br.ReadUInt32();
            m_faceMaskLookupTable_8 = br.ReadUInt32();
            m_faceMaskLookupTable_9 = br.ReadUInt32();
            m_faceMaskLookupTable_10 = br.ReadUInt32();
            m_faceMaskLookupTable_11 = br.ReadUInt32();
            m_faceMaskLookupTable_12 = br.ReadUInt32();
            m_faceMaskLookupTable_13 = br.ReadUInt32();
            m_faceMaskLookupTable_14 = br.ReadUInt32();
            m_faceMaskLookupTable_15 = br.ReadUInt32();
            m_faceMaskLookupTable_16 = br.ReadUInt32();
            m_faceMaskLookupTable_17 = br.ReadUInt32();
            m_faceMaskLookupTable_18 = br.ReadUInt32();
            m_faceMaskLookupTable_19 = br.ReadUInt32();
            m_faceMaskLookupTable_20 = br.ReadUInt32();
            m_faceMaskLookupTable_21 = br.ReadUInt32();
            m_faceMaskLookupTable_22 = br.ReadUInt32();
            m_faceMaskLookupTable_23 = br.ReadUInt32();
            m_faceMaskLookupTable_24 = br.ReadUInt32();
            m_faceMaskLookupTable_25 = br.ReadUInt32();
            m_faceMaskLookupTable_26 = br.ReadUInt32();
            m_faceMaskLookupTable_27 = br.ReadUInt32();
            m_faceMaskLookupTable_28 = br.ReadUInt32();
            m_faceMaskLookupTable_29 = br.ReadUInt32();
            m_faceMaskLookupTable_30 = br.ReadUInt32();
            m_faceMaskLookupTable_31 = br.ReadUInt32();
            m_cellMaskLookupTable = br.ReadUInt32();
            br.ReadUInt64();
            br.ReadUInt32();
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteUInt32(m_edgeMaskLookupTable_0);
            bw.WriteUInt32(m_edgeMaskLookupTable_1);
            bw.WriteUInt32(m_edgeMaskLookupTable_2);
            bw.WriteUInt32(m_edgeMaskLookupTable_3);
            bw.WriteUInt32(m_edgeMaskLookupTable_4);
            bw.WriteUInt32(m_edgeMaskLookupTable_5);
            bw.WriteUInt32(m_edgeMaskLookupTable_6);
            bw.WriteUInt32(m_edgeMaskLookupTable_7);
            bw.WriteUInt32(m_edgeMaskLookupTable_8);
            bw.WriteUInt32(m_edgeMaskLookupTable_9);
            bw.WriteUInt32(m_edgeMaskLookupTable_10);
            bw.WriteUInt32(m_edgeMaskLookupTable_11);
            bw.WriteUInt32(m_edgeMaskLookupTable_12);
            bw.WriteUInt32(m_edgeMaskLookupTable_13);
            bw.WriteUInt32(m_edgeMaskLookupTable_14);
            bw.WriteUInt32(m_edgeMaskLookupTable_15);
            bw.WriteUInt32(m_edgeMaskLookupTable_16);
            bw.WriteUInt32(m_edgeMaskLookupTable_17);
            bw.WriteUInt32(m_edgeMaskLookupTable_18);
            bw.WriteUInt32(m_edgeMaskLookupTable_19);
            bw.WriteUInt32(m_edgeMaskLookupTable_20);
            bw.WriteUInt32(m_edgeMaskLookupTable_21);
            bw.WriteUInt32(m_edgeMaskLookupTable_22);
            bw.WriteUInt32(m_edgeMaskLookupTable_23);
            bw.WriteUInt32(m_edgeMaskLookupTable_24);
            bw.WriteUInt32(m_edgeMaskLookupTable_25);
            bw.WriteUInt32(m_edgeMaskLookupTable_26);
            bw.WriteUInt32(m_edgeMaskLookupTable_27);
            bw.WriteUInt32(m_edgeMaskLookupTable_28);
            bw.WriteUInt32(m_edgeMaskLookupTable_29);
            bw.WriteUInt32(m_edgeMaskLookupTable_30);
            bw.WriteUInt32(m_edgeMaskLookupTable_31);
            bw.WriteUInt32(m_faceMaskLookupTable_0);
            bw.WriteUInt32(m_faceMaskLookupTable_1);
            bw.WriteUInt32(m_faceMaskLookupTable_2);
            bw.WriteUInt32(m_faceMaskLookupTable_3);
            bw.WriteUInt32(m_faceMaskLookupTable_4);
            bw.WriteUInt32(m_faceMaskLookupTable_5);
            bw.WriteUInt32(m_faceMaskLookupTable_6);
            bw.WriteUInt32(m_faceMaskLookupTable_7);
            bw.WriteUInt32(m_faceMaskLookupTable_8);
            bw.WriteUInt32(m_faceMaskLookupTable_9);
            bw.WriteUInt32(m_faceMaskLookupTable_10);
            bw.WriteUInt32(m_faceMaskLookupTable_11);
            bw.WriteUInt32(m_faceMaskLookupTable_12);
            bw.WriteUInt32(m_faceMaskLookupTable_13);
            bw.WriteUInt32(m_faceMaskLookupTable_14);
            bw.WriteUInt32(m_faceMaskLookupTable_15);
            bw.WriteUInt32(m_faceMaskLookupTable_16);
            bw.WriteUInt32(m_faceMaskLookupTable_17);
            bw.WriteUInt32(m_faceMaskLookupTable_18);
            bw.WriteUInt32(m_faceMaskLookupTable_19);
            bw.WriteUInt32(m_faceMaskLookupTable_20);
            bw.WriteUInt32(m_faceMaskLookupTable_21);
            bw.WriteUInt32(m_faceMaskLookupTable_22);
            bw.WriteUInt32(m_faceMaskLookupTable_23);
            bw.WriteUInt32(m_faceMaskLookupTable_24);
            bw.WriteUInt32(m_faceMaskLookupTable_25);
            bw.WriteUInt32(m_faceMaskLookupTable_26);
            bw.WriteUInt32(m_faceMaskLookupTable_27);
            bw.WriteUInt32(m_faceMaskLookupTable_28);
            bw.WriteUInt32(m_faceMaskLookupTable_29);
            bw.WriteUInt32(m_faceMaskLookupTable_30);
            bw.WriteUInt32(m_faceMaskLookupTable_31);
            bw.WriteUInt32(m_cellMaskLookupTable);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
        }
    }
}