using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedEventListener : MonoBehaviour
{
    [SerializeField] private SharedEvent sharedEvent;

    [SerializeField] private UnityEngine.Events.UnityEvent unityEvent;

    private void OnEnable() => sharedEvent.RegisterListener(this);

    private void OnDisable() => sharedEvent.UnregisterListener(this);

    public void OnEventRaised() => unityEvent.Invoke();
}
