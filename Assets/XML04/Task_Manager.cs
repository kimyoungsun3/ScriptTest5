using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace XML04_Test
{
	public class Task_Manager : MonoBehaviour
	{
		public List<int> listQuest = new List<int>();
		List<ePopupYesNo> list = new List<ePopupYesNo>();

		IEnumerator Start()
		{
			ItemInfo.ins.Init();

			yield return null;
			bool _wait = true;

			//1. question		
			for (int i = 0; i < listQuest.Count; i++)
			{
				Ui_Popup.ins.SetData(ItemInfo.ins.Get_TaskData(listQuest[i]),
					(_e) =>
					{
						_wait = false;
						list.Add(_e);
					}
				);
				_wait = true;
				while (_wait) yield return null;
				Ui_Popup.ins.SetAlive(false);
				yield return new WaitForSeconds(.5f);
			}


			////1. question		
			//Ui_Popup2.ins.SetData("T1", "Q1", spriteYes, spriteNo,
			//	(_e) =>
			//	{
			//		_wait = false;
			//		list.Add(_e);
			//	}
			//);
			//_wait = true;
			//while (_wait) yield return null;
			//Ui_Popup2.ins.SetAlive(false);
			//yield return new WaitForSeconds(1f);


			//result...
			//Ui_Result.ins.SetAlive(true);
			Ui_Result.ins.SetData("Research Result", list);
			//yield return new WaitForSeconds(2f);
		}
	}
}