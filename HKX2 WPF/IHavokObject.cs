﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

using Type = System.Type;
namespace HKX2
{
    public interface IHavokObject
    {
        public uint Signature { set; get; }

        public void Read(PackFileDeserializer des, BinaryReaderEx br);

        public void Write(PackFileSerializer s, BinaryWriterEx bw);
        public void WriteXml(XmlSerializer xs, XElement xe);
        public void ReadXml(XmlDeserializer xd, XElement xe);
    }



}