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
    /// 创角
    /// </summary>
    public class Step1007 : CaseStep
    {
        static public uint KeyInt2Uint(int id)
        {
            if (id < 0)
            {
                return (uint)((uint)int.MaxValue - id);
            }
            else
            {
                return (uint)id;
            }
        }
        static public int KeyUInt2Int(uint id)
        {
            if (id > int.MaxValue)
            {
                return -((int)(id - int.MaxValue));
            }
            else
            {
                return (int)id;
            }
        }
        Response1007Pack responsePack;
        protected override void SetUrlElement()
        {
            int id = -357016106;
            Request1007Pack requestPack = new Request1007Pack();
            requestPack.the3rdUserID = 5228;// KeyInt2Uint(id);
            requestPack.dateType = 1;
            byte[] data = ProtoBufUtils.Serialize(requestPack);
            System.Console.WriteLine(id+":"+requestPack.the3rdUserID + ":" + KeyUInt2Int(requestPack.the3rdUserID));
            netWriter.SetBodyData(data);
        }

        protected override bool DecodePacket(MessageStructure reader, MessageHead head)
        {
            responsePack = ProtoBufUtils.Deserialize<Response1007Pack>(netReader.Buffer);
           string responseDataInfo = "";
           responseDataInfo = indentify + " acction success: " + responsePack.errorCode;
           responseDataInfo += "\nenterNum:"+responsePack.enterNum;
           responseDataInfo += "\nhappyPoint:"+responsePack.happyPoint;
           responseDataInfo += "\n realdInfo:";
           foreach (var v in responsePack.realItemsIds)
           {
               responseDataInfo +=  v.id + " ";
           }
           System.Console.WriteLine(responseDataInfo);
            return true;
        }

    }
}