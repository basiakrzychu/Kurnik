using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Kurnik
{
    class KurnikAgent : Agent
    {

        public double Czystosc { get; set; }
        public double Woda { get; set; }
        public double Jedzenie { get; set; }
    
        public Mutex dwor = new Mutex();
        public SemaphoreSlim picie = new SemaphoreSlim(3, 3);
        public SemaphoreSlim jedz = new SemaphoreSlim(5, 5);





        public KurnikAgent(int ID, int frequency, double czystosc, double woda, double jedzenie) : base(ID, frequency)
        {

            Czystosc = czystosc;
            Woda = woda;
            Jedzenie = jedzenie;
        }

        public override void Update()
        {

            

            try
            {
                Console.WriteLine("KURNIK | Czystosc={0:0.00}% | Woda={1:0.00}% | Jedzenie={2:0.00}% | Liczba jajek={3} | Liczba kur={4}", Czystosc/100, Woda/100, Jedzenie/100, Program.agents.Count(), Program.kury.Count());

            }
            catch
            {
                Console.WriteLine("KURNIK | Czystosc={0:0.00}% | Woda={1:0.00}% | Jedzenie={2:0.00}% ", Czystosc / 100, Woda / 100, Jedzenie / 100);
            }

            Wait obj = new Wait();
            Program.thr2 = new Thread(new ThreadStart(obj.mythread));
            Program.thr2.Start();
        }


    }
}
