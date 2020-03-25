using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AttributeTest
{
	[CustomPropertyDrawer(typeof(ReadOnlyAttribute), true)]
	public class ReadOnlyDrawer : PropertyDrawer 
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return UnityEditor.EditorGUI.GetPropertyHeight(property, label, true);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			bool _disabled = true;
			switch (((ReadOnlyAttribute)attribute).runtimeOnly){
				case eReadOnlyType.Full_Disabled:
					_disabled = true;
					break;
				case eReadOnlyType.Editable_Runtime:
					_disabled = !Application.isPlaying;
					break;
				case eReadOnlyType.Editable_Editor:
					_disabled = Application.isPlaying;
					break;
			}

			using (var scope = new UnityEditor.EditorGUI.DisabledGroupScope(_disabled))
			{
				UnityEditor.EditorGUI.PropertyField(position, property, label, true);
			}
		}
	}

	[CustomPropertyDrawer(typeof(BeginReadOnlyAttribute))]
	public class BeginReadOnlyGroupDrawer : DecoratorDrawer
	{
		public override float GetHeight()
		{
			return 0;
		}

		public override void OnGUI(Rect position)
		{
			UnityEditor.EditorGUI.BeginDisabledGroup(true);
		}
	}

	[CustomPropertyDrawer(typeof(EndReadOnlyAttribute))]
	public class EndReadOnlyGroupDrawer : DecoratorDrawer
	{
		public override float GetHeight()
		{
			return 0;
		}

		public override void OnGUI(Rect position)
		{
			UnityEditor.EditorGUI.EndDisabledGroup();
		}
	}
}