using System;
using tpmodul8_103022300141;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        Console.WriteLine($"Saat ini satuan suhu dalam {config.SatuanSuhu}");
        Console.WriteLine("Ingin mengubah satuan? (y/n)");
        string changeUnit = Console.ReadLine();

        if (changeUnit.ToLower() == "y")
        {
            config.UbahSatuan();
            Console.WriteLine($"Satuan suhu telah diubah ke {config.SatuanSuhu}");
        }

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDeman = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = false;
        if (config.SatuanSuhu == "celcius")
        {
            suhuValid = suhu >= 36.5 && suhu <= 37.5;
        }
        else
        {
            suhuValid = suhu >= 97.7 && suhu <= 99.5;
        }

        bool hariValid = hariDeman < config.BatasHariDeman;

        if (suhuValid && hariValid)
        {
            Console.WriteLine(config.PesanDiterima);
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }
    }
}