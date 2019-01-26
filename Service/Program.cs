using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(ProductContract),
               new Uri[] {
                            new Uri(@"net.tcp://localhost:3121/Product"),

                            new Uri(@"net.pipe://localhost/Product")
               });

            serviceHost.AddServiceEndpoint(typeof(IProductContract), new NetTcpBinding(),
                @"net.tcp://localhost:3121/Product");
            serviceHost.AddServiceEndpoint(typeof(IProductContract), new NetNamedPipeBinding(),
                @"net.pipe://localhost/Product");
            serviceHost.Open();
            Console.WriteLine("Service run........");
            Console.ReadKey();

            serviceHost.Close();
        }
    }
}
