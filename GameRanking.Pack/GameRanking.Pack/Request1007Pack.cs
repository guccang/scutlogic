﻿using System;
using ProtoBuf;

namespace GameRanking.Pack
{
    [ProtoContract]
    public class Request1007Pack
    {
        [ProtoMember(101)]
        public int UserID { get; set; }

        [ProtoMember(102)]
        public string identify { get; set; }

        [ProtoMember(103)]
        public string version { get; set; }

        [ProtoMember(104)]
        public uint the3rdUserID { get; set; }

        [ProtoMember(105)]
        public byte dateType { get; set; }
        
        [ProtoMember(106)]
        public string strThe3rdUserID { get; set; }

        [ProtoMember(107)]
        public string typeUser { get; set; }
    }
}