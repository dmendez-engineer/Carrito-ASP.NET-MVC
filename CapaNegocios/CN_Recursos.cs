﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Recursos
    {
        public static string ConvertirSHA256(string text)
        {
            StringBuilder sb = new StringBuilder();

            using(SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(text));

                foreach(byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    
    }
}
