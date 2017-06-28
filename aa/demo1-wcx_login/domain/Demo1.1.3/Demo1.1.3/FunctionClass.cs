using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;

namespace Demo1._1._3
{
    class FunctionClass
    {
        //********************
        //客户端发送数据（新建）
        //********************
        public void saveData<T>(T t)
        {
            string json;
            json = JsonConvert.SerializeObject(t);
            using (var ws = new WebSocket("ws://localhost:9000/SaveData"))
            {
                ws.Connect();
                ws.Send(json);
                ws.Close();
            }
        }

        //********************
        //客户端发送数据（更新）
        //********************
        public void updateData<T>(T t)
        {
            string json;
            json = JsonConvert.SerializeObject(t);

            using (var ws = new WebSocket("ws://localhost:9000/UpdateData"))
            {
                ws.Connect();
                ws.Send(json);
                ws.Close();
            }

        }
    }
}
