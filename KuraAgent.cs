using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kurnik
{
    class KuraAgent:Agent
    {
        public int wiek { get; set; }
        private int pragnienie;
        private int glod;
        private bool g=true;
        private bool p = true;
        


        public KuraAgent(int ID, int frequency  ) : base(ID, frequency)
        {
           
           
        }

        public override void Update()
        {
           
           
            if (p == false)
            {
                p = true;
                try
                {
                    Program.kurnik.picie.Release();
                }
                catch { }
            }

            if (g == false)
            {
                g = true;
                try
                {
                    Program.kurnik.jedz.Release();
                }
                catch { }
                //      Console.WriteLine("Kura ID: {0} zwalnia blokade",ID);
            }

            

            if (wiek > 12 || pragnienie > 2 || glod > 4 || Program.kurnik.Czystosc <= 0)
            {
                Program.kury.Remove(this);

                //    Program.rolnik.Sprzatanie();
                this.HasFinished = true;


           //     Console.WriteLine("Kura {0} umiera. wiek:{1}, pragnienie:{2}, glod:{3}, czystosc:{4}", ID, wiek,pragnienie,glod, Program.kurnik.Czystosc/100);
                
               
                return;
            }

            Console.WriteLine("Kura ID: {0}, wiek {1}, pragnienie {2}, glod {3}, czystosc {4}, jedzenie {5}, woda {6}", ID, wiek,pragnienie,glod,Program.kurnik.Czystosc/100, Program.kurnik.Jedzenie/100,Program.kurnik.Woda/100);

            Program.kurnik.Czystosc -= 50;
            wiek++;
            pragnienie++;
            glod++;

  

           
             

            if (wiek % 6 == 5)
            {

           //     Console.WriteLine("Kura ID: {0}, wiek {1} składa jajko", ID, wiek);
                JajkoAgent jajko = new JajkoAgent(Program.i, 10);
                Program.i++;

               
                Program.agents.Add(jajko);

                List<Agent> lista = new List<Agent>();
                lista.Add(jajko);
                Program.RunThreads(lista);

                return;
            }

          

            

            if (Program.kurnik.Woda > 0 && pragnienie>1 && Program.kurnik.picie.CurrentCount>0)
            {
                Program.kurnik.picie.Wait();
                Program.kurnik.Woda -= 500;
     //         Console.WriteLine("Kura {0} pije. {1}", ID, pragnienie);
          //      Program.kurnik.picie.Release();
                pragnienie = 0;
                p = false;
                return;
            }
            if (Program.kurnik.Jedzenie > 0 && glod>2 && Program.kurnik.jedz.CurrentCount>0)
            {
                Program.kurnik.jedz.Wait();
                Program.kurnik.Jedzenie -= 500;
            //    Console.WriteLine("Kura {0} je. {1}", ID, glod);
            //    Program.kurnik.jedz.Release();
                glod = 0;
                g = false;
                  return;
                
                
            }
           
            
/*
            Program.kurnik.dwor.WaitOne();
         //   Console.WriteLine("Kura {0} wychodzi na dwór.",ID);
            Program.kurnik.dwor.ReleaseMutex();

        //    Console.WriteLine("Kura {0} biega sobie wesoło po dworze.", ID);

            Program.kurnik.dwor.WaitOne();
       //   Console.WriteLine("Kura {0} wchodzi do kurnika.", ID);
            Program.kurnik.dwor.ReleaseMutex();

    */

          

         
        }


    }
}
