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
    public class Step2000 : CaseStep
    {
        public ResponsePack responsePack = null;
        private string name = "";
        private string pwd  = "";
        protected override void SetUrlElement()
        {
            readAuthory();
            Request2000Pack req = new Request2000Pack();
            req.theActionType = Request2000Pack.E_ACTION_TYPE.E_ACTION_TYPE_ADD;
            req.param         = ConfigUtils.GetSetting("Test.Params2000", "");
            req.name = name;
            req.pwd = ZyGames.Framework.Common.Security.CryptoHelper.MD5_Encrypt(pwd);
            byte[] data = ProtoBufUtils.Serialize(req);
            netWriter.SetBodyData(data);
        }

        protected override bool DecodePacket(MessageStructure reader, MessageHead head)
        {
            responsePack = ProtoBufUtils.Deserialize<ResponsePack>(netReader.Buffer);
            string responseDataInfo = "";
            responseDataInfo = indentify + " acction success: " + responsePack.ActionId + ":" + responsePack.ErrorInfo;
            System.Console.WriteLine(responseDataInfo);
            return true;
        }
        void createAuthory()
        {
          
        }
        void readAuthory()
        {
            try
            {
                System.IO.StreamReader stream = new System.IO.StreamReader(".//authory.txt");
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    // TODO
                    string[] words = line.Split(',');
                    name = words[0];
                    pwd = words[1];
                }
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine("Step2000:"+e.Message);
            }
         
            System.Console.WriteLine("name:"+name+"\npwd:"+pwd);
        }
    }
}