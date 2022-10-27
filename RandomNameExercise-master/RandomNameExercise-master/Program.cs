using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections;

namespace ConsoleApplication16
{
    class Program
    {
        //static Random value = new Random();
        static void Main(string[] args)
        {
            string temp = "";
            Random value = new Random();

            string filnavn = "";
            string[] dreng = File.ReadAllLines(@"C:\Users\Jonas\source\repos\RandomNamesExercices\RandomNamesExercices\data_files\drengenavne.dat", Encoding.Unicode);
            string[] pige = File.ReadAllLines(@"C:\Users\Jonas\source\repos\RandomNamesExercices\RandomNamesExercices\data_files\pigenavne.dat", Encoding.Unicode);
            string[] efternavn = File.ReadAllLines(@"C:\Users\Jonas\source\repos\RandomNamesExercices\RandomNamesExercices\data_files\efternavne.dat", Encoding.Unicode);
            string[] gadevej = File.ReadAllLines(@"C:\Users\Jonas\source\repos\RandomNamesExercices\RandomNamesExercices\data_files\vejnavne.dat", Encoding.Unicode);
            string[] postnrby = File.ReadAllLines(@"C:\Users\Jonas\source\repos\RandomNamesExercices\RandomNamesExercices\data_files\postby.dat", Encoding.Unicode);
            string[] mail = File.ReadAllLines(@"C:\Users\Jonas\source\repos\RandomNamesExercices\RandomNamesExercices\data_files\mail.dat", Encoding.Unicode);

            Console.WriteLine("Antal: \n{0} drenge | {1} piger | {2} efternavne \n{3} veje | {4} -byer | {5} -maildomænder ", dreng.Length, pige.Length, efternavn.Length, gadevej.Length, postnrby.Length, mail.Length);

            Console.Write("Hvor mange navne skal genereres ? : ");
            int antal = Convert.ToInt32(Console.ReadLine());

            Console.Write("Navn på datafil ?   : ");
            filnavn = Console.ReadLine();

            string[] fiktiv = new string[antal];
            // start timeren

            for (int x = 1; x <= antal; x++)
            {
                temp = "";

                if (value.Next(0, 10) >= 5)                         // vælg dreng eller pige 
                {
                    temp += dreng[value.Next(0, dreng.Length)];
                }
                else
                {
                    temp += pige[value.Next(0, pige.Length)];
                }

                temp += ";" + efternavn[value.Next(0, efternavn.Length)];      // Og efternavn....
                
                temp += ";" + gadevej[value.Next(0, gadevej.Length)];           // ..... efternavn  

                temp += ";" + value.Next(0, 101);    // husnr...

                temp += ";" + postnrby[value.Next(0, postnrby.Length)];          // postnr/by

                fiktiv[x - 1] = temp;             // læg indhold fra temp over i array'et

            }

            File.WriteAllLines(@"C:\Users\Jonas\source\repos\RandomNamesExercices\RandomNamesExercices\data_files\" + filnavn + ".dat", fiktiv, Encoding.Unicode);

            string[] lineAmount = File.ReadAllLines(@"C:\Users\Jonas\source\repos\RandomNamesExercices\RandomNamesExercices\data_files\" + filnavn + ".dat");


            Console.WriteLine("- Press SPACEBAR to continue -\n");

            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine("Printing the first 15 lines of the file:\n");

                for (int i = 0; i <= 14; i++)
                {
                    Console.WriteLine("{0}", lineAmount[i]);
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("Printing the next 15 lines of the file: \n");
            Console.WriteLine("- Press SPACEBAR to continue -\n");

            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                for (int i = 15; i <= 29; i++)
                {
                    Console.WriteLine("{0}", lineAmount[i]);
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("Printing the last 15 lines of the file: \n");
            Console.WriteLine("- Press SPACEBAR to continue -\n");

            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                for (int i = 30; i <= 44; i++)
                {
                    Console.WriteLine("{0}", lineAmount[i]);
                }
            }

            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}


/*
                Console.WriteLine("Enter any key to continue\n");
                Console.ReadLine();

                Console.WriteLine("Printing the next 15 lines of the file: ");
                if (i == 29)
                {
                    
                    Console.WriteLine("{0}", lineAmount[i]);
                    
                }

                Console.WriteLine("Enter any key to continue\n");
                Console.ReadLine();

                Console.WriteLine("Printing the last 15 lines of the file: "); 

                if (i == 44)
                {
                    Console.WriteLine("{0}", lineAmount[i]);
                }*/