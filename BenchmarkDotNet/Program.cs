using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Common.Enum;
using Common.Interface;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNet
{
    class Program
    {
        


        //public static void Main(string[] args)
        //{
        //    var summary = BenchmarkRunner.Run<CustomerPaginationBM>();

        //}

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CustomerPaginationBM>();
        }
           //=> BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

    }
}
