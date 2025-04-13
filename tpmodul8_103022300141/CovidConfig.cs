using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;
using System.Text.Json;

namespace tpmodul8_103022300141
{
    internal class CovidConfig
    {
        public string SatuanSuhu { get; set; }
        public int BatasHariDeman { get; set; }
        public string PesanDitolak { get; set; }
        public string PesanDiterima { get; set; }

        private const string ConfigFile = "covid_config.json";

        public CovidConfig()
        {
            SatuanSuhu = "celcius";
            BatasHariDeman = 14;
            PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

            LoadConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(ConfigFile))
            {
                try
                {
                    string json = File.ReadAllText(ConfigFile);
                    var config = JsonSerializer.Deserialize<CovidConfig>(json);

                    SatuanSuhu = config.SatuanSuhu;
                    BatasHariDeman = config.BatasHariDeman;
                    PesanDitolak = config.PesanDitolak;
                    PesanDiterima = config.PesanDiterima;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading config: {ex.Message}");
                }
            }
        }

        public void SaveConfig()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(ConfigFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving config: {ex.Message}");
            }
        }

        public void UbahSatuan()
        {
            SatuanSuhu = SatuanSuhu == "celcius" ? "fahrenheit" : "celcius";
            SaveConfig();
        }
    }
}
