﻿/****************************************************************************
Copyright (c) 2013-2015 scutgame.com

http://www.scutgame.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
****************************************************************************/
using System;
using ProtoBuf;
using ZyGames.Framework.Model;
using System.Collections.Generic;

namespace GameServer.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable, ProtoContract]
    [EntityTable(CacheType.Entity, "ConnData")]
    public class ShareRealItemCnt : ShareEntity
    {
        public ShareRealItemCnt()
            : base(false)
        {
            preUpdateTime = DateTime.Now;
        }

        [ProtoMember(1)]
        [EntityField(true)]
        public int itemID
        {
            get;
            set;
        }

        [ProtoMember(2)]
        [EntityField]
        public int num
        {
            get;
            set;
        }

        [ProtoMember(3)]
        [EntityField]
        public DateTime preUpdateTime
        {
            get;
            set;
        }

        protected override int GetIdentityId()
        {
            return itemID;
        }
    }

}