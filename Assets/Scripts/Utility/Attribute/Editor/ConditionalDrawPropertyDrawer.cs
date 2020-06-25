using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ConditionalDrawAttribute))]
public class ConditionalDrawPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var attribute = (ConditionalDrawAttribute)this.attribute;

        var isEnabled = GetConditionalDrawAttribute(attribute, property);

        if (isEnabled)
            EditorGUI.PropertyField(position, property, label, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var attribute = (ConditionalDrawAttribute)this.attribute;

        var isEnabled = GetConditionalDrawAttribute(attribute, property);

        if (isEnabled)
            return EditorGUI.GetPropertyHeight(property, label);

        return -EditorGUIUtility.standardVerticalSpacing;
    }

    private bool GetConditionalDrawAttribute(ConditionalDrawAttribute attribute, SerializedProperty property)
    {
        var source = default(SerializedProperty);

        if (!property.isArray)
        {
            var propertyPath = property.propertyPath;
            var conditionPath = propertyPath.Replace(property.name, attribute.source);

            source = property.serializedObject.FindProperty(conditionPath);
            

            if(source == null)
            {
                source = property.serializedObject.FindProperty(attribute.source);
            }
        }

        else
        {
            source = property.serializedObject.FindProperty(attribute.source);
        }

        if (source != null)
            return CheckPropertyType(attribute, source);

        return true;
    }

    private bool CheckPropertyType(ConditionalDrawAttribute attribute, SerializedProperty source)
    {
        switch (source.propertyType)
        {
            case SerializedPropertyType.Boolean:
                return source.boolValue;

            case SerializedPropertyType.Enum:
                return source.enumValueIndex == attribute.enumIndex;

            case SerializedPropertyType.Generic:
            case SerializedPropertyType.Integer:
            case SerializedPropertyType.Float:
            case SerializedPropertyType.String:
            case SerializedPropertyType.Color:
            case SerializedPropertyType.ObjectReference:
            case SerializedPropertyType.LayerMask:
            case SerializedPropertyType.Vector2:
            case SerializedPropertyType.Vector3:
            case SerializedPropertyType.Vector4:
            case SerializedPropertyType.Rect:
            case SerializedPropertyType.ArraySize:
            case SerializedPropertyType.Character:
            case SerializedPropertyType.AnimationCurve:
            case SerializedPropertyType.Bounds:
            case SerializedPropertyType.Gradient:
            case SerializedPropertyType.Quaternion:
            case SerializedPropertyType.ExposedReference:
            case SerializedPropertyType.FixedBufferSize:
            case SerializedPropertyType.Vector2Int:
            case SerializedPropertyType.Vector3Int:
            case SerializedPropertyType.RectInt:
            case SerializedPropertyType.BoundsInt:
            case SerializedPropertyType.ManagedReference:
            default:
                Debug.LogError($"{source.propertyType} is not supported");
                return true;
        }
    }
}
