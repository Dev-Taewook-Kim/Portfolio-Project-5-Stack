using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellObject : MonoBehaviour
{
    [Header("[Properties]")]
    [SerializeField] private StackObject currentStack;

    public StackObject GetStack => currentStack;

    public void SetStack(StackObject value) => currentStack = value;

    public void UnsetStack() => currentStack = null;

    public bool HasStack => currentStack == null ? false : true;
}
