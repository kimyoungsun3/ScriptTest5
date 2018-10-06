using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataManager{
	public class TestList : MonoBehaviour {
		public List<OwnerItem> listOwnerItem = new List<OwnerItem>();
		public List<GiftItem> listGiftItem = new List<GiftItem>();

		void Start () {
			OwnerItem _ownerItem;
			for (int i = 0; i < 3; i++) {
				int _count = Random.Range (1, 5);
				_ownerItem = new OwnerItem (i, i * 100, _count, i + "A");
				listOwnerItem.Add (_ownerItem);
			}

			GiftItem _giftItem;
			for (int i = 0; i < 3; i++) {
				int _count = Random.Range (1, 5);
				_giftItem = new GiftItem (i, i * 100, _count, i + "B");
				listGiftItem.Add (_giftItem);
			}

			Debug.Log (" Key 1, 2 > OwenerItem Add/Use");
			Debug.Log (" Key 3, 4 > GiftItem Add / Del");
		}

		void Update () {
			int _listIdx = Random.Range (0, 5);
			int _count = Random.Range (1, 5);

			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				Debug.Log (" OwnerItem Add ");

				//탐색.
				OwnerItem _ownerItem = listOwnerItem.Find (
					delegate(OwnerItem _obj) {
						return _obj.listIdx == _listIdx;
					}
				);


				if (_ownerItem != null) {
					//listIdx is find -> Add
					Debug.Log (" Owner old data plus " + _listIdx + " / " + _count);
					_ownerItem.AddCnt (_count);
				} else {
					//listIdx is not found -> new Create and Add
					Debug.Log (" Owner new data add " + _listIdx + " / " + _count);
					_ownerItem = new OwnerItem (_listIdx, _listIdx * 100, _count, _listIdx + "AA");
					listOwnerItem.Add (_ownerItem);
				}

			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				Debug.Log (" OwnerItem Use");

				//탐색.
				OwnerItem _ownerItem = listOwnerItem.Find (
					delegate(OwnerItem _obj) {
						return _obj.listIdx == _listIdx;
					}
				);

				_count = 1;
				if (_ownerItem != null) {
					if (_ownerItem.ChechCnt (_count)) {
						//수량이 충분하다. > 사용...
						Debug.Log (" Use Owner OK" + _listIdx + " / " + _count);
						_ownerItem.UseItem (_count);
						if (_ownerItem.cnt <= 0) {
							listOwnerItem.Remove (_ownerItem);						
						}
					} else {
						//수량이 부족하다..
						Debug.Log ("Not Enough " + _listIdx + " / " + _count);
					}
				} else {
					//해당템이 없다...
					Debug.Log ("Not Found " + _listIdx + " / " + _count);
				}

			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				Debug.Log (" GiftItem Add");
				GiftItem _giftItem = new GiftItem (_listIdx, _listIdx * 100, _count, _listIdx + "AA");
				listGiftItem.Add (_giftItem);
			} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
				Debug.Log (" GiftItem Del");

				//탐색.
				GiftItem _giftItem = listGiftItem.Find (
					delegate(GiftItem _obj) {
						return _obj.listIdx == _listIdx;
					}
				);

				if (_giftItem != null) {
					Debug.Log (" Find and Remove" + _listIdx);
					listGiftItem.Remove (_giftItem);
				}
			}			
		}
	}
}
