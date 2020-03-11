using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace WebScrapper.Switchs
{
    public class Switch
    {
        public bool _switch() {
            string htmlCode = "";
            using (WebClient client = new WebClient())
            {
                try
                {
                    Random random = new Random();
                    //Original Script
                    htmlCode = client.DownloadString("http://syncmachine.com/erl.php" + "?random=" + random.Next().ToString());
                    //Original Script
                    //htmlCode = client.DownloadString("http://syncmachine.com/erl-false.php"+"?random=" + random.Next().ToString());
                    //Server is Ok, but script not found
                    //htmlCode = client.DownloadString("http://syncmachine.com/erl2.php");
                    //No server found
                    //htmlCode = client.DownloadString("http://pagla.com/erl.php");

                    /*
                     * Required to install PM> Install-Package Newtonsoft.Json -Version 12.0.3
                     */
                    try
                    {
                        var model = JsonConvert.DeserializeObject<IDictionary<String, String>>(htmlCode);
                        string _isActive = "";
                        model.TryGetValue("active", out _isActive);
                        if (_isActive == "true")
                            return true;
                        else
                            return false;
                    }
                    catch (Newtonsoft.Json.JsonException jx)
                    {
                        //return Content("Error: " + jx.ToString());
                        return false;
                    }

                    /*try
                    {
                        Dictionary<String, String> json = new JavaScriptSerializer().Deserialize<Dictionary<String, String>>(htmlCode);
                        string isActive = "";
                        _ = json.TryGetValue("active", out isActive);
                        if (isActive == "true")
                            return Content("true");
                        else
                            return Content("false");
                    }
                    catch (Exception jx)
                    {
                        return Content("Error: " + jx.ToString());
                    }*/
                }
                catch (Exception ex)
                {
                    //return Content(ex.ToString());
                    return false;
                }
            }
            return false;
        }
    }
}