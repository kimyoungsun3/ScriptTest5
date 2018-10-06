using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataManager{
	public static class UserData
	{
		public static List<OwnerItem> listOwnerItem = new List<OwnerItem> ();
		public static List<GiftItem> listGiftItem = new List<GiftItem> ();


		public static void Init(){
			listOwnerItem.Clear ();
			listGiftItem.Clear ();
		}
	}
}