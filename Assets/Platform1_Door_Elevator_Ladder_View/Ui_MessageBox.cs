using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platform_Door_Elevator
{
	public class Ui_MessageBox : MonoBehaviour
	{
		#region singletone
		public static Ui_MessageBox ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion


		public Text title;
		public Text content;
		public GameObject body;

		[Range(0.01f, 0.5f)]public float WAIT_TIME = 0.02f;
		string strContent;
		//int index;
		bool bTypeWriter;

		public void SetMessage(string _title, string _content)
		{
			body.SetActive(true);
			
			title.text		= _title;
			content.text	= "";

			//메세지를 킥 ~~~ 주주줄 출력...
			strContent = _content;
			StopCoroutine("Co_TypeWriterEffect");
			StopCoroutine("Co_Monitor");

			StartCoroutine("Co_TypeWriterEffect");
			StartCoroutine("Co_Monitor");
		}

		public void SetDisable()
		{
			body.SetActive(false);
		}

		IEnumerator Co_TypeWriterEffect()
		{
			WaitForSeconds _wait = new WaitForSeconds(WAIT_TIME);
			string _text = strContent;
			bTypeWriter = true;
			for (int i = 0, imax = _text.Length; i < imax; i++)
			{
				content.text = _text.Substring(0, i);
				yield return _wait;
			}
			bTypeWriter = false;
		}

		IEnumerator Co_Monitor()
		{
			while (bTypeWriter)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					TypeWriterFast();
				}
				yield return null;
			}
		}

		void TypeWriterFast()
		{
			StopCoroutine("Co_TypeWriterEffect");
			StopCoroutine("Co_Monitor");
			content.text = strContent;
			bTypeWriter = false;
		}
	}
}