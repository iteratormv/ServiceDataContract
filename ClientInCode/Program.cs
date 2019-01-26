using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientInCode
{
    [DataContract(Namespace = "http://itstep.org")]
    class Product
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Category { set; get; }
    }
    [ServiceContract]
    interface IProductContract
    {
        [OperationContract]
        IEnumerable<Product> GetAll();
        [OperationContract]
        Product Get(int id);
        [OperationContract]
        void Remove(int id);
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IProductContract> myTcpClient = 
                new ChannelFactory<IProductContract>(new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:3121/Product"));
            IProductContract contract =  myTcpClient.CreateChannel();
            var collection = contract.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("-------------------------------");
            ChannelFactory<IProductContract> myPipeClient =
               new ChannelFactory<IProductContract>(new NetNamedPipeBinding(),
               new EndpointAddress("net.pipe://localhost/Product"));
            IProductContract contractPipe = myTcpClient.CreateChannel();
            var collection1 = contractPipe.GetAll();
            foreach (var item in collection1)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
