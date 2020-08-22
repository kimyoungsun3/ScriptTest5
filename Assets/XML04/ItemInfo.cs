using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


namespace XML04_Test
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


		public Dictionary<int, TaskData> dic_TaskData = new Dictionary<int, TaskData>();

		public void Init()
		{
			Parse_TaskData("xml/task_data", "root/taskdata");
		}

		public TaskData Get_TaskData(int _itemcode)
		{
			if (dic_TaskData.ContainsKey(_itemcode))
			{
				return dic_TaskData[_itemcode];
			}
			return null;
		}

		//xmlFile , selectNode
		void Parse_TaskData(string _xmlFile, string _selectNode)
		{
			string _strXML = LoadXML(_xmlFile);
			if (string.IsNullOrEmpty(_strXML))
			{
				Debug.LogError("TextAsset Load Failed >> string null or empty");
				return;
			}
			
			XmlDocument _xmldoc = new XmlDocument();
			_xmldoc.LoadXml(_strXML);
			XmlNodeList _nodeList = _xmldoc.SelectNodes(_selectNode);
			XmlNode _item;

			Dictionary<int, TaskData> _dic = dic_TaskData;
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
				_data			= new TaskData();

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