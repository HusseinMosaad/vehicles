using Application.Model;
using Application.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage;

namespace MSLoadData
{
    class Program
    {
        public static string basepath = "";
        public static CloudStorageAccount storageAccount = null;

        public static string ApiUrl
        {
            get
            {
                if (Environment.GetEnvironmentVariable("ApiUrl") != null)
                {
                    return Environment.GetEnvironmentVariable("ApiUrl");
                }
                else
                {
                    return AppSetting.Get("ApiUrl");
                }
            }
        }


        static void Main(string[] args)
        {
            Console.Write("started" + DateTime.Now);
            basepath = new FileInfo(Assembly.GetEntryAssembly().Location).Directory.FullName;
            string appsetting = Path.Combine(basepath, "appsettings.json");
            AppSetting.init(basepath, appsetting);
            string apibaseurl = ApiUrl;
            Console.Write("apibaseurl" + apibaseurl);
            while (true)
            {
                try
                {
                    //check current queue size, if queue is full then wait untill some message not processed
                    if (GetQueueCount() > 100)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    //get the Vehicle list
                    WebClient wc = new WebClient();
                    var json = wc.DownloadString(apibaseurl + "api/VehicleData/Vehicles?Customer_Id=null&Status=null");
                    var Vehicles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Vehicle>>(json).Where(x=>x.Status==true).OrderBy(x => x.Last_Updated).ToList();
                    foreach (var item in Vehicles)
                    {
                        //queue the Vehicle for satus update and send signal to browser to for update status
                        AddInQueueCount(item.Vehicle_Id.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(1000);//2 sec sleep for check status 

            }

        }

        public static int GetQueueCount() {

            string apibaseurl = AppSetting.Get("ApiUrl");

            WebClient wc = new WebClient();
            var countstr = wc.DownloadString(apibaseurl + "api/Queue/GetQueueCount");

            int cnt = Convert.ToInt32(countstr);
            return cnt;

        }

        public static void AddInQueueCount(string Vehicle_Id)
        {

            string apibaseurl = AppSetting.Get("ApiUrl");
            WebClient wc = new WebClient();
            var countstr = wc.DownloadString(apibaseurl + "api/Queue/AddQueue?Vehicle_Id="+ Vehicle_Id);

          
         

        }

    }
}
