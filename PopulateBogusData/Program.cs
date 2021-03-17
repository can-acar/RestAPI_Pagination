using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateBogusData
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerData obj = new CustomerData();
            obj.Populate();
        }
    }
}
