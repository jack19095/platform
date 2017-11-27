﻿using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Web.Optimization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Web.Helpers;

namespace Web
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        private System.Threading.Timer _objTimer;
        private static readonly object Locko = new object();

        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {

            //SqlDependency.Start(ApplicationDbContext.Create().Database.Connection.ConnectionString);

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // webapi
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // mvc
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper.Run();

            // Replace cache provider with Memcached provider
            //Locator.Current.Register<ICacheProvider>(() => new MemcachedProvider());
            //Locator.Current.Register<ICacheProvider>(() => new MemoryCacheProvider());

            // 计划任务 按照间隔时间执行

            var onTimedEvent = DependencyResolver.Current.GetService<IOnTimedEvent>();

            if (!int.TryParse(ConfigurationManager.AppSettings["TaskInterval"], out int taskInterval))
            {
                taskInterval = 60; //秒
            }

            _objTimer = new System.Threading.Timer(onTimedEvent.Run, Locko, new TimeSpan(0, 0, 0, taskInterval), new TimeSpan(0, 0, 0, taskInterval));

        }

        /// <summary>
        /// 
        /// </summary>
        protected void Application_End()
        {
            //SqlDependency.Stop(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _objTimer.Dispose();
        }

        /// <summary>
        /// 按照用户Id更新缓存信息，不同用户Id分别缓存 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        public override string GetVaryByCustomString(HttpContext context, string arg)
        {
            if (arg.ToLower() == "userid")
            {
                var userid = "wjw1";

                if (context.User.Identity.IsAuthenticated)
                {
                    userid = context.User.Identity.GetUserId();
                }

                context.Trace.Write("缓存过滤器拦截", userid);

                return userid;
            }
            return base.GetVaryByCustomString(context, arg);
        }
    }
}
