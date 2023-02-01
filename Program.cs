using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasaDirektoriji
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Program na početku traži unos putanje te, ako unesena putanja postoji, ispisuje
            datoteke koje se tamo nalaze.*/

            Console.WriteLine("Upisite putanju direktorija");
            string putanja = Console.ReadLine();
            if (Directory.Exists(putanja))
            {
                Directory.SetCurrentDirectory(putanja);
                
                Console.WriteLine("Trenutačno smo u directoriju: {0}\nOn se nalazi u directoriju: {1}",
                    Directory.GetCurrentDirectory(),
                    Directory.GetParent(Directory.GetCurrentDirectory()));

                Console.WriteLine("U ovom direktoriju imaju direktoriji: ");
                string[] direktoriji = Directory.GetDirectories(Directory.GetCurrentDirectory());
                for (int i = 0; i < direktoriji.Length; i++) { Console.WriteLine(direktoriji[i]); }

                Console.WriteLine("U ovom direktoriju imaju datoteke: ");
                foreach (string datoteka in Directory.GetFiles(putanja))
                {
                    Console.WriteLine(datoteka);
                }
            }
            else
            {
                Directory.CreateDirectory(putanja);
                Directory.SetCurrentDirectory(putanja);
                Console.WriteLine("Napravljena je novi directory");
                File.Create(putanja + "\\temp.txt");
                Console.WriteLine("Napravljena je datoteka temp.txt");
                string parent = Convert.ToString(Directory.GetParent(putanja));
                
                Console.WriteLine("File Temp, pomaknut u directory {1}", parent);
                Directory.Delete(putanja, true);
                Console.WriteLine("Directory {0}, izbrisana", putanja);
            }
            Console.ReadKey();

        }
    }
}
