using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace XML03_Test
{
	public enum ePopupYesNo { Yes, No };
	public delegate void VOID_FUN_YESNO(ePopupYesNo _e);
	public class Ui_Popup2 : MonoBehaviour
	{

		#region singleton
		public static Ui_Popup2 ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion


		[SerializeField] GameObject body;
		[SerializeField] Text title;
		[SerializeField] Text question;
		[SerializeField] Image imgYes, imgNo;
		VOID_FUN_YESNO onCallback;
		void Start()
		{
			body.SetActive(false);
		}

		public void SetData(TaskData _data, VOID_FUN_YESNO _onCallback)
		{
			body.SetActive(true);
			title.text = _data.title;
			question.text = _data.question;
			imgYes.sprite = _data.sprite1;
			imgNo.sprite = _data.sprite2;
			onCallback = _onCallback;
		}

		public void SetData(string _title, string _question, Sprite _spriteYes, Sprite _spriteNo, VOID_FUN_YESNO _onCallback)
		{
			body.SetActive(true);
			title.text = _title;
			question.text = _question;
			imgYes.sprite = _spriteYes;
			imgNo.sprite = _spriteNo;
			onCallback = _onCallback;
		}

		public void SetAlive(bool _b)
		{
			body.SetActive(_b);
		}

		public void Inovke_Yes()
		{
			//Debug.Log("yes");
			if (onCallback != null)
			{
				onCallback(ePopupYesNo.Yes);
			}

			SetAlive(false);
		}

		public void Inoke_No()
		{
			//Debug.Log("no");
			if (onCallback != null)
			{
				onCallback(ePopupYesNo.No);
			}
			SetAlive(false);
		}

	}
}