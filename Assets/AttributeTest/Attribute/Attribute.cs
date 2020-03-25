using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttributeTest
{
	public enum eReadOnlyType { Full_Disabled, Editable_Runtime, Editable_Editor }

	public class ReadOnlyAttribute : PropertyAttribute
	{
		public readonly eReadOnlyType runtimeOnly;

		public ReadOnlyAttribute(eReadOnlyType _runtimeOnly = eReadOnlyType.Full_Disabled)
		{
			runtimeOnly = _runtimeOnly;
		}
	}

	public class BeginReadOnlyAttribute : PropertyAttribute { }
	public class EndReadOnlyAttribute : PropertyAttribute { }
}