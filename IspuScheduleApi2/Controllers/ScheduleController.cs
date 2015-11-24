using System.Web.Http;
using Core;
using IspuScheduleApi2.Factories;
using IspuScheduleApi2.Models;
using System.Configuration;
using System.Web;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System;

namespace IspuScheduleApi2.Controllers
{
    public class ScheduleController : ApiController
    {

        /// <summary>
        /// Отправка всего расписания на сервер
        /// </summary>
        /// <returns></returns>
        public string get_schedule(string password)
        {
            string truePass = ConfigurationManager.AppSettings["password"].ToString();
            if (truePass == password)
            {
                string postData = "format=json";
                postData += "&token=" + ConfigurationManager.AppSettings["token"].ToString();
                postData += "&report=" + ConfigurationManager.AppSettings["email"].ToString();
                postData += "&data=" + JsonConvert.SerializeObject(UIScheduleFactory.Init());

                byte[] postBytes = GetBytes(postData);

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://api.rvuzov.ru/2/import");
                req.ContentType = "application/x-www-form-urlencoded";
                req.Method = "POST";


                Stream postStream = req.GetRequestStream();
                postStream.Write(postBytes, 0, postBytes.Length);
                postStream.Flush();
                postStream.Close();


                try
                {
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    //string s = (new StreamReader(res.GetResponseStream())).ReadToEnd();

                    if (res != null)
                        return "success";
                }
                catch (Exception e)
                {
                    return e.Message;
                }

                return "error";
            }
            return "wrong password";
        }


        
        /// <summary>
        /// Вывод расписания по запросу (для тестирования)
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public UISchedule get_schedule(int test)
        {
            if (test == 1)
            {
                return UIScheduleFactory.Init();
            }
            return new UISchedule();
        }



        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

    }
}