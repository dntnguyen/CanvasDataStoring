﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemoNetFramework
{
    public class ResponseResult
    {
        public ResponseResultCode ResultCode { get; set; }
        public string ResultDescription { get; set; }
        public object ResultValue { get; set; }
    }

    public class ResponseResult<T>
    {
        public ResponseResultCode ResultCode { get; set; }
        public string ResultDescription { get; set; }
        public T ResultValue { get; set; }
        public object MoreInfo { get; set; }
    }
}
