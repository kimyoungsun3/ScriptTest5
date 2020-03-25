using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttributeTest
{
	public class Sample : MonoBehaviour
	{
		public string publicField;

		[ReadOnly]
		public string readOnlyField;

		[ReadOnly(eReadOnlyType.Full_Disabled)]
		public string fullReadOnly;

		[ReadOnly(eReadOnlyType.Editable_Runtime)]
		public string editableRuntime;

		[ReadOnly(eReadOnlyType.Editable_Editor)]
		public string editableEditor;

		private void Start()
		{
			publicField		= "start";
			readOnlyField	= "start";
			fullReadOnly	= "start";
			editableRuntime = "start";
			editableEditor	= "start";

		}
	}
}
