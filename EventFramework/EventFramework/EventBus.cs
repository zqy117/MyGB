using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFramework
{
    public sealed class EventBus
    {
        private static Dictionary<Type, List<Type>> eventMappers = new Dictionary<Type, List<Type>>();

        public void RaiseEvent<TEvent>(object o) where TEvent : BaseEvent
        {
            if (!eventMappers.ContainsKey(typeof(TEvent)))
                return;

            List<Type> existingProcessorTypes = eventMappers[typeof(TEvent)];
            foreach(Type t in existingProcessorTypes)
            {
                BaseEventProcessor processor = (BaseEventProcessor)Activator.CreateInstance(t);
                processor.Process();
            }
        }
        public void RaiseEvent(Type eventType, object o)
        {
            if (!eventMappers.ContainsKey(eventType))
                return;

            List<Type> existingProcessorTypes = eventMappers[eventType];
            foreach (Type t in existingProcessorTypes)
            {
                BaseEventProcessor processor = (BaseEventProcessor)Activator.CreateInstance(t);
                processor.Process();
            }
        }

        public void Subscribe<TEvent, TProcessor>()
            where TEvent : BaseEvent
            where TProcessor:BaseEventProcessor
        {
            if (!eventMappers.ContainsKey(typeof(TEvent)))
                eventMappers.Add(typeof(TEvent), new List<Type>());

            List<Type> existingProcessorTypes=eventMappers[typeof(TEvent)];
            if (!existingProcessorTypes.Exists(t => t is TProcessor))
            {
                existingProcessorTypes.Add(typeof(TProcessor));
                eventMappers[typeof(TEvent)] = existingProcessorTypes;
            }
        }
    }
}
