﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Datas
{
    public interface IHasModificationTime
    {
        public DateTime? LastModificationTime { get; set; }
    }
}
