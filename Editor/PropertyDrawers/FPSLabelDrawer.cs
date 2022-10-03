/**
 * FPSLabelDrawer.cs
 * Created by: João Borks [joao.borks@gmail.com]
 * Created on: 5/30/2021 (en-US)
 */

using UnityEditor;
using UnityEngine;

namespace MyGameDevTools.Stats.UI
{
    [CustomPropertyDrawer(typeof(FPSLabel))]
    public class FPSLabelDrawer : PropertyDrawer
    {
        bool dynamicColoring;
        bool foldout;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!foldout)
                return EditorGUIUtility.singleLineHeight;
            return dynamicColoring ? EditorGUIUtility.singleLineHeight * 4 + EditorGUIUtility.standardVerticalSpacing * 3 : EditorGUIUtility.singleLineHeight * 3 + EditorGUIUtility.standardVerticalSpacing * 2;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.serializedObject.Update();
            EditorGUI.BeginProperty(position, label, property);
            var tempPosition = new Rect(position)
            {
                height = EditorGUIUtility.singleLineHeight
            };
            foldout = EditorGUI.Foldout(tempPosition, foldout, label, true);

            if (foldout)
            {
                var indent = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 1;

                tempPosition.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(tempPosition, property.FindPropertyRelative("Label"));
                tempPosition.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                var useColorProperty = property.FindPropertyRelative("UseColorGradient");
                useColorProperty.boolValue = EditorGUI.Toggle(tempPosition, useColorProperty.displayName, useColorProperty.boolValue);
                dynamicColoring = useColorProperty.boolValue;
                tempPosition.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                if (dynamicColoring)
                    EditorGUI.PropertyField(tempPosition, property.FindPropertyRelative("ColorGradient"));

                EditorGUI.indentLevel = indent;
            }

            EditorGUI.EndProperty();
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}