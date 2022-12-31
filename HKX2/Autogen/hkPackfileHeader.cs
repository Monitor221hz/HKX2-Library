using System.Collections.Generic;
using System.Xml.Linq;

namespace HKX2
{
    // hkPackfileHeader Signatire: 0x79f9ffda size: 64 flags: FLAGS_NONE

    // m_magic m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 2 offset: 0 flags: FLAGS_NONE enum: 
    // m_userTag m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 8 flags: FLAGS_NONE enum: 
    // m_fileVersion m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 12 flags: FLAGS_NONE enum: 
    // m_layoutRules m_class:  Type.TYPE_UINT8 Type.TYPE_VOID arrSize: 4 offset: 16 flags: FLAGS_NONE enum: 
    // m_numSections m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 20 flags: FLAGS_NONE enum: 
    // m_contentsSectionIndex m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 24 flags: FLAGS_NONE enum: 
    // m_contentsSectionOffset m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 28 flags: FLAGS_NONE enum: 
    // m_contentsClassNameSectionIndex m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    // m_contentsClassNameSectionOffset m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 36 flags: FLAGS_NONE enum: 
    // m_contentsVersion m_class:  Type.TYPE_CHAR Type.TYPE_VOID arrSize: 16 offset: 40 flags: FLAGS_NONE enum: 
    // m_flags m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 56 flags: FLAGS_NONE enum: 
    // m_pad m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 1 offset: 60 flags: FLAGS_NONE enum: 
    public partial class hkPackfileHeader : IHavokObject
    {
        public List<int> m_magic;
        public int m_userTag;
        public int m_fileVersion;
        public List<byte> m_layoutRules;
        public int m_numSections;
        public int m_contentsSectionIndex;
        public int m_contentsSectionOffset;
        public int m_contentsClassNameSectionIndex;
        public int m_contentsClassNameSectionOffset;
        public string m_contentsVersion;
        public int m_flags;
        public List<int> m_pad;

        public virtual uint Signature => 0x79f9ffda;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_magic = des.ReadInt32CStyleArray(br, 2);
            m_userTag = br.ReadInt32();
            m_fileVersion = br.ReadInt32();
            m_layoutRules = des.ReadByteCStyleArray(br, 4);
            m_numSections = br.ReadInt32();
            m_contentsSectionIndex = br.ReadInt32();
            m_contentsSectionOffset = br.ReadInt32();
            m_contentsClassNameSectionIndex = br.ReadInt32();
            m_contentsClassNameSectionOffset = br.ReadInt32();
            m_contentsVersion = br.ReadASCII(16);
            m_flags = br.ReadInt32();
            m_pad = des.ReadInt32CStyleArray(br, 1);
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            s.WriteInt32CStyleArray(bw, m_magic);
            bw.WriteInt32(m_userTag);
            bw.WriteInt32(m_fileVersion);
            s.WriteByteCStyleArray(bw, m_layoutRules);
            bw.WriteInt32(m_numSections);
            bw.WriteInt32(m_contentsSectionIndex);
            bw.WriteInt32(m_contentsSectionOffset);
            bw.WriteInt32(m_contentsClassNameSectionIndex);
            bw.WriteInt32(m_contentsClassNameSectionOffset);
            bw.WriteASCII(m_contentsVersion);
            bw.WriteInt32(m_flags);
            s.WriteInt32CStyleArray(bw, m_pad);
        }

        public virtual void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public virtual void WriteXml(XmlSerializer xs, XElement xe)
        {
            xs.WriteNumberArray(xe, nameof(m_magic), m_magic);
            xs.WriteNumber(xe, nameof(m_userTag), m_userTag);
            xs.WriteNumber(xe, nameof(m_fileVersion), m_fileVersion);
            xs.WriteNumberArray(xe, nameof(m_layoutRules), m_layoutRules);
            xs.WriteNumber(xe, nameof(m_numSections), m_numSections);
            xs.WriteNumber(xe, nameof(m_contentsSectionIndex), m_contentsSectionIndex);
            xs.WriteNumber(xe, nameof(m_contentsSectionOffset), m_contentsSectionOffset);
            xs.WriteNumber(xe, nameof(m_contentsClassNameSectionIndex), m_contentsClassNameSectionIndex);
            xs.WriteNumber(xe, nameof(m_contentsClassNameSectionOffset), m_contentsClassNameSectionOffset);
            xs.WriteString(xe, nameof(m_contentsVersion), m_contentsVersion);
            xs.WriteNumber(xe, nameof(m_flags), m_flags);
            xs.WriteNumberArray(xe, nameof(m_pad), m_pad);
        }
    }
}

