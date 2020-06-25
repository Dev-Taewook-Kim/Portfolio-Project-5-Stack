using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class HierarchyLable : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private new string name = "New Lable";

    [TextArea]
    [SerializeField] private string description = "Lable Description";

    public enum HierarchyLableCapacity { Short = 25, Medium = 50, Long = 100 };

    [SerializeField] private HierarchyLableCapacity lableCapacity = HierarchyLableCapacity.Medium;

    [SerializeField] private char blankCharacter = '_';

    [SerializeField] private bool alwaysCenter = false;

    private StringBuilder stringBuilder = new StringBuilder();

    private void OnValidate()
    {
        stringBuilder.Clear();

        stringBuilder.Capacity = (int)lableCapacity;

        var leftBlankCount = ((int)lableCapacity - name.Length) * 0.5f;

        var rightBlankCount = name.Length % 2 == 0 ? leftBlankCount : leftBlankCount - 1;

        for (int i = 0; i < leftBlankCount; i++)
        {
            stringBuilder.Append(blankCharacter);
        }

        stringBuilder.Append(name);

        for (int i = 0; i < rightBlankCount; i++)
        {
            stringBuilder.Append(blankCharacter);
        }

        gameObject.name = stringBuilder.ToString();

        if (alwaysCenter)
            transform.position = Vector3.zero;
    }
#endif
}
