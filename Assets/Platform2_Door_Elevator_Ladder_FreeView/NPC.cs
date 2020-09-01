using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2_Door_Elevator_Ladder_FreeView
{

	public class NPC : MonoBehaviour
	{

		private void OnTriggerEnter(Collider other)
		{
			Ui_MessageBox.ins.SetMessage("[제목]", "내용이다...");
		}
	}
}