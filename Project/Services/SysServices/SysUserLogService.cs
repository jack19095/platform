﻿using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Common;
using IServices.ISysServices;
using Models.SysModels;
using Services.Infrastructure;

namespace Services.SysServices
{
    public class SysUserLogService : RepositoryBase<SysUserLog>, ISysUserLogService
    {
        public SysUserLogService(DbContext databaseFactory, IUserInfo userInfo)
            : base(databaseFactory, userInfo)
        {
        }
     
        public void DeleteExpiredData()
        {
            //只保留一定数量的日志,根据web.config中的设置值，默认单位：天。
            if (ConfigurationManager.AppSettings["LogValidity"] == null) return;

            var logValidity = Convert.ToDouble(ConfigurationManager.AppSettings["LogValidity"]);

            Delete(a => SqlFunctions.DateDiff("d", a.CreatedDate, DateTimeLocal.Now) > logValidity);
        }
    }

    
}