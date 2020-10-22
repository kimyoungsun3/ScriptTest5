using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _196_JsonUtility
{
	public class JsonExample2 : MonoBehaviour
	{
		public JTestClass jtc;
		[TextArea(10, 15)] public string jsonData;
		public JTestClass jtc2;
		public int LOOP_MAX = 10000 * 1;
		public float[] t = new float[10];

		void Start()
		{
			//jtc = new PlayerInfo()
			//{
			//	Name = "Dustin",
			//	Age = 36,
			//	Race = CharacterType.Human
			//};
			//var jsonData = JsonConvert.SerializeObject(jtc);
			//var jsonData2 = JsonConvert.SerializeObject(jtc, Formatting.None);
			//.var newPlayer = JsonConvert.DeserializeObject<PlayerInfo>(jsonData);
			//JsonConvert.PopulateObject(jsonData, newPlayer);


			//Debug.Log(jsonData);
			//Debug.Log(jsonData);

			//t[0] = Time.realtimeSinceStartup;
			//Fun_ToJson();
			//t[1] = Time.realtimeSinceStartup;
			//Fun_FromJson();
			//t[2] = Time.realtimeSinceStartup;
			//Fun1();
			//t[3] = Time.realtimeSinceStartup;
			//Fun2();
			//t[4] = Time.realtimeSinceStartup;
			//Fun2();
			//t[5] = Time.realtimeSinceStartup;
			//Fun2();
			//t[6] = Time.realtimeSinceStartup;

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
			Debug.Log("Newtonsoft.Json Loop:" + LOOP_MAX);

			t[0] = Time.realtimeSinceStartup;
			Fun_ToJson();
			t[1] = Time.realtimeSinceStartup;
			Debug.Log("Newtonsoft ToJson:" + (t[1] - t[0]));

			t[0] = Time.realtimeSinceStartup;
			Fun_FromJson();
			t[1] = Time.realtimeSinceStartup;
			Debug.Log("Newtonsoft FromJson:" + (t[1] - t[0]));
		}

		void Fun_ToJson()
		{
			for (int i = 0; i < LOOP_MAX; i++)
			{
				jsonData = JsonConvert.SerializeObject(jtc);
			}
		}

		//void Fun12()
		//{
		//	for (int i = 0; i < LOOP_MAX; i++)
		//	{
		//		jsonData = JsonConvert.SerializeObject(jtc, Formatting.None);
		//	}
		//}

		void Fun_FromJson()
		{
			JTestClass _j;
			for (int i = 0; i < LOOP_MAX; i++)
			{
				_j = JsonConvert.DeserializeObject<JTestClass>(jsonData);
			}
		}
	}

	public enum CharacterType
	{
		Oger = 10,
		Human = 20,
		Orc = 30,
		Elf = 40
	}
	public class PlayerInfo
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public CharacterType Race { get; set; }
	}


}