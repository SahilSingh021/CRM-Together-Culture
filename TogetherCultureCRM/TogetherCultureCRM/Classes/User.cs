﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM
{
    internal static class User
    {
        public static Guid userId { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
        public static string email { get; set; }
        public static bool bIsAdmin { get; set; }
    }
}
