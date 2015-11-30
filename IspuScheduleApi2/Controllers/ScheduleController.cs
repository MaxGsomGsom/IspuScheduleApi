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


                //генерируем разделитель
                byte[] boundaryBytes = new byte[10];
                (new Random()).NextBytes(boundaryBytes);
                string boundary = "--"+BitConverter.ToString(boundaryBytes);

                //тело запроса
                string postData = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"token\"\r\n\r\n" + ConfigurationManager.AppSettings["token"].ToString()+"\r\n";
                postData += "--" + boundary + "\r\nContent-Disposition: form-data; name=\"type\"\r\n\r\njson\r\n";
                postData += "--" + boundary + "\r\nContent-Disposition: form-data; name=\"report\"\r\n\r\n" + ConfigurationManager.AppSettings["email"].ToString() + "\r\n";
                postData += "--" + boundary + "\r\nContent-Disposition: form-data; name=\"datafile\"; filename=\"ispu_schedule.json\"\r\nContent-Type: text/json\r\n\r\n" + JsonConvert.SerializeObject(UIScheduleFactory.Init()) + "\r\n";
                postData += "--" + boundary + "--\r\n";

                byte[] postBytes = GetBytes(postData);

                //заголовки запроса
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://api.rvuzov.ru/v2/import/file");
                req.ContentType = "multipart/form-data; boundary=" + boundary;
                req.Method = "POST";


                //записываем тело в запрос
                Stream postStream = req.GetRequestStream();
                postStream.Write(postBytes, 0, postBytes.Length);
                postStream.Flush();
                postStream.Close();


                //получаем ответ, при ошибке выводим текст исключения, при успехе - текст ответа
                try
                {
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    string result = (new StreamReader(res.GetResponseStream())).ReadToEnd();

                    if (res != null)
                        return result;
                }
                catch (Exception e)
                {
                    return e.Message;
                }

                return "Error";
            }
            return "Wrong password";
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