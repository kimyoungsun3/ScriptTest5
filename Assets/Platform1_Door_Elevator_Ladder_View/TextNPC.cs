using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform_Door_Elevator
{
	public class TextNPC : MonoBehaviour
	{
		public string npcName;
		[TextArea(5, 8)]public string message;

		private void OnTriggerEnter(Collider _col)
		{
			if (_col.CompareTag("Player"))
			{
				Ui_MessageBox.ins.SetMessage(npcName, message);
			}
		}

		private void OnTriggerExit(Collider _col)
		{
			if (_col.CompareTag("Player"))
			{
				Ui_MessageBox.ins.SetDisable();
			}

		}
	}
}