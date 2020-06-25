using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : class
{
    protected static SingletonBehaviour<T> baseInstance = null;

    protected static T instance = null;

    [Space(10, order = 0)]
    [Header("[Singleton Behaviour]", order = 1)]
    [Space(10, order = 2)]

    [SerializeField] private int instanceID = 0;

    [SerializeField] private int instanceHash = 0;

    [SerializeField] private bool publicAccess = false;

    [SerializeField] private bool dontDestroyOnLoad = false;

    private void Awake()
    {
        if(baseInstance == null)
        {
            baseInstance = this;
            instance = this as T;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        instanceID = GetInstanceID();
        instanceHash = GetHashCode();

        if (dontDestroyOnLoad)
            DontDestroyOnLoad(this);
    }

    public static T GetInstance()
    {
        if (baseInstance == null)
            return null;

        if (!baseInstance.publicAccess)
        {
            Debug.LogError($"Instance {baseInstance.name} is not set to public access");

            return null;
        }

        return instance;
    }

    public new static int GetInstanceID()
    {
        return baseInstance.instanceID;
    }

    public static int GetInstanceHash()
    {
        return baseInstance.instanceHash;
    }
}
