using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _GameFlowStruct
{
	[System.Serializable]
	public class PlayerData
	{
		public string name;
		public float health;
		public int exp;

		public List<ItemOwner> listOwnerItem = new List<ItemOwner>();

		public void AddItem(ItemOwner _item)
		{
			listOwnerItem.Add(_item);
		}

		public void UpgradeItem(ItemOwner _item)
		{
			_item.UgradeItem();
		}
	}


	public class Player : MonoBehaviour
	{
		public PlayerData playerData;
		Color originalColor;
		Material materal;
		public void InitData()
		{
			gameObject.SetActive(true);
			materal = GetComponent<Renderer>().material;
			originalColor = materal.color;

			playerData		= new PlayerData();
			playerData.name	= "ID" + Random.Range(10000, 99999);
			gameObject.name = playerData.name;
			playerData.health = Random.Range(100f, 200f);
			textID.text		= playerData.health.ToString();
			textListOwner.text = "";
		}

		public void DestroyUser()
		{
			Destroy(gameObject);
		}

		private void OnMouseDown()
		{
			ItemMaster _itemMaster;
			int _r = Random.Range(0, 2);
			int _itemcode;
			if (_r == 0)
			{
				_itemcode	= 10001;
				_itemMaster = ItemInfo.ins.Get_WearItem(10001);
			}
			else
			{
				_itemcode	= 10101;
				_itemMaster = ItemInfo.ins.Get_WeaponItem(10101);
			}
			
			//위의 아이템 지급...
			ItemOwner _itemOwner = new ItemOwner(_itemcode, _itemMaster);
			playerData.AddItem(_itemOwner);

			string _msg = "";
			List<ItemOwner> _list = playerData.listOwnerItem;
			for (int i = 0, imax = _list.Count; i < imax; i++)
			{
				_msg += _list[i].itemData.name + "\n";
			}
			textListOwner.text = _msg;


		}

		public void ReleasePlayer()
		{
			materal.color = originalColor;
		}

		public void SelectPlayer()
		{
			materal.color = Color.red;
		}

		public void Attack()
		{
			List<Player> _list = PlayerManager.ins.listPlayer;
			Player _other;
			for (int i = 0, imax = _list.Count; i < imax; i++)
			{
				_other = _list[i];
				if (this != _other)
				{
					_other.Damage();
				}
			}
		}

		public void Damage()
		{
			playerData.health -= Random.Range(2f, 5f);
			textID.text = playerData.health.ToString();
		}

		public TextMesh textID;
		public TextMesh textListOwner;
	}
}