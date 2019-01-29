using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampoSkaiciavimas
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            { 
                try
                {
                    Console.WriteLine("Iveskite valandas ir minutes (naudokite formata vv:mm):");
                    var ivedimas = Console.ReadLine();
                    string[] valandosMinutes = ivedimas.Split(':');
                    var valandos = Convert.ToInt32(valandosMinutes[0]);
                    var minutes = Convert.ToInt32(valandosMinutes[1]);

                    if (valandos >= 24 || minutes >= 60)
                    {
                        Console.WriteLine("Neteisingai ivedete laika. Valandu ir minuxiu reiksmes negali buti didesnes nei 23:59");
                        Console.WriteLine("Iveskite valandas ir minutes (naudokite formata vv:mm):");
                        ivedimas = Console.ReadLine();
                        valandosMinutes = ivedimas.Split(':');
                        valandos = Convert.ToInt32(valandosMinutes[0]);
                        minutes = Convert.ToInt32(valandosMinutes[1]);
                    }

                    KampoSkaiciavimas kampas = new KampoSkaiciavimas();
                    kampas.IsvestiAtsakyma(valandos, minutes);
                    Console.WriteLine("Spauskite ENTER noredami skaiciuoti kampa");
                    Console.ReadLine();
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Iveskite laika teisingu formatu!");
                }
            }
        }

        class KampoSkaiciavimas
        {
            public int Valandos { get; set; }
            public int Minutes { get; set; }
            /// <summary>
            /// Parodo kiek minute turi laipsniu
            /// </summary>
            public const int minutesLaipsnis = 6;
            /// <summary>
            /// Parodo kiek valanda turi minuciu
            /// </summary>
            public const int valandosMinutes = 5;
            /// <summary>
            /// Skaicius reiskiantis pilno apskritimo laipsnius
            /// </summary>
            public const int visiLaipsniai = 360;

            public KampoSkaiciavimas()
            {
               
            }

            public int SuskaiciuotiKampa(int valandos, int minutes)
            {
                var valanduPozicija = valandos * valandosMinutes * minutesLaipsnis;
                var minuciuPozicija = minutes * minutesLaipsnis;
                var suskaiciuotasKampas = valanduPozicija - minuciuPozicija;
                return suskaiciuotasKampas;
            }

            public int ParinktiMazajiKampa(int suskaiciuotasKampas)
            {
                int mazasisKampas = 0;
                if (suskaiciuotasKampas > 360)
                {
                    mazasisKampas = 2 * visiLaipsniai - suskaiciuotasKampas;
                }
                else if (suskaiciuotasKampas>180)
                {
                    mazasisKampas = visiLaipsniai - suskaiciuotasKampas;
                }
                else
                {
                    mazasisKampas = suskaiciuotasKampas;
                }
                if (mazasisKampas<0)
                {
                    mazasisKampas *= -1;
                }
                return mazasisKampas;
            }

            public void IsvestiAtsakyma(int valandos, int minutes)
            {
                Console.WriteLine("Suskaiciuotas kampas tarp rodykliu yra: " + ParinktiMazajiKampa(SuskaiciuotiKampa(valandos, minutes)));   
            }
        }
    }
}
