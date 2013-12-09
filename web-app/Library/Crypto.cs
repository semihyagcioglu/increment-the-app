using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace increment_the_app.Library
{
    public class Crypto
    {


     
        static public string MD5Encode(string data)
        {
            byte[] b = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(data);
            string encoded = System.Convert.ToBase64String(b);
            return encoded;
        }

        static public string MD5Decode(string encoded)
        {
            encoded = encoded.Replace(' ', '+');
            byte[] b = System.Convert.FromBase64String(encoded);
            string data = System.Text.Encoding.GetEncoding("ISO-8859-9").GetString(b);
            return data;
        }
       
    }
}

