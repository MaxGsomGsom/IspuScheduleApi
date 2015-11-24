﻿using System.Net.Http.Headers;
using System.Web.Http;

namespace IspuScheduleApi2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "{controller}/{id}", new {id = RouteParameter.Optional}
                );

            // Раскомментируйте следующую строку кода, чтобы включить поддержку запросов для действий с типом возвращаемого значения IQueryable или IQueryable<T>.
            // Чтобы избежать обработки неожиданных или вредоносных запросов, используйте параметры проверки в QueryableAttribute, чтобы проверять входящие запросы.
            // Дополнительные сведения см. по адресу http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // Чтобы отключить трассировку в приложении, закомментируйте или удалите следующую строку кода
            // Дополнительные сведения см. по адресу: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}