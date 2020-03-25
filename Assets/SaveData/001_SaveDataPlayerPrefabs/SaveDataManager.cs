using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaveDataTest001
{
	[System.Serializable]
	public class UserData{
		public int gamecash;
		public int gamecoin;
		public int stage;

		public void Init()
		{
			gamecash	= 0;
			gamecoin	= 0;
			stage		= 1;
		}
	}

	public class SaveDataManager : MonoBehaviour
	{
		public static SaveDataManager ins;
		public UserData userData = new UserData();

		private void Awake()
		{
			if(ins != null)
			{
				Destroy(gameObject);
				return;
			}

			ins = this;
			DontDestroyOnLoad(gameObject);
		}

		// Use this for initialization
		void Start()
		{
			Debug.Log("1,2,3, Change Variable");
			LoadData();
		}

		//gamecash:gamecost:stage
		//1       :       2:    3
		void LoadData()
		{
			string _strData = PlayerPrefs.GetString("MyData", "");
			if (!string.IsNullOrEmpty(_strData))
			{
				string[] _datas = _strData.Split(':');
				for(int i = 0, imax = _datas.Length; i < imax; i++)
				{
					switch (i)
					{
						case 0:		userData.gamecash	= int.Parse(_datas[i]);	break;
						case 1:		userData.gamecoin	= int.Parse(_datas[i]); break;
						case 2:		userData.stage		= int.Parse(_datas[i]); break;
					}
				}
			}
			else
			{
				userData.Init();
			}
		}

		private void OnApplicationQuit()
		{
			SaveData();
		}

		void SaveData()
		{
			StringBuilder _builder = new StringBuilder();
			_builder.Append(userData.gamecash);
			_builder.Append(":");
			_builder.Append(userData.gamecoin);
			_builder.Append(":");
			_builder.Append(userData.stage);

			PlayerPrefs.SetString("MyData", _builder.ToString());
			PlayerPrefs.Save();
		}

		// Update is called once per frame
		void Update()
		{
			//값세팅....
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				userData.gamecash += 10;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				userData.gamecoin += 5;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				userData.stage += 1;
			}

		}
	}
}
