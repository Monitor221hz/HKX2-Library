namespace HKX2
{
    public class hclObjectSpaceDeformerLocalBlockP : IHavokObject
    {
        public short m_localPosition_0;
        public short m_localPosition_1;
        public short m_localPosition_10;
        public short m_localPosition_11;
        public short m_localPosition_12;
        public short m_localPosition_13;
        public short m_localPosition_14;
        public short m_localPosition_15;
        public short m_localPosition_16;
        public short m_localPosition_17;
        public short m_localPosition_18;
        public short m_localPosition_19;
        public short m_localPosition_2;
        public short m_localPosition_20;
        public short m_localPosition_21;
        public short m_localPosition_22;
        public short m_localPosition_23;
        public short m_localPosition_24;
        public short m_localPosition_25;
        public short m_localPosition_26;
        public short m_localPosition_27;
        public short m_localPosition_28;
        public short m_localPosition_29;
        public short m_localPosition_3;
        public short m_localPosition_30;
        public short m_localPosition_31;
        public short m_localPosition_32;
        public short m_localPosition_33;
        public short m_localPosition_34;
        public short m_localPosition_35;
        public short m_localPosition_36;
        public short m_localPosition_37;
        public short m_localPosition_38;
        public short m_localPosition_39;
        public short m_localPosition_4;
        public short m_localPosition_40;
        public short m_localPosition_41;
        public short m_localPosition_42;
        public short m_localPosition_43;
        public short m_localPosition_44;
        public short m_localPosition_45;
        public short m_localPosition_46;
        public short m_localPosition_47;
        public short m_localPosition_48;
        public short m_localPosition_49;
        public short m_localPosition_5;
        public short m_localPosition_50;
        public short m_localPosition_51;
        public short m_localPosition_52;
        public short m_localPosition_53;
        public short m_localPosition_54;
        public short m_localPosition_55;
        public short m_localPosition_56;
        public short m_localPosition_57;
        public short m_localPosition_58;
        public short m_localPosition_59;
        public short m_localPosition_6;
        public short m_localPosition_60;
        public short m_localPosition_61;
        public short m_localPosition_62;
        public short m_localPosition_63;
        public short m_localPosition_7;
        public short m_localPosition_8;
        public short m_localPosition_9;
        public virtual uint Signature => 0x0;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_localPosition_0 = br.ReadInt16();
            m_localPosition_1 = br.ReadInt16();
            m_localPosition_2 = br.ReadInt16();
            m_localPosition_3 = br.ReadInt16();
            m_localPosition_4 = br.ReadInt16();
            m_localPosition_5 = br.ReadInt16();
            m_localPosition_6 = br.ReadInt16();
            m_localPosition_7 = br.ReadInt16();
            m_localPosition_8 = br.ReadInt16();
            m_localPosition_9 = br.ReadInt16();
            m_localPosition_10 = br.ReadInt16();
            m_localPosition_11 = br.ReadInt16();
            m_localPosition_12 = br.ReadInt16();
            m_localPosition_13 = br.ReadInt16();
            m_localPosition_14 = br.ReadInt16();
            m_localPosition_15 = br.ReadInt16();
            m_localPosition_16 = br.ReadInt16();
            m_localPosition_17 = br.ReadInt16();
            m_localPosition_18 = br.ReadInt16();
            m_localPosition_19 = br.ReadInt16();
            m_localPosition_20 = br.ReadInt16();
            m_localPosition_21 = br.ReadInt16();
            m_localPosition_22 = br.ReadInt16();
            m_localPosition_23 = br.ReadInt16();
            m_localPosition_24 = br.ReadInt16();
            m_localPosition_25 = br.ReadInt16();
            m_localPosition_26 = br.ReadInt16();
            m_localPosition_27 = br.ReadInt16();
            m_localPosition_28 = br.ReadInt16();
            m_localPosition_29 = br.ReadInt16();
            m_localPosition_30 = br.ReadInt16();
            m_localPosition_31 = br.ReadInt16();
            m_localPosition_32 = br.ReadInt16();
            m_localPosition_33 = br.ReadInt16();
            m_localPosition_34 = br.ReadInt16();
            m_localPosition_35 = br.ReadInt16();
            m_localPosition_36 = br.ReadInt16();
            m_localPosition_37 = br.ReadInt16();
            m_localPosition_38 = br.ReadInt16();
            m_localPosition_39 = br.ReadInt16();
            m_localPosition_40 = br.ReadInt16();
            m_localPosition_41 = br.ReadInt16();
            m_localPosition_42 = br.ReadInt16();
            m_localPosition_43 = br.ReadInt16();
            m_localPosition_44 = br.ReadInt16();
            m_localPosition_45 = br.ReadInt16();
            m_localPosition_46 = br.ReadInt16();
            m_localPosition_47 = br.ReadInt16();
            m_localPosition_48 = br.ReadInt16();
            m_localPosition_49 = br.ReadInt16();
            m_localPosition_50 = br.ReadInt16();
            m_localPosition_51 = br.ReadInt16();
            m_localPosition_52 = br.ReadInt16();
            m_localPosition_53 = br.ReadInt16();
            m_localPosition_54 = br.ReadInt16();
            m_localPosition_55 = br.ReadInt16();
            m_localPosition_56 = br.ReadInt16();
            m_localPosition_57 = br.ReadInt16();
            m_localPosition_58 = br.ReadInt16();
            m_localPosition_59 = br.ReadInt16();
            m_localPosition_60 = br.ReadInt16();
            m_localPosition_61 = br.ReadInt16();
            m_localPosition_62 = br.ReadInt16();
            m_localPosition_63 = br.ReadInt16();
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            bw.WriteInt16(m_localPosition_0);
            bw.WriteInt16(m_localPosition_1);
            bw.WriteInt16(m_localPosition_2);
            bw.WriteInt16(m_localPosition_3);
            bw.WriteInt16(m_localPosition_4);
            bw.WriteInt16(m_localPosition_5);
            bw.WriteInt16(m_localPosition_6);
            bw.WriteInt16(m_localPosition_7);
            bw.WriteInt16(m_localPosition_8);
            bw.WriteInt16(m_localPosition_9);
            bw.WriteInt16(m_localPosition_10);
            bw.WriteInt16(m_localPosition_11);
            bw.WriteInt16(m_localPosition_12);
            bw.WriteInt16(m_localPosition_13);
            bw.WriteInt16(m_localPosition_14);
            bw.WriteInt16(m_localPosition_15);
            bw.WriteInt16(m_localPosition_16);
            bw.WriteInt16(m_localPosition_17);
            bw.WriteInt16(m_localPosition_18);
            bw.WriteInt16(m_localPosition_19);
            bw.WriteInt16(m_localPosition_20);
            bw.WriteInt16(m_localPosition_21);
            bw.WriteInt16(m_localPosition_22);
            bw.WriteInt16(m_localPosition_23);
            bw.WriteInt16(m_localPosition_24);
            bw.WriteInt16(m_localPosition_25);
            bw.WriteInt16(m_localPosition_26);
            bw.WriteInt16(m_localPosition_27);
            bw.WriteInt16(m_localPosition_28);
            bw.WriteInt16(m_localPosition_29);
            bw.WriteInt16(m_localPosition_30);
            bw.WriteInt16(m_localPosition_31);
            bw.WriteInt16(m_localPosition_32);
            bw.WriteInt16(m_localPosition_33);
            bw.WriteInt16(m_localPosition_34);
            bw.WriteInt16(m_localPosition_35);
            bw.WriteInt16(m_localPosition_36);
            bw.WriteInt16(m_localPosition_37);
            bw.WriteInt16(m_localPosition_38);
            bw.WriteInt16(m_localPosition_39);
            bw.WriteInt16(m_localPosition_40);
            bw.WriteInt16(m_localPosition_41);
            bw.WriteInt16(m_localPosition_42);
            bw.WriteInt16(m_localPosition_43);
            bw.WriteInt16(m_localPosition_44);
            bw.WriteInt16(m_localPosition_45);
            bw.WriteInt16(m_localPosition_46);
            bw.WriteInt16(m_localPosition_47);
            bw.WriteInt16(m_localPosition_48);
            bw.WriteInt16(m_localPosition_49);
            bw.WriteInt16(m_localPosition_50);
            bw.WriteInt16(m_localPosition_51);
            bw.WriteInt16(m_localPosition_52);
            bw.WriteInt16(m_localPosition_53);
            bw.WriteInt16(m_localPosition_54);
            bw.WriteInt16(m_localPosition_55);
            bw.WriteInt16(m_localPosition_56);
            bw.WriteInt16(m_localPosition_57);
            bw.WriteInt16(m_localPosition_58);
            bw.WriteInt16(m_localPosition_59);
            bw.WriteInt16(m_localPosition_60);
            bw.WriteInt16(m_localPosition_61);
            bw.WriteInt16(m_localPosition_62);
            bw.WriteInt16(m_localPosition_63);
        }
    }
}