using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop4.States
{
    internal interface IOrderState
    {
        void Submit();
        void Cancel();
        void Update();
        void Pay();
    }
}
