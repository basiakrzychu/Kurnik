using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurnik
{
    class Program
    {
        static List<Agent> GenerateRunnables(KurnikAgent kurnik)
        {
            List<Agent> agents = new List<Agent>();
            agents.Add(new JajkoAgent(0, 10));
            agents.Add(new JajkoAgent(1, 10));
            agents.Add(new JajkoAgent(2, 10));


         /*   agents.Add(new JajkoAgent(3, 10));
            agents.Add(new JajkoAgent(4, 10));
            agents.Add(new JajkoAgent(5, 10));
            agents.Add(new JajkoAgent(6, 10));
            agents.Add(new JajkoAgent(7, 10));
            agents.Add(new JajkoAgent(8, 10));*/
            return agents;
        }

       static public int i = 3;
       

        public static void RunThreads(List<Agent> agents)
        {

            List<Thread> threads = new List<Thread>();
            foreach (var agent in agents)
            {
                threads.Add(new Thread(agent.Run));
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
        /*    foreach (var thread in threads)
            {
               thread.Join();
            }
    */

        }

        public static KurnikAgent kurnik;
        public static Thread kurnikT;
        
        public static void Kurnik()
        {
            kurnik = new KurnikAgent(0, 10, 5000, 5000, 5000);
            kurnikT = new Thread(kurnik.Run);
            kurnikT.Start();
          
         
          
        }
        
        public static RolnikAgent rolnik;
        public static Thread rolnikT;

        public static void Rolnik(int i)
        {
            rolnik = new RolnikAgent(i, 10);
            rolnikT = new Thread(rolnik.Run);
            rolnikT.Start();
          
           
        }

        static public List<Agent> agents;

        static public List<Agent> kury=new List<Agent>();

        public static Thread thr2;
        
        static void Main(string[] args)
        {

            Wait obj = new Wait();

            // Creating and initializing threads 
            Thread thr1 = new Thread(new ThreadStart(obj.mythread));
            thr2 = new Thread(new ThreadStart(obj.mythread));
            thr1.Start();

            // Join thread 
            thr1.Join();
            thr2.Start();
            
            Kurnik();
            Rolnik(0);
            agents = GenerateRunnables(kurnik);
            RunThreads(agents);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           
         //   Console.ReadKey();
          // Program.kurnik.picie = new SemaphoreSlim(15, 15);


        }
    }
}
