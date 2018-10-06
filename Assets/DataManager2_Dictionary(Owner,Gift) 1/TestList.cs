using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataManager2{
	public class TestList : MonoBehaviour {
		void Start () {
			for (int i = 0; i < 3; i++) {
				int _count = Random.Range (1, 5);
				UserData.AddOwnerItem(i, i * 100, _count, i + "A");
			}

			GiftItem _giftItem;
			for (int i = 0; i < 3; i++) {
				int _count = Random.Range (1, 5);
				UserData.AddGiftItem(i, i * 100, _count, i + "B");
			}

			Debug.Log (" Key 1, 2 > OwenerItem Add/Use");
			Debug.Log (" Key 3, 4 > GiftItem Add / Del");
		}

		void Update () {
			int _listIdx = Random.Range (0, 5);
			int _count = Random.Range (1, 5);

			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				Debug.Log (" OwnerItem Add ");
				UserData.AddOwnerItem(_listIdx, _listIdx * 100, _count, _listIdx + "AA");
				UserData.DisplayOwnerItem ();
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				Debug.Log (" OwnerItem Use");

				_count = 1;
				bool _bUse = UserData.UseOwnerItem(_listIdx, _count);
				Debug.Log(" use > " + _bUse);
				UserData.DisplayOwnerItem ();
			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				Debug.Log (" GiftItem Add");
				UserData.AddGiftItem (_listIdx, _listIdx * 100, _count, _listIdx + "AA");
				UserData.DisplayGiftItem ();
			} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
				Debug.Log (" GiftItem Del " + _listIdx);
				bool _bUse = UserData.RemoveGiftItem(_listIdx); 
				Debug.Log(" remove > " + _bUse);
				UserData.DisplayGiftItem ();
			}			
		}
	}
}
