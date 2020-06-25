using System.Collections;
using System.Collections.Generic;
using Teamp2.Library.Framework.DataType;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseDisplaySharedVariableTextUI<T, U> : MonoBehaviour where T : BaseSharedVariable<U> where U : struct
{
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private T sharedVariable;

    [SerializeField] private Text textUI;

    private void LateUpdate()
    {
        textUI.text = $"{sharedVariable.Value,0:00}";
    }
}
