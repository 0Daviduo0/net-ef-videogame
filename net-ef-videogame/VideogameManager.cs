using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace net_ef_videogame
{
    internal class VideogameManager
    {
        public static void InsertVideogame()
        {
            using VideogameContext db = new VideogameContext();

            string name;
            string overview;
            DateTime release_date;
            long software_house_id;
            string input;


            do
            {
                Console.Write("Inserisci il nome: ");
                name = Console.ReadLine();

            } while (string.IsNullOrEmpty(name));

            do
            {
                Console.Write("Inserisci la descrizione: ");
                overview = Console.ReadLine();

            } while (string.IsNullOrEmpty(overview));

            do
            {
                Console.Write("Inserisci la data di uscita (yyyy-MM-dd): ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out release_date));

            var SoftwareHouse = db.SoftwareHouse.ToList();

            foreach (var aviable in SoftwareHouse)
            {
                Console.WriteLine($"{aviable.Id} - {aviable.Name}");
            }


            do
            {
                Console.Write("Inserisci l'ID della SoftwareHouse: ");
                input = Console.ReadLine();
            } while (!long.TryParse(input, out software_house_id));

            var videogame = new Videogame
            {
                Name = name,
                Overview = overview,
                Release_date = release_date,
                Software_house_id = software_house_id
            };

            db.Videogames.Add(videogame);
            db.SaveChanges();
        }

        public static void GetVideogameById()
        {
            using (var context = new VideogameContext())
            {
                try
                {
                    long id;

                    do
                    {
                        Console.Write("Inserisci l'ID del videogioco: ");
                    } while (!long.TryParse(Console.ReadLine(), out id));

                    var videogame = context.Videogames.Find(id);

                    if (videogame != null)
                    {
                        Console.WriteLine($"Nome: {videogame.Name}");
                        Console.WriteLine($"Descrizione: {videogame.Overview}");
                        Console.WriteLine($"Data di uscita: {videogame.Release_date}");
                        Console.WriteLine($"ID SoftwareHouse: {videogame.Software_house_id}");
                    }
                    else
                    {
                        Console.WriteLine("Videogioco non trovato!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void GetVideogamesName()
        {
            using (var context = new VideogameContext())
            {
                try
                {
                    string input;

                    do
                    {
                        Console.Write("Cerca il nome (o parte del nome) del videogioco che stai cercando: ");
                        input = Console.ReadLine();
                    } while (string.IsNullOrEmpty(input));

                    var videogames = context.Videogames
                        .Where(v => v.Name.Contains(input))
                        .ToList();

                    foreach (var videogame in videogames)
                    {
                        Console.WriteLine(videogame.Name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DeleteGame()
        {
            using (var context = new VideogameContext())
            {
                try
                {
                    long id;

                    do
                    {
                        Console.Write("Scrivi l'ID del videogioco da eliminare: ");
                    } while (!long.TryParse(Console.ReadLine(), out id));

                    var videogameToDelete = context.Videogames.Find(id);

                    if (videogameToDelete != null)
                    {
                        context.Videogames.Remove(videogameToDelete);
                        context.SaveChanges();
                        Console.WriteLine("Videogioco trovato e cancellato");
                    }
                    else
                    {
                        Console.WriteLine("C'è stato un problema nell'eliminazione del gioco");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void CreateSoftwareHouse()
        {
            using (VideogameContext db = new VideogameContext())
            {
                string nome;
                string codiceFiscale;
                string citta;
                string paese;
                string input;

                do
                {
                    Console.Write("Inserisci il nome della software house: ");
                    nome = Console.ReadLine();
                } while (string.IsNullOrEmpty(nome));

                do
                {
                    Console.Write("Inserisci il tax ID della software house: ");
                    codiceFiscale = Console.ReadLine();
                } while (string.IsNullOrEmpty(codiceFiscale));

                do
                {
                    Console.Write("Inserisci la città della software house: ");
                    citta = Console.ReadLine();
                } while (string.IsNullOrEmpty(citta));

                do
                {
                    Console.Write("Inserisci il paese della software house: ");
                    paese = Console.ReadLine();
                } while (string.IsNullOrEmpty(paese));

                SoftwareHouse softwareHouse = new SoftwareHouse
                {
                    Name = nome,
                    Tax_id = codiceFiscale,
                    City = citta,
                    Country = paese
                };

                db.SoftwareHouse.Add(softwareHouse);
                db.SaveChanges();

                Console.WriteLine("Software house creata con successo!");
            }
        }


    }

    internal class VideoGame
    {
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long SoftwareHouseId { get; set; }
    }
}

