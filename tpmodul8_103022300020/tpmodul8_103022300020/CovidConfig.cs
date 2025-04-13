using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300020
{
    internal class CovidConfig
    {
        public string SatuanSuhu { get; set; } = "celcius";
        public int BatasHariDemam { get; set; } = 14;
        public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public void UbahSatuan()
        {
            SatuanSuhu = SatuanSuhu == "celcius" ? "fahrenheit" : "celcius";
        }

        public static CovidConfig LoadFromFile(string path)
        {
            if (!File.Exists(path))
                return new CovidConfig();

            string json = File.ReadAllText(path);
            var raw = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            var config = new CovidConfig();

            if (raw.ContainsKey("satuan_suhu") && raw["satuan_suhu"] != "CONFIG1")
                config.SatuanSuhu = raw["satuan_suhu"];
            if (raw.ContainsKey("batas_hari_demam") && raw["batas_hari_demam"] != "CONFIG2")
                config.BatasHariDemam = int.Parse(raw["batas_hari_demam"]);
            if (raw.ContainsKey("pesan_ditolak") && raw["pesan_ditolak"] != "CONFIG3")
                config.PesanDitolak = raw["pesan_ditolak"];
            if (raw.ContainsKey("pesan_diterima") && raw["pesan_diterima"] != "CONFIG4")
                config.PesanDiterima = raw["pesan_diterima"];

            return config;
        }
    }
}
