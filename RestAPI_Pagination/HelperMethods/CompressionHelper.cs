using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RestAPI_Pagination.HelperMethods
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CompressionHelper'
    public class CompressionHelper
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CompressionHelper'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CompressionHelper.DeflateByte(byte[])'
        public static byte[] DeflateByte(byte[] str)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CompressionHelper.DeflateByte(byte[])'
        {
            if (str == null)
            {
                return null;
            }

            using (var output = new MemoryStream())
            {
                using (
                    var compressor = new Ionic.Zlib.DeflateStream(
                    output, Ionic.Zlib.CompressionMode.Compress,
                    Ionic.Zlib.CompressionLevel.BestSpeed))
                {
                    compressor.Write(str, 0, str.Length);
                }

                return output.ToArray();
            }
        }
    }
}