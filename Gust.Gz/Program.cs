﻿using System;
using System.IO;
using Cethleann.Gust;
using DragonLib.IO;

namespace Gust.Gz
{
    static class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Logger.Info("GUST", arg);
                var data = new Span<byte>(File.ReadAllBytes(arg));
                if (arg.EndsWith(".gz"))
                    File.WriteAllBytes(arg.Substring(0, arg.Length - 3), Compression.Decompress(data).ToArray());
                else
                    File.WriteAllBytes(arg + ".gz", Compression.Compress(data).ToArray());
            }
        }
    }
}