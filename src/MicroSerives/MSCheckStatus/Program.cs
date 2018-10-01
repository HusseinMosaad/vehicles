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
namespace MSCheckStatus
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

            while (true)
            {
                try
                {

                    var msg = GetMessageFromQueue();
                    if (!string.IsNullOrEmpty(msg))
                    {

                        //get the Vehicle list
                        WebClient wc = new WebClient();
                        var json = wc.DownloadString(apibaseurl + "api/VehicleData/VehiclesById?Vehicle_Id="+ msg);
                        var Vehicle = Newtonsoft.Json.JsonConvert.DeserializeObject<Vehicle>(json);
                        //if status active and last update is more then 60 sec ( 1min) update status and notify browser Vehicle is inactive
                        if (Vehicle.Status && (DateTime.Now - Vehicle.Last_Updated).TotalSeconds > 60) {

                            UpdateStatus(Vehicle.Vehicle_Id, false);

                        }
                        

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(1000);//0.5 sec sleep for check status 

            }
        }

   
        public static string GetMessageFromQueue()
        {
            string apibaseurl = AppSetting.Get("ApiUrl");
            WebClient wc = new WebClient();
            var Vehicle_Id = wc.DownloadString(apibaseurl + "api/Queue/GetQueue");
            return Vehicle_Id;
        }

        public static void UpdateStatus(int Vehicle_Id, bool status)
        {
            string apibaseurl = AppSetting.Get("ApiUrl");
            WebClient wc = new WebClient();
            string response = wc.DownloadString(apibaseurl + "api/VehicleData/VehicleStatusUpdate?Vehicle_Id=" + Vehicle_Id + "&Status=" + status);
        }
    
    }
}
