using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Util
{

    public static class AppSetting
    {

        static Dictionary<string, IConfiguration> Configurations = new Dictionary<string, IConfiguration>();
        public static bool IsInit = false;
        public static bool IsInitFromFile = false;

        /// <summary>
        ///  Get Key from appsettings.json
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ConfKey"></param>
        /// <returns></returns>
        public static string Get(string key, string ConfKey = "")
        {
            var result = Configurations[ConfKey][key];
            if (result == null)
            {
                result = Configurations[ConfKey]["AppSettings:" + key];
            }
            return result;
        }
        /// <summary>
        /// init
        /// </summary>
        static IConfiguration iconfiguration;
        public static void init(IConfiguration piconfiguration, string ConfKey = "")
        {
            iconfiguration = piconfiguration;
            if (!Configurations.ContainsKey(ConfKey))
            {
                Configurations.Add(ConfKey, iconfiguration);
            }
            IsInit = true;
        }

        public static void init(string basepath, string settingFile, string ConfKey = "")
        {
            var builder = new ConfigurationBuilder()
.SetBasePath(basepath)
                .AddJsonFile(settingFile);
            if (Configurations.ContainsKey(ConfKey))
            {
                Configurations.Remove(ConfKey);
            }

            if (!Configurations.ContainsKey(ConfKey))
            {
                Configurations.Add(ConfKey, builder.Build());
            }
            IsInitFromFile = true;
            IsInit = true;
        }


    }

}
