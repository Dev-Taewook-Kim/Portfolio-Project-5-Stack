using System.Collections;
using System.Collections.Generic;
using Teamp2.Library.Framework.DataType;
using UnityEngine;

public abstract class BaseDisplaySharedVariableTextMesh<T, U> : MonoBehaviour where T : BaseSharedVariable<U> where U : struct
{
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private T sharedVariable;

    [SerializeField] private TextMesh textMesh;

    private void LateUpdate()
    {
        textMesh.text = $"{sharedVariable.Value,0:00000000}";
    }
}
