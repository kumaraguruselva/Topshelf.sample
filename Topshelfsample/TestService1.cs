using System;
using System.Timers;
using System.IO;

namespace Topshelfsample
{
    class TestService1
    {
        private readonly System.Timers.Timer _timer;

        public TestService1()
        {
            _timer = new System.Timers.Timer(2000) { AutoReset = true };
            _timer.Elapsed += ExecuteService;
        }
        private void ExecuteService(object sender, ElapsedEventArgs ev)
        {
            string[] files = System.IO.Directory.GetFiles(@"in");
            foreach (string filepath in files)
            {
                string filename = Path.GetFileName(filepath);
                System.IO.File.Copy(@"in/" + filename, @"out/" + filename);
                System.IO.File.Delete(@"in/" + filename);
            }
            try
            {
                _timer.Stop();
            }
            catch(Exception e) {
                Console.WriteLine("something went rong:" +e.Message);
            }
            finally { _timer.Start(); }
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
