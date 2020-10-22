using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _196_JsonUtility
{

	public class JsonExample3 : MonoBehaviour
	{
		//public JTestClass jtc;
		//[TextArea(10, 15)] public string jsonData;
		//public JTestClass jtc2;

		// Use this for initialization
		void Start()
		{
			//jtc		= new JTestClass(true);
			//jsonData = ToJson(jtc, true);
			//jtc2 = FromJson<JTestClass>(jsonData);


			//JSONObject _json = new JSONObject();
			//_json.AddField("gameid", "gameid");
			//_json.AddField("pw", "password");
			//_json.AddField("nickname", "nickname");
			////socket.Emit(_type.ToString(), _json);
			//string _msg = string.Format("[\"{0}\",{1}]", "PTC_LOGIN", _json);
			////Debug.Log(_msg);

			////JTestClass[] _users = new JTestClass[5];
			////for (int i = 0; i < _users.Length; i++)
			////	_users[i] = new JTestClass(true);

			//////string _str = ToJson(_users);
			////string _str = JsonHelper.ToJson<JTestClass>(_users);
			////Debug.Log(_str);


			//t[0] = Time.realtimeSinceStartup;
			//Fun1();
			//t[1] = Time.realtimeSinceStartup;
			//Fun2();
			//t[2] = Time.realtimeSinceStartup;
			////Fun1();
			////t[3] = Time.realtimeSinceStartup;
			////if(bAdd)Fun2();
			////t[4] = Time.realtimeSinceStartup;
			////if (bAdd) Fun2();
			////t[5] = Time.realtimeSinceStartup;
			////if (bAdd) Fun2();
			////t[6] = Time.realtimeSinceStartup;

			//Debug.Log(this + " Loop:" + LOOP_MAX + " SUB_LOOP:" + SUB_LOOP);
			//Debug.Log(this + " new:" + (t[1] - t[0]));
			//Debug.Log(this + " notstring:" + (t[2] - t[1]));
			//Debug.Log("new:" + (t[3] - t[2]));
			//Debug.Log("add:" + (t[4] - t[3]));
			//Debug.Log("add:" + (t[5] - t[4]));
			//Debug.Log("add:" + (t[6] - t[5]));
			/**/
		}

		private void Update()
		{
			//JSONObject _json = new JSONObject();
			//_json.AddField("gameid", "gameid");
			//_json.AddField("pw", "password");
			//_json.AddField("nickname", "nickname");
			//string _msg = string.Format("[\"{0}\",{1}]", "PTC_LOGIN", _json);


			Debug.Log("JSONObject Loop:" + LOOP_MAX + " SUB_LOOP:" + SUB_LOOP);

			t[0] = Time.realtimeSinceStartup;
			//Fun_ToJson();
			t[1] = Time.realtimeSinceStartup;
			Debug.Log("JSONObject ToJson:" + (t[1] - t[0]));

			t[0] = Time.realtimeSinceStartup;
			Fun_FromJson();
			t[1] = Time.realtimeSinceStartup;
			Debug.Log("JSONObject FromJson:" + (t[1] - t[0]));
		}

		public bool bAdd = false;
		public int LOOP_MAX = 10000 * 1;
		public int SUB_LOOP = 10;
		public float[] t = new float[10];
		void Fun_ToJson()
		{
			JSONObject _json = new JSONObject();
			_json.AddField("gameid",	"gameid");
			_json.AddField("pw",		"password");
			_json.AddField("nickname",	"nickname");
			for (int j = 0; j < SUB_LOOP; j++)
				_json.AddField("nickname" + j, "nickname" + j);

			string _msg;
			for (int i = 0; i < LOOP_MAX; i++)
			{
				//socket.Emit(_type.ToString(), _json);
				_msg = string.Format("[\"{0}\",{1}]", "PTC_LOGIN", _json);
			}
		}

		void Fun_FromJson()
		{
			JSONObject _json;// = new JSONObject();
			string _msg;
			for (int i = 0; i < LOOP_MAX; i++)
			{
				List<string> keys = new List<string>();
				List<JSONObject> list = new List<JSONObject>();
				for (int j = 0; j < SUB_LOOP; j++)
				{
					keys.Add("gameid");
					list.Add(JSONObject.Create());
				}

				//_json = new JSONObject();
				//_json.AddField("gameid",	"gameid");
				//_json.AddField("pw",		"password");
				//_json.AddField("nickname",	"nickname");
				//for (int j = 0; j < SUB_LOOP; j++)
				//	_json.AddField("nickname" + j, "nickname" + j);

				//socket.Emit(_type.ToString(), _json);
				//_msg = string.Format("[\"{0}\",{1}]", "PTC_LOGIN", _json);
				_json = null;
			}
		}

		void Fun1_NotClear()
		{
			JSONObject _json = new JSONObject();
			string _msg;
			
			for (int i = 0; i < LOOP_MAX; i++)
			{
				//_json = new JSONObject();
				_json.AddField("gameid", "gameid");
				_json.AddField("pw", "password");
				_json.AddField("nickname", "nickname");
				//socket.Emit(_type.ToString(), _json);
				_msg = string.Format("[\"{0}\",{1}]", "PTC_LOGIN", _json);
				//_json = null;
			}
		}
	}
}