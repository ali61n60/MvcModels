﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MvcModels.Models
{
    
    public class AddressSummary
    {
        public string City { get; set; }

        //[BindNever]
        public string Country { get; set; }
    }
}
