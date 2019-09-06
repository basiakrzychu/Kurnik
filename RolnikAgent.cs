using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kurnik
{
    class RolnikAgent : Agent
    {
        public RolnikAgent(int ID, int frequency) : base(ID, frequency)
        {

        }

        public override void Update()
        {
            


            if (Program.kurnik.Woda<=9000 && Program.kurnik.Woda<=Program.kurnik.Jedzenie && Program.kurnik.Woda <=Program.kurnik.Czystosc)
            {
                Program.kurnik.Woda+=500;
         //       Console.WriteLine("Rolnik nalał wody");
                return;
            }
            if (Program.kurnik.Jedzenie <= 9000 && Program.kurnik.Jedzenie <=Program.kurnik.Czystosc)
            {
                Program.kurnik.Jedzenie += 500;
            //    Console.WriteLine("Rolnik dosypał ziarna");
                return;
            }
            if (Program.kurnik.Czystosc <= 9000)
            {
                Program.kurnik.Czystosc += 500;
         //       Console.WriteLine("Rolnik wyczyścił kurnik");
                return;
            }



            try
            {
                if (Program.agents.Count() > 3)
                {
                    Program.agents.Last().HasFinished = true;
                    Program.agents.Remove(Program.agents.Last());
                    
                    //      Console.WriteLine("Rolnik {1} zebrał jajko. Pozostała liczba jajek: {0}", Program.agents.Count(),ID);
                    return;
                }
            }
            catch { }

            //  Console.WriteLine("Rolnik {0} z tej strony", ID);

           

        }

        public void Sprzatanie()
        {
       //    Console.WriteLine("Rolnik utylizyje zwłoki kury.");
        }
    }

}
