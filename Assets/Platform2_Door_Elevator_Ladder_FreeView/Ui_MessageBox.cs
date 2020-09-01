using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platform2_Door_Elevator_Ladder_FreeView
{
	public class Ui_MessageBox : MonoBehaviour
	{
		public static Ui_MessageBox ins;
		public GameObject body;
		public Text title;
		public Text content;


		private void Awake()
		{
			ins = this;
		}

		public void SetMessage(string _title, string _message)
		{
			body.SetActive(true);
			title.text = _title;
			content.text = _message;
		}

		public void SetDisable()
		{
			body.SetActive(false);
		}

	}
}