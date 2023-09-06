// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using Topshelf;
using Topshelfsample;

namespace Testservice1
{
    class program
    {
        static void Main(string[] args)
        {
            try
            {
                var code = HostFactory.Run(x =>
                {
                    x.Service<TestService1>(s => {
                        s.ConstructUsing(Service => new TestService1());
                        s.WhenStarted(Service => Service.Start());
                        s.WhenStopped(Service => Service.Stop());
                    }); 
                    x.RunAsLocalSystem();
                    x.SetServiceName("TestService1");
                    x.SetDisplayName("TestService1");
                    x.SetDescription("this is an important service dont stop");

                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
