using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

namespace LocalizingDataManagerTest
{
	public enum eLanguageType
	{
		Korean,
		English,
		Japenese,
		Chinese
	}

	public class LocalizingDataManager
	{
		public eLanguageType typeLanguage = eLanguageType.Korean;
		private static LocalizingDataManager instance;
		public static LocalizingDataManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new LocalizingDataManager();
					instance.LoadLocalizingData("XML/LocalizingTest");
					instance.LoadLocalizingData("XML/Localizing");
					instance.LoadLocalizingData("XML/DataLocalizing");
					instance.LoadLocalizingData("XML/TalkLocalizing");
				}
				return instance;
			}
		}

		private Dictionary<string, Dictionary<eLanguageType, string>> dic_LocalizingData = new Dictionary<string, Dictionary<eLanguageType, string>>();
		private List<LocalizingText> list_RegistLabel = new List<LocalizingText>();

		//---------------------------------------------------------
		public void SetLanguage(eLanguageType _typeLanguage)
		{
			typeLanguage = _typeLanguage;
		}

		public void SetLanguage()
		{
			for (int i = 0, imax = list_RegistLabel.Count; i < imax; i++)
			{
				SetLanguage(list_RegistLabel[i].GetLocalizeTexts());
			}
		}

		public void SetLanguage(LocalizeText[] _localizeTexts)
		{
			eLanguageType _language = typeLanguage;
			string _uniqueID;
			for (int j = 0, jmax = _localizeTexts.Length; j < jmax; j++)
			{
				if (Constant.DEBUG) Debug.Log(_localizeTexts[j].uniqueID + "," + dic_LocalizingData.ContainsKey(_localizeTexts[j].uniqueID));
				_uniqueID = _localizeTexts[j].uniqueID.Trim();

				if (!_uniqueID.Contains("/"))
				{
					if (dic_LocalizingData.ContainsKey(_uniqueID) && dic_LocalizingData[_uniqueID].ContainsKey(_language))
					{
						//Debug.Log(localizingDataDic[uniqueID][_language]);
						_localizeTexts[j].label.text = dic_LocalizingData[_uniqueID][_language];
					}
				}
				else
				{
					string[] _texts = _uniqueID.Split('/');
					_localizeTexts[j].label.text = "";
					string _str;
					for (int k = 0, kmax = _texts.Length; k < kmax; k++)
					{
						_str = _texts[k].Trim();
						if (dic_LocalizingData.ContainsKey(_str) && dic_LocalizingData[_str].ContainsKey(_language))
						{
							_localizeTexts[j].label.text += dic_LocalizingData[_str][_language];
						}
						else
						{
							_localizeTexts[j].label.text += _str;
						}
					}
				}

				if (_uniqueID.Contains("{"))
				{
					string[] _texts = _uniqueID.Split('/');
					_uniqueID = _texts[0].Trim();
					if (dic_LocalizingData.ContainsKey(_uniqueID) && dic_LocalizingData[_uniqueID].ContainsKey(_language))
					{
						string[] parameterArray = _texts[1].Split(',');
						_localizeTexts[j].label.text = string.Format(dic_LocalizingData[_uniqueID][_language], parameterArray);
					}
				}
			}
		}

		public void SetLocalizeLabel(LocalizingText _localizeText, bool _isStart)
		{
			list_RegistLabel.Add(_localizeText);
			if (_isStart)
			{
				SetLanguage(_localizeText.GetLocalizeTexts());
			}
		}

		public void LabelClear()
		{
			list_RegistLabel.Clear();
		}

		//------------------------------------------------------------

		public string GetText(string _uniqueID, bool _isSplit = false)
		{
			eLanguageType _language = typeLanguage;
			if (!_isSplit)
			{
				if (dic_LocalizingData.ContainsKey(_uniqueID) 
					&& dic_LocalizingData[_uniqueID].ContainsKey(_language))
						return dic_LocalizingData[_uniqueID][_language];
			}
			else
			{
				string[] _texts			= _uniqueID.Split('/');
				string _resultString	= "";
				for (int i = 0, imax = _texts.Length; i < imax; i++)
				{
					_uniqueID = _texts[i].Trim();
					if (dic_LocalizingData.ContainsKey(_uniqueID) 
						&& dic_LocalizingData[_uniqueID].ContainsKey(_language))
					{
						_resultString += dic_LocalizingData[_uniqueID][_language];
					}
					else
					{
						_resultString += _texts[i];
					}
				}
				return _resultString;
			}
			return _uniqueID;
		}

		public string GetText(string _uniqueID, string _text)
		{
			eLanguageType _language = typeLanguage;
			//if(Constant.DEBUG)Debug.Log(this + " GetText _uniqueID:" + _uniqueID + " _text:" + _text);
			if (dic_LocalizingData.ContainsKey(_uniqueID) && dic_LocalizingData[_uniqueID].ContainsKey(_language))
			{
				string _str = dic_LocalizingData[_uniqueID][_language];
				if (_str.Contains("{0}"))
				{
					_str = _str.Replace("{0}", _text);
					return _str;
				}
			}
			return _uniqueID;
		}

		//LoadLocalizingData("XML/Localizing");
		//LoadLocalizingData("XML/DataLocalizing");
		//LoadLocalizingData("XML/TalkLocalizing");
		private void LoadLocalizingData(string _xmlFile)
		{
			if (Constant.DEBUG) Debug.Log(this + " LoadSceneTable >> " + _xmlFile);
			TextAsset _textAsset = Resources.Load<TextAsset>(_xmlFile);
			if (_textAsset == null)
			{
				Debug.Log("TextAsset Load Failed");
				return;
			}
			XmlDocument _xmldoc = new XmlDocument();
			_xmldoc.LoadXml(_textAsset.text);
  
			XmlNodeList _nodeList = _xmldoc.SelectNodes("Localizing/Data");
			XmlNode _item;
			string _uniqueID;

			for (int i = 0, imax = _nodeList.Count; i < imax; i++)
			{
				_item		= _nodeList.Item(i);
				_uniqueID	= _item.SelectSingleNode("UniqueID").InnerText;

				if (!string.IsNullOrEmpty(_uniqueID) && !dic_LocalizingData.ContainsKey(_uniqueID))
				{
					dic_LocalizingData.Add(_uniqueID, new Dictionary<eLanguageType, string>());
					if (_item.SelectSingleNode("Korean") != null)
						dic_LocalizingData[_uniqueID].Add(eLanguageType.Korean, _item.SelectSingleNode("Korean").InnerText);
					if (_item.SelectSingleNode("English") != null)
						dic_LocalizingData[_uniqueID].Add(eLanguageType.English, _item.SelectSingleNode("English").InnerText);
					if (_item.SelectSingleNode("Japenese") != null)
						dic_LocalizingData[_uniqueID].Add(eLanguageType.Japenese, _item.SelectSingleNode("Japenese").InnerText);
					if (_item.SelectSingleNode("Chinese") != null)
						dic_LocalizingData[_uniqueID].Add(eLanguageType.Chinese, _item.SelectSingleNode("Chinese").InnerText);
				}
				else
				{
					Debug.Log(" >> 중복발생:" + _xmlFile + " (" + _uniqueID + ")");
					continue;
				}
			}
		}
	}
}