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
            String line;
            String jsonScenario;
            using (var writer = new StreamWriter(@"C:\BackstopJSTests\Childfund\LargeRegress\lrurls.json"))
            {
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"C:\BackstopJSTests\Childfund\LargeRegress\LR-UrlList.csv");
                //Use a csv where col1=scenario label, col2=url, col3=reference url
                int count = 0;
                string sep = ",";
                while ((line = file.ReadLine()) != null)
                {
                    var label = line.Split(sep.ToCharArray())[0];
                    var url = line.Split(sep.ToCharArray())[1];
                    var refUrl = line.Split(sep.ToCharArray())[2];
                    count++; // 

                     jsonScenario = $"{{\"label\":\"{label}\",\"cookiePath\":\"backstop_data/engine_scripts/cookies.json\",\"url\":\"{url}\",\"referenceUrl\":\"{refUrl}\",\"readyEvent\":\"\",\"readySelector\":\"\",\"delay\":5000,\"hideSelectors\":[],\"removeSelectors\":[],\"hoverSelector\":\"\",\"clickSelector\":\"\",\"postInteractionWait\":0,\"selectors\":[],\"selectorExpansion\":true,\"expect\":0,\"misMatchThreshold\":0.9,\"requireSameDimensions\":true}},";
                    writer.WriteLine(jsonScenario);
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
