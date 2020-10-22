using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _196_JsonUtility
{
	public class JsonExample : MonoBehaviour
	{
		public JTestClass jtc;
		[TextArea(10, 15)]public string jsonData;
		public JTestClass jtc2;
		public int LOOP_MAX = 10000 * 1;
		public float[] t = new float[10];

		// Use this for initialization
		void Start()
		{
			//jtc		= new JTestClass(true);
			jsonData	= ToJson(jtc, true);
			jtc2		= FromJson<JTestClass>(jsonData);


			//JTestClass[] _users = new JTestClass[5];
			//for (int i = 0; i < _users.Length; i++)
			//	_users[i] = new JTestClass(true);

			////string _str = ToJson(_users);
			//string _str = JsonHelper.ToJson<JTestClass>(_users);
			//Debug.Log(_str);


			//t[0] = Time.realtimeSinceStartup;
			//Fun_ToJson();
			//t[1] = Time.realtimeSinceStartup;
			//Fun_FromJson();
			//t[2] = Time.realtimeSinceStartup;
			////Fun1();
			////t[3] = Time.realtimeSinceStartup;
			////Fun2();
			////t[4] = Time.realtimeSinceStartup;
			////Fun2();
			////t[5] = Time.realtimeSinceStartup;
			////Fun2();
			////t[6] = Time.realtimeSinceStartup;

			//Debug.Log(this + " Loop:" + LOOP_MAX);
			//Debug.Log(this + " ToJson:" + (t[1] - t[0]));
			//Debug.Log(this + " FromJson:" + (t[2] - t[1]));
			//Debug.Log(this + " ToJson:" + (t[3] - t[2]));
			//Debug.Log(this + " FromJson:" + (t[4] - t[3]));
			//Debug.Log(this + " FromJson:" + (t[5] - t[4]));
			//Debug.Log(this + " FromJson:" + (t[6] - t[5]));
		}

		private void Update()
		{
			Debug.Log("JsonUtility Loop:" + LOOP_MAX);
			t[0] = Time.realtimeSinceStartup;
			Fun_ToJson();
			t[1] = Time.realtimeSinceStartup;
			Debug.Log("JsonUtility ToJson:" + (t[1] - t[0]));


			t[0] = Time.realtimeSinceStartup;
			Fun_FromJson();
			t[1] = Time.realtimeSinceStartup;
			Debug.Log("JsonUtility FromJson:" + (t[1] - t[0]));
		}

		void Fun_ToJson()
		{
			for(int i = 0; i < LOOP_MAX; i++)
			{
				jsonData = ToJson(jtc, true);
			}
		}

		void Fun_FromJson()
		{
			JTestClass _j;
			for (int i = 0; i < LOOP_MAX; i++)
			{
				_j = FromJson<JTestClass>(jsonData);
			}
		}


		string ToJson(object _obj, bool _pretty = false)
		{
			return JsonUtility.ToJson(_obj, _pretty);
		}

		T FromJson<T>(string _jsonData)
		{
			return JsonUtility.FromJson<T>(_jsonData);
		}
	}


	[System.Serializable]
	public class JTestClass
	{
		public int i;
		public float f;
		public bool b;
		public string str;
		public float f1;//, f2, f3, f4, f5;

		public Vector3 v;
		public Quaternion q;
		public ItemData itemdata, itemdata2;

		public int[] iArray = new int[10];
		public List<int> iList = new List<int>();
		public ItemData[] itemList = new ItemData[10];
		public List<Vector3> posList = new List<Vector3>();

		//public JTestClass() { }

		//public JTestClass(bool isSet)
		//{
		//	if (isSet)
		//	{
		//		i = 10;
		//		f = 99.9f;
		//		b = true;

		//		v = new Vector3(39.56f, 21.2f, 6.4f);
		//		str = "JSON Test String";
		//		iArray = new int[] { 1, 1, 3, 5, 8, 13, 21, 34, 55 };

		//		for (int idx = 0; idx < 5; idx++)
		//		{
		//			iList.Add(2 * idx);
		//		}
		//	}
		//}
	}

	public enum eItemType { None, Head, Body, Boots, Weapon};
	[System.Serializable]
	public class ItemData {
		public int listIndex;
		public int itemcode;
		public eItemType type;
		public int upgradeCount;
		
		//.....
	}
}