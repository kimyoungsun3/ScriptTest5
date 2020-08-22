using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace XML04_Test
{
	public enum ePopupYesNo { Yes, No };
	public delegate void VOID_FUN_YESNO(ePopupYesNo _e);
	public class Ui_Popup : MonoBehaviour
	{

		#region singleton
		public static Ui_Popup ins;
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
			if(_data == null)
			{
				Debug.LogError(this + " TaskData is null");
				return;
			}

			body.SetActive(true);
			title.text		= _data.title;
			question.text	= _data.question;
			imgYes.sprite	= _data.sprite1;
			imgNo.sprite	= _data.sprite2;
			onCallback		= _onCallback;
		}

		//public void SetData(string _title, string _question, Sprite _spriteYes, Sprite _spriteNo, VOID_FUN_YESNO _onCallback)
		//{
		//	body.SetActive(true);
		//	title.text		= _title;
		//	question.text	= _question;
		//	imgYes.sprite	= _spriteYes;
		//	imgNo.sprite	= _spriteNo;
		//	onCallback		= _onCallback;
		//}

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