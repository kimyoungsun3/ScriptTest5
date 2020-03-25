﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_DragAndDropTest2
{
	public class DragDropSlotItem : MonoBehaviour
	{
		public static ItemData current;

		UISprite spriteIcon;
		ItemData itemData;

		private void Start()
		{
			SetSlot(null);
		}

		public void SetSlot(ItemData _itemData)
		{
			if(spriteIcon == null)
			{
				spriteIcon = transform.GetChild(0).GetComponent<UISprite>();
			}

			itemData = _itemData;
			if (_itemData == null)
			{
				spriteIcon.enabled		= false;
			}
			else
			{
				spriteIcon.enabled		= true;
				spriteIcon.spriteName	= _itemData.spriteName;
			}
		}

		void OnPress(bool _isPress)
		{
			if(_isPress)
				Calculate();
		}

		void OnDrop(GameObject _go)
		{
			Calculate();
		}

		void Calculate()
		{
			
			if (current == null)
			{
				//2
				//없는 상태 >> 빈곳 >> 무시...
				//없는 상태 >> 있는곳 선택...
				if (itemData == null)
				{

				}
				else
				{
					ItemData _tmp = itemData;
					SetSlot(null);

					current = _tmp;
					DragDropCursor2.instance.SetSpriteName(this, _tmp.spriteName);
				}
			}
			else if (current != null)
			{
				//1.든상태
				if (itemData == null)
				{
					//	>> 빈곳에   내려놓기...
					SetSlot(current);

					current = null;
					DragDropCursor2.instance.Clear();
				}
				else
				{
					//	>> 있는곳에 내려놓기(교체)...
					//백업하기...
					ItemData _tmp = itemData;

					//현재 커서를 넣어주기...
					SetSlot(current);

					//기존 slot에 넣어주기...
					DragDropSlotItem _beforeSlot = DragDropCursor2.instance.GetBeforeSlot();
					_beforeSlot.SetSlot(_tmp);

					//커서 클리어해주기..
					current = null;
					DragDropCursor2.instance.Clear();
				}
			}			
		}
	}
}