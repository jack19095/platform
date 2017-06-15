﻿using System.Data.Entity;
using IServices.ISysServices;
using Models.SysModels;
using Services.Infrastructure;

namespace Services.SysServices
{
    public class SysLogService : RepositoryBase<SysLog>, ISysLogService
    {
        public SysLogService(DbContext databaseFactory, IUserInfo userInfo)
               : base(databaseFactory, userInfo)
        {

        }




    }
}