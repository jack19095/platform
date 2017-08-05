﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Models.SysModels
{
    public class SysLog : DbSetBaseId
    {
        public SysLog()
        {
            CreatedDateTime = DateTimeOffset.Now;
        }

        [DataType(DataType.MultilineText)]
        public string Log { get; set; }

        /// <summary>
        /// 创建日期时间
        /// </summary>
        [Index]
        [Required]
        public DateTimeOffset CreatedDateTime { get; set; }
    }
}