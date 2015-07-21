﻿using System;
using ProtoBuf;

namespace Game.YYS.Protocol
{
    [ProtoContract]
    public class RequestPackHead
    {
        [ProtoMember(1)]
        public int MsgId { get; set; }

        [ProtoMember(2)]
        public int ActionId { get; set; }

        [ProtoMember(3)]
        public string SessionId { get; set; }

        [ProtoMember(4)]
        public int UserId { get; set; }

    }

    [ProtoContract]
    public class RequestPackDataBase
    {
        [ProtoMember(201)]
        public string version { get; set; }

        [ProtoMember(202)]
        public int UserID { get; set; }

        [ProtoMember(203)]
        public string identify { get; set; }

    }
}