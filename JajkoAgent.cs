using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kurnik
{
    class JajkoAgent : Agent
    {

      

        private int wiek;
       

     

        public JajkoAgent(int ID, int frequency  ) : base(ID, frequency)
        {
          
            
        }

        public override void Update()
        {

          //  Program.kurnikT.Join();

            if (wiek == 3)
            {
         //          Console.WriteLine("Jajko ID: {0} wykluwa sie", ID);
                KuraAgent kura = new KuraAgent(ID, 10);

                Program.kury.Add(kura);
                List<Agent> lista = new List<Agent>();
                lista.Add(kura);

                Program.RunThreads(lista);
                Program.agents.Remove(this);
                this.HasFinished = true;

                return;

            }
            wiek++;


        }
    }
}
