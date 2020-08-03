using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


namespace XML03_Test
{
	public class TaskData
	{
		public int itemcode;
		public string name;
		public string title;
		public string question;
		public string filedata1;
		public string filedata2;
		public Sprite sprite1;
		public Sprite sprite2;
		public bool bRead;
	}

	public class LoaderXML
	{
		#region singleton
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
		#endregion

		//public static LoaderXML ins;
		//private void Awake()
		//{
		//	ins = this;
		//}

		//LoaderXML.ins.LoadMonster(dic, "Monster_data2");
		public void LoadTask(Dictionary<int, TaskData> _dic, string _xmlFile)
		{
			TextAsset _textAsset = Resources.Load<TextAsset>(_xmlFile);
			if (_textAsset == null)
			{
				Debug.LogError("TextAsset Load Failed");
				return;
			}
			XmlDocument _xmldoc = new XmlDocument();
			_xmldoc.LoadXml(_textAsset.text);

			XmlNodeList _nodeList = _xmldoc.SelectNodes("root/taskdata");
			XmlNode _item;
			string _strItemcode;
			int _itemcode;
			TaskData _data;

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
				_data = new TaskData();

				//data parse;
				_data.itemcode	= _itemcode;
				_data.name		= _item.SelectSingleNode("name").InnerText;
				_data.title		= _item.SelectSingleNode("title").InnerText;
				_data.question	= _item.SelectSingleNode("question").InnerText;
				_data.filedata1 = _item.SelectSingleNode("filedata1").InnerText;
				_data.filedata2 = _item.SelectSingleNode("filedata2").InnerText;
				//_itemcode		= int.Parse(_strItemcode);
				//_data.attacktime	= float.Parse(_item.SelectSingleNode("attacktime").InnerText);

				_dic.Add(_data.itemcode, _data);
				//Debug.Log(_data.ToString());
				_data.sprite1 = Resources.Load<Sprite>(_data.filedata1);
				_data.sprite2 = Resources.Load<Sprite>(_data.filedata2);
				

			}
		}
	}


}