﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersentation(this IServiceCollection service)
        {
            return service;
        }
    }
}
