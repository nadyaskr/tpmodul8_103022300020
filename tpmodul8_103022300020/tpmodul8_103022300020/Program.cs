using System;
using tpmodul8_103022300020;

class Program
{
    static void Main()
    {
        CovidConfig config = CovidConfig.LoadFromFile("covid_config.json");

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}");
        double suhu = double.Parse(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDemam = int.Parse(Console.ReadLine());

        bool suhuOK = false;

        if (config.SatuanSuhu == "celcius")
            suhuOK = suhu >= 36.5 && suhu <= 37.5;
        else
            suhuOK = suhu >= 97.7 && suhu <= 99.5;

        if (suhuOK && hariDemam < config.BatasHariDemam)
            Console.WriteLine(config.PesanDiterima);
        else
            Console.WriteLine(config.PesanDitolak);
    }
}