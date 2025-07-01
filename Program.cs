using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalnaKuharica
{
    class Recept
    {
        public string Naziv { get; set; }
        public string Kategorija { get; set; }
        public int VrijemePripreme { get; set; }
        public string Tezina { get; set; }
        public List<string> Sastojci { get; set; }

        public void Prikazi()
        {
            Console.WriteLine($"Naziv: {Naziv}");
            Console.WriteLine($"Kategorija: {Kategorija}");
            Console.WriteLine($"Vrijeme pripreme: {VrijemePripreme} minuta");
            Console.WriteLine($"Težina: {Tezina}");
            Console.WriteLine("Sastojci:");
            foreach (var s in Sastojci)
                Console.WriteLine($" - {s}");
            Console.WriteLine("------------------------------");
        }
    }

    class Program
    {
        static List<Recept> recepti = new List<Recept>();

        static void Main(string[] args)
        {
            int izbor;
            do
            {
                PrikaziMeni();
                Console.Write("Unesite izbor (0-5): ");
                if (!int.TryParse(Console.ReadLine(), out izbor))
                {
                    Console.WriteLine("Nevažeći unos!");
                    continue;
                }

                switch (izbor)
                {
                    case 1:
                        DodajRecept();
                        break;
                    case 2:
                        PrikaziRecepte();
                        break;
                    case 3:
                        ObrisiRecept();
                        break;
                    case 4:
                        PretraziRecepte();
                        break;
                    case 5:
                        PrikaziPoTezini();
                        break;
                    case 0:
                        Console.WriteLine("Izlaz iz programa...");
                        break;
                    default:
                        Console.WriteLine("Nepoznata opcija.");
                        break;
                }
            } while (izbor != 0);
        }

        static void PrikaziMeni()
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine("           DIGITALNA KUHARICA");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. Dodaj novi recept");
            Console.WriteLine("2. Prikaži sve recepte");
            Console.WriteLine("3. Obriši recept");
            Console.WriteLine("4. Pretraži po nazivu");
            Console.WriteLine("5. Prikaži recepte po težini");
            Console.WriteLine("0. Izlaz iz programa");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Ukupno recepata: {recepti.Count}");

            if (recepti.Any())
            {
                var najvise = recepti
                    .GroupBy(r => r.Kategorija)
                    .OrderByDescending(g => g.Count())
                    .First();

                Console.WriteLine($"Kategorija s najviše recepata: {najvise.Key} ({najvise.Count()})");
            }
            Console.WriteLine("---------------------------------------------");
        }

        static void DodajRecept()
        {
            Console.WriteLine("Unesite naziv jela:");
            string naziv = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(naziv))
            {
                Console.WriteLine("Naziv ne može biti prazan!");
                return;
            }

            Console.WriteLine("Unesite kategoriju (npr. Deserti, Glavno jelo):");
            string kategorija = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(kategorija))
            {
                Console.WriteLine("Kategorija ne može biti prazna!");
                return;
            }

            Console.WriteLine("Unesite vrijeme pripreme (u minutama):");
            if (!int.TryParse(Console.ReadLine(), out int vrijeme) || vrijeme <= 0)
            {
                Console.WriteLine("Vrijeme mora biti broj veći od nule!");
                return;
            }

            Console.WriteLine("Unesite težinu (Lako, Srednje, Teško):");
            string tezina = Console.ReadLine();
            if (!(tezina == "Lako" || tezina == "Srednje" || tezina == "Teško"))
            {
                Console.WriteLine("Nevažeća težina!");
                return;
            }

            Console.WriteLine("Unesite sastojke (odvojeni zarezima):");
            string[] sastojci = Console.ReadLine().Split(',');

            var noviRecept = new Recept
            {
                Naziv = naziv.Trim(),
                Kategorija = kategorija.Trim(),
                VrijemePripreme = vrijeme,
                Tezina = tezina,
                Sastojci = sastojci.Select(s => s.Trim()).ToList()
            };

            recepti.Add(noviRecept);
            Console.WriteLine("Recept dodan uspješno!");
            Console.WriteLine("Pritisnite dugme Enter da nastavite.");
            Console.ReadKey();
        }

        static void PrikaziRecepte()
        {
            Console.WriteLine("=== Lista recepata ===");
            if (!recepti.Any())
            {
                Console.WriteLine("Nema unesenih recepata.");
            }
            else
            {
                foreach (var r in recepti)
                    r.Prikazi();
            }
            Console.WriteLine("Pritisnite dugme Enter da nastavite.");
            Console.ReadKey();
        }

        static void ObrisiRecept()
        {
            Console.WriteLine("Unesite naziv recepta koji želite obrisati:");
            string naziv = Console.ReadLine();

            var r = recepti.FirstOrDefault(x => x.Naziv.Equals(naziv, StringComparison.OrdinalIgnoreCase));
            if (r != null)
            {
                recepti.Remove(r);
                Console.WriteLine("Recept obrisan.");
            }
            else
            {
                Console.WriteLine("Recept nije pronađen.");
            }
            Console.WriteLine("Pritisnite dugme Enter da nastavite.");
            Console.ReadKey();
        }

        static void PretraziRecepte()
        {
            Console.WriteLine("Unesite naziv za pretragu:");
            string naziv = Console.ReadLine();

            var filtrirani = recepti
                .Where(r => r.Naziv.IndexOf(naziv, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (filtrirani.Any())
            {
                foreach (var r in filtrirani)
                    r.Prikazi();
            }
            else
            {
                Console.WriteLine("Nema rezultata.");
            }
            Console.WriteLine("Pritisnite dugme Enter da nastavite.");
            Console.ReadKey();
        }

        static void PrikaziPoTezini()
        {
            Console.WriteLine("Unesite težinu (Lako, Srednje, Teško):");
            string tezina = Console.ReadLine();

            var filtrirani = recepti
                .Where(r => r.Tezina.Equals(tezina, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (filtrirani.Any())
            {
                foreach (var r in filtrirani)
                    r.Prikazi();
            }
            else
            {
                Console.WriteLine("Nema rezultata za tu težinu.");
            }
            Console.WriteLine("Pritisnite dugme Enter da nastavite.");
            Console.ReadKey();
        }
    }
}
