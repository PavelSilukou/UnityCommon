using System.Collections.Generic;

namespace UnityCommon.EventSystem
{
    public class EventQueue : SingletonBehaviour<EventQueue>
    {
        private readonly Queue<Event> _eventQueue = new Queue<Event>();

        public void Enqueue(Event ev)
        {
            _eventQueue.Enqueue(ev);
        }
        
        public void Clear()
        {
            _eventQueue.Clear();
        }

        private bool IsEmpty()
        {
            return _eventQueue.Count == 0;
        }
        
        private void Run()
        {
            while (IsEmpty() == false)
            {
                var ev = _eventQueue.Dequeue();
                ev.Execute();
            }
        }

        private void Update()
        {
            Run();
        }
    }
}
