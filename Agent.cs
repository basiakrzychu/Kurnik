using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Kurnik
{
    abstract class Agent :IRunnable
    {
        public bool HasFinished { get; set; }
        public int ID;
        public int Frequency = 10;
        


        public Agent(int ID, int Frequency)
        {
            HasFinished = false;
            this.ID = ID;
            this.Frequency = Frequency;
        }

        public abstract void Update();




        public void Run()
        {
           

            while (!HasFinished )
            {
                Program.thr2.Join();
                Update();
                Thread.Sleep(10000 / Frequency);
                
            }
        }
        
        public IEnumerator<float> CoroutineUpdate()
        {
            while (!HasFinished)
            {

               
            
                Update();
 
                yield return 0;
            }
            yield break;
        }
    }
}
