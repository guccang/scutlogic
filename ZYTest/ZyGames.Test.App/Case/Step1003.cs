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

using ZyGames.Framework.Common;
using ZyGames.Framework.RPC.IO;
using ZyGames.Test;
using GameRanking.Pack;
using ZyGames.Framework.Common.Serialization;
using System.Collections.Generic;

namespace ZyGames.Quanmin.Test.Case
{
    /// <summary>
    /// 登录
    /// </summary>
    public class Step1003 : CaseStep
    {
        static int index = 0;
        Response1003Pack responsePack = null;
        List<string> version;

        protected override void SetUrlElement()
        {
           
            Request1003Pack req = new Request1003Pack();
            req.code = "D3VIEHTN3";
            req.type = 12;
            req.index = 0;
            // req.Ip = "123.57.73.204";
            byte[] data = ProtoBufUtils.Serialize(req);
            netWriter.SetBodyData(data);

        }

        protected override bool DecodePacket(MessageStructure reader, MessageHead head)
        {
            responsePack = ProtoBufUtils.Deserialize<Response1003Pack>(netReader.Buffer);
            string responseDataInfo = "";
            responseDataInfo += "result:"+responsePack.result;
            responseDataInfo += "code:"+responsePack.code;
            responseDataInfo += "type:"+responsePack.result;
            responseDataInfo += "index:"+responsePack.Index;
            System.Console.WriteLine(responseDataInfo);
            return true;
        }

    }
}