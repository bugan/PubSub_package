using GameEventSystem.Chanels;
using UnityEngine;
using UnityEngine.Events;

namespace GameEventSystem.Responses
{
    public class BaseEventResponse<T> : MonoBehaviour
    {
        [SerializeField]
        private BaseEventChanel<T> listeningChanel;
        [SerializeField]
        private UnityEvent<T> response;

        private UnityAction<T> _response;
        private bool started = false;
        void Start()
        {
            _response += toInvoke;
            if (listeningChanel == null) return;
            listeningChanel.Subscribe(_response);
            started = true;
        }
        void OnEnable()
        {
            if (listeningChanel == null || !started) return;
            listeningChanel.Subscribe(_response);
        }
        void OnDisable()
        {
            if (listeningChanel == null) return;
            listeningChanel.Unsubscribe(_response);
        }

        void toInvoke(T value)
        {
            response.Invoke(value);
        }
    }
}