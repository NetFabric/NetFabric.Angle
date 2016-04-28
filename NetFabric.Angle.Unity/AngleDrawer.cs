using Supyrb;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace NetFabric
{
    [CustomPropertyDrawer(typeof(Angle))]
    public class AngleDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var min = Angle.Zero;
            var max = Angle.Full;

            var range = property.GetCustomAttributes<AngleRangeAttribute>(true).FirstOrDefault();
            if(range != null)
            {
                min = range.Min;
                max = range.Max;
            }

            var angle = property.GetValue<Angle>();
            var newAngle = Angle.FromDegrees(EditorGUI.Slider(position, (float)angle.ToDegrees(), (float)min.ToDegrees(), (float)max.ToDegrees()));
            if (newAngle != angle)
                property.SetValue<Angle>(newAngle);

            EditorGUI.EndProperty();
        }
    }
}
