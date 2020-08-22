using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


namespace _GameFlowStruct
{
	public class ItemMaster
	{
		public int itemcode;
		public eWearKind kind;
		public string name;
		public string icon;
		public string descript;
	}

	public class ItemWear : ItemMaster
	{
		public float def;
		public float plusdef;
	}

	public class ItemWeapon : ItemMaster
	{
		public float att;
		public float plusatt;
	}

	public class ItemInfo
	{
		#region singleton
		private static ItemInfo ins_;
		public static ItemInfo ins
		{
			get
			{
				if (ins_ == null)
				{
					ins_ = new ItemInfo();
				}
				return ins_;
			}
		}

		//public static LoaderXML ins;
		//private void Awake()
		//{
		//	ins = this;
		//}
		#endregion


		public Dictionary<int, ItemWear> dic_ItemWear		= new Dictionary<int, ItemWear>();
		public Dictionary<int, ItemWeapon> dic_ItemOwner	= new Dictionary<int, ItemWeapon>();


		public void Init()
		{
			string _strXML = LoadXML("xml/iteminfo");

			Parse_WearItem(_strXML, "root/wearitem");
			Parse_WeaponItem(_strXML, "root/weaponitem");
		}

		#region ItemWear
		public ItemWear Get_WearItem(int _itemcode)
		{
			if (dic_ItemWear.ContainsKey(_itemcode))
			{
				return dic_ItemWear[_itemcode];
			}
			return null;
		}

		//xmlFile , selectNode
		void Parse_WearItem(string _strXML, string _selectNode)
		{
			if (string.IsNullOrEmpty(_strXML))
			{
				Debug.LogError("TextAsset Load Failed >> string null or empty");
				return;
			}
			
			XmlDocument _xmldoc = new XmlDocument();
			_xmldoc.LoadXml(_strXML);
			XmlNodeList _nodeList = _xmldoc.SelectNodes(_selectNode);
			XmlNode _item;

			Dictionary<int, ItemWear> _dic = dic_ItemWear;
			string _strItemcode;
			int _itemcode;
			ItemWear _data;

			for (int i = 0, imax = _nodeList.Count; i < imax; i++)
			{
				//xml data part label
				_item = _nodeList.Item(i);
				_strItemcode = _item.SelectSingleNode("itemcode").InnerText;
				if (string.IsNullOrEmpty(_strItemcode))
				{
					Debug.LogError("itemcode is null");
					continue;
				}

				_itemcode = int.Parse(_strItemcode);
				if (_dic.ContainsKey(_itemcode))
				{
					Debug.LogError("Monster code double");
					continue;
				}

				//create data 
				_data			= new ItemWear();

				//data parse;
				_data.itemcode	= _itemcode;
				_data.kind = eWearKind.Cloth;
				_data.name		= _item.SelectSingleNode("name").InnerText;
				_data.icon		= _item.SelectSingleNode("icon").InnerText;
				_data.descript	= _item.SelectSingleNode("descript").InnerText;

				_data.def		= float.Parse(_item.SelectSingleNode("def").InnerText);
				_data.plusdef	= float.Parse(_item.SelectSingleNode("plusdef").InnerText);
				//_itemcode		= int.Parse(_strItemcode);
				//_data.attacktime	= float.Parse(_item.SelectSingleNode("attacktime").InnerText);

				_dic.Add(_data.itemcode, _data);	
			}
		}
		#endregion

		#region ItemWeapon
		public ItemWeapon Get_WeaponItem(int _itemcode)
		{
			if (dic_ItemOwner.ContainsKey(_itemcode))
			{
				return dic_ItemOwner[_itemcode];
			}
			return null;
		}

		//xmlFile , selectNode
		void Parse_WeaponItem(string _strXML, string _selectNode)
		{
			if (string.IsNullOrEmpty(_strXML))
			{
				Debug.LogError("TextAsset Load Failed >> string null or empty");
				return;
			}

			XmlDocument _xmldoc = new XmlDocument();
			_xmldoc.LoadXml(_strXML);
			XmlNodeList _nodeList = _xmldoc.SelectNodes(_selectNode);
			XmlNode _item;

			Dictionary<int, ItemWeapon> _dic = dic_ItemOwner;
			string _strItemcode;
			int _itemcode;
			ItemWeapon _data;

			for (int i = 0, imax = _nodeList.Count; i < imax; i++)
			{
				//xml data part label
				_item = _nodeList.Item(i);
				_strItemcode = _item.SelectSingleNode("itemcode").InnerText;
				if (string.IsNullOrEmpty(_strItemcode))
				{
					Debug.LogError("itemcode is null");
					continue;
				}

				_itemcode = int.Parse(_strItemcode);
				if (_dic.ContainsKey(_itemcode))
				{
					Debug.LogError("Monster code double");
					continue;
				}

				//create data 
				_data = new ItemWeapon();

				//data parse;
				_data.itemcode	= _itemcode;
				_data.kind		= eWearKind.Weapon;
				_data.name		= _item.SelectSingleNode("name").InnerText;
				_data.icon		= _item.SelectSingleNode("icon").InnerText;
				_data.descript	= _item.SelectSingleNode("descript").InnerText;

				_data.att			= float.Parse(_item.SelectSingleNode("att").InnerText);
				_data.plusatt		= float.Parse(_item.SelectSingleNode("plusatt").InnerText);
				//_itemcode		= int.Parse(_strItemcode);
				//_data.attacktime	= float.Parse(_item.SelectSingleNode("attacktime").InnerText);

				_dic.Add(_data.itemcode, _data);
			}
		}
		#endregion

		string LoadXML(string _xmlFile)
		{
			//Debug.Log(_xmlFile);
			TextAsset _textAsset = Resources.Load<TextAsset>(_xmlFile);
			if (_textAsset == null)
			{
				Debug.LogError("TextAsset Load Failed : " + _xmlFile);
				return null;
			}
			return _textAsset.text;
		}
	}
}