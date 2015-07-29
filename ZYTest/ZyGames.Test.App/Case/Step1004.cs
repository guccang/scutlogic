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
using ZyGames.Framework.Common.Configuration;

namespace ZyGames.Quanmin.Test.Case
{
    /// <summary>
    /// 登录
    /// </summary>
    public class Step1004 : CaseStep
    {
        Response1004Pack responsePack = null;
        Request1004Pack req;
        protected override void SetUrlElement()
        {
            req = new Request1004Pack();
            req.UserID = 111;
            req.identify = "123211";
            req.version = "1.09";
            req.status = 0;
            req.actionID = 0;
            if (isUseConfigData())
            {
                req.UserID = GetParamsData("UserID", req.UserID);
                req.identify = GetParamsData("identify", req.identify);
                req.version = GetParamsData("version", req.version);
                req.status = GetParamsData("status", req.status);
                req.actionID = (byte)GetParamsData("actionID", (int)req.actionID);
            }
            byte[] data = ProtoBufUtils.Serialize(req);
            netWriter.SetBodyData(data);
        }

        protected override bool DecodePacket(MessageStructure reader, MessageHead head)
        {
            responsePack = ProtoBufUtils.Deserialize<Response1004Pack>(netReader.Buffer);
            string responseDataInfo = "";
            responseDataInfo = "request :" + Game.NSNS.JsonHelper.prettyJson<Request1004Pack>(req) + "\n";
            responseDataInfo += "response:" + Game.NSNS.JsonHelper.prettyJson<Response1004Pack>(responsePack) + "\n";
            DecodePacketInfo = responseDataInfo;
            return true;
        }

    }
}