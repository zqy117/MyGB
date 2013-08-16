using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFramework;

namespace Core.EventProcessors
{
    class SampleOrderSavedEventProcessor : BaseEventProcessor
    {
        public override void Process()
        {
            Console.WriteLine("Triggered event : SampleOrderSavedEventProcessor");
        }
    }
}
