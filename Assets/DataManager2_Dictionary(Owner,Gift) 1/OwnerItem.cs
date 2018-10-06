using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataManager2{
	[System.Serializable]
	public class OwnerItem  {
		public int listIdx;
		public int itemcode;
		public int cnt;
		public string itemname;

		//-------------------------------
		public OwnerItem(int _listidx, int _itemcode, int _cnt, string _itemname){
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
			
		#region 아이템 Plus / Using
		//-------------------------------
		public void AddCnt(int _plus){
			cnt += _plus;
		}

		//--------------------------------
		// 10 - 1  >= 0		-> true
		// 10 - 10 >= 0		-> true
		// 10 - 11 > -1		-> false
		//--------------------------------
		public bool ChechCnt(int _useCnt){
			return cnt - _useCnt >= 0;
		}

		public void UseItem(int _useCnt){
			cnt -= _useCnt;
		}
		#endregion
	}
}