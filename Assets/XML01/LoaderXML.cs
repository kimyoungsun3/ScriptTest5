using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

namespace XMLTest01
{

	public class LoaderXML
	{
		private static LoaderXML ins_;
		public static LoaderXML ins
		{
			get
			{
				if (ins_ == null)
				{
					ins_ = new LoaderXML();
				}
				return ins_;
			}
		}

		//public static LoaderXML ins;
		//private void Awake()
		//{
		//	ins = this;
		//}

		//LoaderXML.ins.LoadMonster(dic, "Monster_data2");
		public void LoadMonster(Dictionary<int, MonsterData> _dic, string _xmlFile)
		{
			TextAsset _textAsset = Resources.Load<TextAsset>(_xmlFile);
			if (_textAsset == null)
			{
				Debug.LogError("TextAsset Load Failed");
				return;
			}
			XmlDocument _xmldoc = new XmlDocument();
			_xmldoc.LoadXml(_textAsset.text);
  
			XmlNodeList _nodeList = _xmldoc.SelectNodes("root/lvmonster");
			XmlNode _item;
			string _strItemcode;
			int _itemcode;
			MonsterData _data;

			for (int i = 0, imax = _nodeList.Count; i < imax; i++)
			{
				//xml data part label
				_item			= _nodeList.Item(i);
				_strItemcode	= _item.SelectSingleNode("itemcode").InnerText;
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
				_data = new MonsterData();

				//data parse;
				_data.itemcode	= _itemcode;
				_data.filedata	= _item.SelectSingleNode("filedata").InnerText;
				_data.name		= _item.SelectSingleNode("name").InnerText;

							   				 			  			  			 		   						   
				_data.ReadFileData();
				string _type = _item.SelectSingleNode("type").InnerText;
				switch (_type)
				{
					case "A(1)":	_data.type = eMonsterType.GroupA;		break;
					case "B(2)":	_data.type = eMonsterType.GroupB;		break;
					default:		Debug.LogError("type error");			break;
				}

				_data.health		= float.Parse(_item.SelectSingleNode("health").InnerText);
				_data.attacktime	= float.Parse(_item.SelectSingleNode("attacktime").InnerText);
				_data.attackpower	= float.Parse(_item.SelectSingleNode("attackpower").InnerText);
				_data.attackspeed	= float.Parse(_item.SelectSingleNode("attackspeed").InnerText);
				_data.waittime		= float.Parse(_item.SelectSingleNode("waittime").InnerText);
				_data.speedmove		= float.Parse(_item.SelectSingleNode("speedmove").InnerText);
				_data.speedchase	= float.Parse(_item.SelectSingleNode("speedchase").InnerText);
				_data.speedturn		= float.Parse(_item.SelectSingleNode("speedturn").InnerText);
				_data.radius		= float.Parse(_item.SelectSingleNode("radius").InnerText);
				_data.radiusattack	= float.Parse(_item.SelectSingleNode("radiusattack").InnerText);
				_data.radiustorelease = float.Parse(_item.SelectSingleNode("radiustorelease").InnerText);


				_dic.Add(_data.itemcode, _data);
				//Debug.Log(_data.ToString());
			}
		}
	}

	
}