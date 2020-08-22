using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _GameFlowStruct
{
	[System.Serializable]
	public class ItemOwner
	{
		public int itemcode;
		public ItemMaster itemData;

		public int upgradeStep;
		public int ownerCount;

		public ItemOwner(int _itemcode, ItemMaster _itemData)
		{
			itemcode	= _itemcode;
			itemData	= _itemData;
			upgradeStep = 0;
			ownerCount	= 1;
		}

		public void UgradeItem()
		{
			upgradeStep++;
			upgradeStep = upgradeStep > 10 ? 10 : upgradeStep;
		}
	}
}
