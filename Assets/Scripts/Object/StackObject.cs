using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackObject : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private MeshRenderer[] rendererStacks;

    [SerializeField] private ParticleSystem particleCombo;

    [SerializeField] private TextMesh textCount;

    [Space()]
    [Header("[Properties]")]
    [SerializeField] private int stackId;

    [SerializeField] private int stackCount;

    //private void OnEnable() => SetStackCount(1);

    //private void OnDisable() => SetStackCount(1);

    public int GetStackId => stackId;

    public int GetStackCount => stackCount;

    public void SetCell(CellObject value) => transform.position = value.transform.position;

    public void IncreaseStackCount()
    {
        rendererStacks[stackCount++].gameObject.SetActive(true);
        textCount.text = stackCount.ToString();
    }

    public void DecreaseStackCount()
    {
        rendererStacks[--stackCount].gameObject.SetActive(false);
        textCount.text = stackCount.ToString();
    }

    public void SetStackCount(int count)
    {
        while (stackCount != count)
        {
            if (stackCount < count)
                IncreaseStackCount();

            else if (stackCount > count)
                DecreaseStackCount();
        }
    }
} 
