using Supyrb;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace NetFabric
{
    [CustomPropertyDrawer(typeof(AngleDegrees))]
    public class AngleDegreesPropertyDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var min = AngleDegrees.Zero;
            var max = AngleDegrees.Full;

            var range = (AngleDegreesRangeAttribute)fieldInfo
                .GetCustomAttributes(typeof(AngleDegreesRangeAttribute), true)
                .FirstOrDefault();
            if (range is object)
            {
                min = range.Min;
                max = range.Max;
            }

            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, label);

            var angle = property.GetValue<AngleDegrees>();
            var newAngle = Angle.FromDegrees(EditorGUI.Slider(position, (float)angle.Degrees, (float)min.Degrees, (float)max.Degrees));
            if (newAngle != angle)
                property.SetValue<AngleDegrees>(newAngle);

            EditorGUI.EndProperty();
        }
    }
}
