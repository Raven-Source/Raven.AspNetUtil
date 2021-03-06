﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNet.WebApiExtensions
{
    /// <summary>
    /// 
    /// </summary>
    internal static class CompressionHelper
    {
        public static async Task<byte[]> CompressionByteAsync(byte[] str, CompressionType compressionType)
        {
            if (str == null)
            {
                return null;
            }

            using (var output = new MemoryStream())
            {
                switch (compressionType)
                {
                    case CompressionType.Deflate:
                        using (
                            var compressor = new Ionic.Zlib.DeflateStream(
                            output, Ionic.Zlib.CompressionMode.Compress,
                            Ionic.Zlib.CompressionLevel.BestSpeed))
                        {
                            await compressor.WriteAsync(str, 0, str.Length);
                            //compressor.Write(str, 0, str.Length);
                        }
                        break;
                    case CompressionType.GZip:
                        using (
                            var compressor = new Ionic.Zlib.GZipStream(
                            output, Ionic.Zlib.CompressionMode.Compress,
                            Ionic.Zlib.CompressionLevel.BestSpeed))
                        {
                            await compressor.WriteAsync(str, 0, str.Length);
                            //compressor.Write(str, 0, str.Length);
                        }
                        break;
                    case CompressionType.Zlib:
                        using (
                            var compressor = new Ionic.Zlib.ZlibStream(
                            output, Ionic.Zlib.CompressionMode.Compress,
                            Ionic.Zlib.CompressionLevel.BestSpeed))
                        {
                            await compressor.WriteAsync(str, 0, str.Length);
                            //compressor.Write(str, 0, str.Length);
                        }
                        break;
                }

                return output.ToArray();
            }
        }
    }

    /// <summary>
    /// Compression Type
    /// deflate,gzip,zlib
    /// </summary>
    public enum CompressionType : int
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// Deflate
        /// </summary>
        Deflate = 1,
        /// <summary>
        /// GZip
        /// </summary>
        GZip = 2,
        /// <summary>
        /// Zlib
        /// </summary>
        Zlib = 3
    }

}
