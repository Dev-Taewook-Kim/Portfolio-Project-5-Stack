using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class ConditionalDrawAttribute : PropertyAttribute
{
    public string source;

    public int enumIndex;

    public ConditionalDrawAttribute(string source)
    {
        this.source = source;
    }

    public ConditionalDrawAttribute(string enumVarName, int enumIndex)
    {
        this.source = enumVarName;
        this.enumIndex = enumIndex;
    }
}
