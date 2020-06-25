using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shared Event", menuName = "Teamp2/Utility/Event/Shared Event")]
public class SharedEvent : ScriptableObject
{
    [SerializeField] private List<SharedEventListener> listeners = new List<SharedEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(SharedEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(SharedEventListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }
}
