using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataManager2{
	public static class UserData
	{
		public static Dictionary<int, OwnerItem> dicOwnerItem = new Dictionary<int, OwnerItem> ();
		public static Dictionary<int, GiftItem> dicGiftItem = new Dictionary<int, GiftItem> ();

		public static void Init(){
			dicOwnerItem.Clear ();
			dicGiftItem.Clear ();
		}

		#region OwnerItem
		public static void ReadOwnerItem(){

		}

		public static void AddOwnerItem(int _listIdx, int _itemcode, int _count, string _itemname){
			if (dicOwnerItem.ContainsKey (_listIdx)) {
				dicOwnerItem [_listIdx].AddCnt (_count);
			} else {
				dicOwnerItem.Add (_listIdx, new OwnerItem (_listIdx, _itemcode, _count, _itemname));
			}
		}

		public static bool UseOwnerItem(int _listIdx, int _count){
			bool _rtn = false;
			if (dicOwnerItem.ContainsKey (_listIdx)) {
				OwnerItem _ownerItem = dicOwnerItem [_listIdx];
				if (_ownerItem.ChechCnt (_count)) {
					//수량이 충분하다. > 사용...
					Debug.Log (" Use Owner OK" + _listIdx + " / " + _count);
					_ownerItem.UseItem (_count);
					if (_ownerItem.cnt <= 0) {
						dicOwnerItem.Remove (_listIdx);						
					}
					_rtn = true;
				} else {
					//수량이 부족하다..
					Debug.Log ("Not Enough " + _listIdx + " / " + _count);
				}
			} else {
				//해당템이 없다...
				Debug.Log ("Not Found " + _listIdx + " / " + _count);
			}

			return _rtn;
		}

		public static void DisplayOwnerItem(){
			foreach (OwnerItem _obj in dicOwnerItem.Values)
				_obj.Display ();
		}
		#endregion




		#region GiftItem
		public static void ReadGiftItem(){

		}

		public static void AddGiftItem(int _listIdx, int _itemcode, int _count, string _itemname){
			if (dicGiftItem.ContainsKey (_listIdx)) {
				dicGiftItem [_listIdx].AddCnt (_count);
			} else {
				dicGiftItem.Add (_listIdx, new GiftItem (_listIdx, _itemcode, _count, _itemname));
			}
		}

		public static bool RemoveGiftItem(int _listIdx){
			bool _rtn = false;
			if (dicGiftItem.ContainsKey (_listIdx)) {
				dicGiftItem.Remove (_listIdx);		
				_rtn = true;
			}
			return _rtn;
		}

		public static void DisplayGiftItem(){
			foreach (GiftItem _obj in dicGiftItem.Values)
				_obj.Display ();
		}
		#endregion
	}
}