using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataManager2{
	[System.Serializable]
	public class GiftItem {
		public int listIdx;
		public int itemcode;
		public int cnt;
		public string itemname;

		public GiftItem(int _listidx, int _itemcode, int _cnt, string _itemname){
			listIdx 	= _listidx;
			itemcode 	= _itemcode;
			cnt 		= _cnt;
			itemname 	= _itemname;
		}

		public void Display(){
			Debug.Log (ToString());
		}

		public override string ToString(){
			return listIdx + " > " + itemcode + " x " + cnt + " :" + itemname;
		}

		public void AddCnt(int _plus){
			cnt += _plus;
		}
	}
}
