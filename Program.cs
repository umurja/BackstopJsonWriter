using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BackstopJsonWriter
{
    class Program
    {

        static void Main(string[] args)
        {

            foreach (string s in args)
            {
                Console.WriteLine("arg = " + s);
            }
            String line;
            String jsonScenario;

            /* todo: fix all this for better output
            if (File.Exists(args[0])) 
            {
                Console.WriteLine("file exists!!!, continuing..." + fullFilePath);
            }
            else
            {
                Console.WriteLine("file not found, exiting..." + fullFilePath);
                return;
            }
                

            if (args[2] == null)
            {
                Console.WriteLine("arg[2] is null, creating full json");
            }
            else
            {
                Console.WriteLine("arg[2] is present, creating minimal json");
            }
            */

            //using (var writer = new StreamWriter(@"C:\Users\JaMu\source\repos\BackstopJsonWriter\scenarios.json"))
            //Console.WriteLine("writing to... = " + filePath + "\\scenarios.json");
            using (var writer = new StreamWriter(args[1] + "scenarios.json"))
            {
                System.IO.StreamReader file =
                    new System.IO.StreamReader(args[0]);
                //new System.IO.StreamReader(@"C:\Users\JaMu\source\repos\BackstopJsonWriter\urls.csv");
                //Use a csv where col1=scenario label, col2=url, col3=reference url
                //int preCount = File.ReadAllLines(@"C:\Users\JaMu\source\repos\BackstopJsonWriter\urls.csv").Count();
                int preCount = File.ReadAllLines(args[0]).Count();
                int count = 0;
                string sep = ",";
                while ((line = file.ReadLine()) != null)
                {
                    var label = line.Split(sep.ToCharArray())[0];
                    var url = line.Split(sep.ToCharArray())[1];
                    var refUrl = line.Split(sep.ToCharArray())[2];
                    count++; // 

                    if (args==null)
                        jsonScenario = $"{{\"label\":\"{label}\",\"cookiePath\":\"backstop_data/engine_scripts/cookies.json\",\"url\":\"{url}\",\"referenceUrl\":\"{refUrl}\",\"readyEvent\":\"\",\"readySelector\":\"\",\"delay\":5000,\"hideSelectors\":[],\"removeSelectors\":[],\"hoverSelector\":\"\",\"clickSelector\":\"\",\"postInteractionWait\":0,\"selectors\":[],\"selectorExpansion\":true,\"expect\":0,\"misMatchThreshold\":0.9,\"requireSameDimensions\":true}}";
                    else
                        jsonScenario = $"{{\"label\":\"{label}\",\"cookiePath\":\"backstop_data/engine_scripts/cookies.json\",\"url\":\"{url}\",\"referenceUrl\":\"{refUrl}\",\"readyEvent\":\"\",\"readySelector\":\"\",\"delay\":5000,\"hoverSelector\":\"\",\"clickSelector\":\"\",\"postInteractionWait\":0,\"selectorExpansion\":true,\"expect\":0,\"misMatchThreshold\":2.0,\"requireSameDimensions\":true}}";
                    if (count == preCount)
                        writer.WriteLine(jsonScenario);
                    else
                        writer.WriteLine(jsonScenario + ",");

                    jsonScenario = "";
                }
                file.Close();
            }
        }
        private static string getLabel(string rawLine)
        {
            var lineArray = rawLine.Split('/');
            int lCount = lineArray.Length;
            var retval = lineArray.Last();
            return retval;
        }
    }
}
