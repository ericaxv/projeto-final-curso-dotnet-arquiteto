﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Infra.Data.Helpers
{
    public class MD5Helper
    {

        public static string Encrypt(string value)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

                var result = string.Empty;
                foreach (var item in hash)
                    result += item.ToString("X2"); //X2 -> hexadecimal

                return result;
            }
        }
    }
}
