using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace XML03_Test
{
	public class Task_Manager : MonoBehaviour
	{
		private Dictionary<int, TaskData> dic_TaskData = new Dictionary<int, TaskData>();
		public List<int> listQuest = new List<int>();
		List<ePopupYesNo> list = new List<ePopupYesNo>();

		IEnumerator Start()
		{
			LoaderXML.ins.LoadTask(dic_TaskData, "xml/task_data");
			//유연하게 읽어라....

			yield return null;
			bool _wait = true;

			//1. question		
			for (int i = 0; i < listQuest.Count; i++)
			{
				Ui_Popup2.ins.SetData(dic_TaskData[listQuest[i]],
					(_e) =>
					{
						_wait = false;
						list.Add(_e);
					}
				);
				_wait = true;
				while (_wait) yield return null;
				Ui_Popup2.ins.SetAlive(false);
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