using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

namespace GameEventSystem.Chanels{
    public class BaseEventChanel<T> : ScriptableObject
    {
        private UnityEvent<T> my_event = new UnityEvent<T>();


        public T currentValue;
        public T lastValue;
        public void Publish(T value)
        {
            lastValue = value;
            if (my_event == null) return;
            my_event.Invoke(value);
            
        }
        public void Subscribe(UnityAction<T> toCall)
        {
            my_event.AddListener(toCall);
        }
        public void Unsubscribe(UnityAction<T> toCall)
        {
            my_event.RemoveListener(toCall);

        }
 
}
}