using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AddUnitTest
{
	public enum eUnitSelect { None, Select, Release };

	public class UnitItem : MonoBehaviour
	{
		/// <summary>
		/// 특별한 관리 공간에 들어간것임...
		/// 나중에 관리 
		/// </summary>
		//
		//public static List<UnitItem> list	= new List<UnitItem>();
		SpriteRenderer render;
		[HideInInspector] public int unitStep;
		int sortingOrderOld;

		// Use this for initialization
		void Start()
		{
			//list.Add(this);
			Init();
		}

		public void Init(int _unitStep = 0)
		{
			if(render == null)
				render = GetComponent<SpriteRenderer>();

			unitStep		= _unitStep;
			render.sprite	= Spawner.ins.listUnitDic[unitStep].sprite;
		}

		public void SetOrder(eUnitSelect _select)
		{
			if(_select == eUnitSelect.Select)
			{
				sortingOrderOld = render.sortingOrder;
				render.sortingOrder = 100;
			}
			else
			{
				render.sortingOrder = sortingOrderOld;
			}
		}

		public void CheckArea()
		{
			SetOrder(eUnitSelect.Release);

			Bounds _bound = GetComponent<Collider>().bounds;
			Bounds _bound2;
			UnitItem _scpOther;
			List<UnitItem> _list = Spawner.ins.listUnitData;
			for (int i = 0, iMax = _list.Count; i < iMax; i++)
			{
				_scpOther = _list[i];
				//내것이 아닌것... 동일등급...
				if (this != _scpOther && unitStep == _scpOther.unitStep)
				{
					//상화 충돌인가???
					//Debug.Log(list[i].name);
					_bound2 = _scpOther.GetComponent<Collider>().bounds;
					if (_bound.Intersects(_bound2))
					{
						//Debug.Log(" >> up");
						Destroy(_scpOther.gameObject);
						_list.RemoveAt(i);


						unitStep++;
						render.sprite = Spawner.ins.listUnitDic[unitStep].sprite;
						break;
					}	
				}
			}
		}
	}
}
