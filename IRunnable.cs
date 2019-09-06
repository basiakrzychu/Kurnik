using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurnik
{
    interface IRunnable
    {
        bool HasFinished
        {
            get;
            set;
        }
        void Run();
      //  IEnumerator<float> CoroutineUpdate();
    }
}
