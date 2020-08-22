using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XML04_Test
{
	public class Ui_Result : MonoBehaviour
	{
		#region singleton
		public static Ui_Result ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion


		[SerializeField] GameObject body;
		[SerializeField] Text title;
		[SerializeField] Text context;
		List<ePopupYesNo> list;
		void Start()
		{
			body.SetActive(false);
		}

		public void SetAlive(bool _b)
		{
			body.SetActive(_b);
		}

		public void SetData(string _title, List<ePopupYesNo> _list)
		{
			body.SetActive(true);
			title.text = _title;
			list = _list;

			string _msg = "";
			for (int i = 0; i < list.Count; i++)
			{
				_msg += (i + 1) + ". " + list[i].ToString() + "\n";
			}
			context.text = _msg;
		}

		public void Invoke_Ok()
		{
			body.SetActive(false);
		}
	}
}