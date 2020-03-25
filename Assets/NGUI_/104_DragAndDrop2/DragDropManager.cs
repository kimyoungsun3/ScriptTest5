using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_DragAndDropTest2
{
	public class DragDropManager : MonoBehaviour
	{
		public List<DragDropSlotItem> list_UiSlot = new List<DragDropSlotItem>();
		public List<string> list_data = new List<string>();


		IEnumerator Start()
		{
			yield return new WaitForSeconds(1f);


			ItemData _data;
			for (int i = 0, imax = list_UiSlot.Count; i < imax; i++)
			{
				if (i < list_data.Count)
					_data = new ItemData(list_data[i]);
				else
					_data = null;

				list_UiSlot[i].SetSlot(_data);
			}
		}
	}
}