using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private readonly Dictionary<string, UnityEventBase> eventsDictionary = new Dictionary<string, UnityEventBase>();

    public void RegisterEvent<T>(string eventName, UnityAction<T> action)
    {
        if (eventsDictionary.TryGetValue(eventName, out UnityEventBase unityEvent))
        {
            if (unityEvent is UnityEvent<T>)
            {
                ((UnityEvent<T>)unityEvent).AddListener(action);
            }
            else
            {
                Debug.LogError(eventName + " is already registered with a different data type.");
            }
        }
        else
        {
            UnityEvent<T> newEvent = new UnityEvent<T>();
            newEvent.AddListener(action);
            eventsDictionary[eventName] = newEvent;
        }
    }

    public void UnregisterEvent<T>(string eventName, UnityAction<T> action)
    {
        if (eventsDictionary.ContainsKey(eventName))
        {
            ((UnityEvent<T>)eventsDictionary[eventName]).RemoveListener(action);
        }
    }

    public void TriggerEvent<T>(string eventName, T eventData)
    {
        if (eventsDictionary.TryGetValue(eventName, out UnityEventBase unityEvent))
        {
            if (unityEvent is UnityEvent<T> eventWithCorrectType)
            {
                eventWithCorrectType?.Invoke(eventData);
            }
            else
            {
                Debug.LogError(eventName + " is registered with a different data type " + typeof(T));
            }
        }
        else
        {
            Debug.LogError(eventName + " is not registered.");
        }
    }
}