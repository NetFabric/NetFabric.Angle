using Supyrb;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace NetFabric
{
    [CustomPropertyDrawer(typeof(Angle))]
    public class AnglePropertyDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var min = Angle.Zero;
            var max = Angle.Full;

            var range = fieldInfo.GetCustomAttributes(typeof(AngleRangeAttribute), true).Cast<AngleRangeAttribute>().FirstOrDefault();
            if (range != null)
            {
                min = range.Min;
                max = range.Max;
            }

            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, label);

            var angle = property.GetValue<Angle>();
            var newAngle = Angle.FromDegrees(EditorGUI.Slider(position, (float)angle.ToDegrees(), (float)min.ToDegrees(), (float)max.ToDegrees()));
            if (newAngle != angle)
                property.SetValue<Angle>(newAngle);

            EditorGUI.EndProperty();
        }
    }
}
