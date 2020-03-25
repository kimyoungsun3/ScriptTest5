using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttributeTest;

namespace NGUI_ScrollView
{
	public class Ui_ItemScrollVeiw : MonoBehaviour
	{
		[SerializeField] GameObject prefab;
		[SerializeField] Transform grid;
		[SerializeField] UIScrollView scrollView;
		[SerializeField] List<string> listItemName = new List<string>();
		
		[SerializeField] [ReadOnly]
		List<ItemInfo> listItem = new List<ItemInfo>();

		private void Start()
		{
			GameObject _go;
			ItemInfo _item;
			for (int i = 0, iMax = listItemName.Count; i < iMax; i++)
			{
				_go = NGUITools.AddChild(grid, prefab);
				_item = _go.GetComponent<ItemInfo>();
				_item.SetInit(listItemName[i]);
				_go.SetActive(true);

				listItem.Add(_item);
			}

			prefab.SetActive(false);
			scrollView.ResetPosition();
		}

	}
}
