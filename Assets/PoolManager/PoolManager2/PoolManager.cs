/*
 * 2018.6.01 영선 ( kyssmart@naver.com )....
 * 
 * [미처리 내용입니다.]
 * - 생성을 처음에 개별로 지정하기. > OK
 * - 이름으로 관리가 아니라 GameObject로 관리. > OK
 * - 생성관리를 환영큐.. 
 *   > 이것은 약간 front 는 이상 없는데.... rear부분에 각 오브젝트에서 이동 해줘야 하는 문제가 있어 보류.
 *   > front 만 인식하는 형태로 가면 될듯.... 
 * */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace PM2{
	public class PoolManager : MonoBehaviour {
		[System.Serializable]
		public class GameObjectInfo{
			public GameObject prefab;
			public int count = 10;
			//public int index = 0;
		}

		public static PoolManager ins;
		public List<GameObjectInfo> objList = new List<GameObjectInfo>();
		public bool willGrow = true;

		//1. 첫번째 Prefab 파일. 
		//2. 두번째 GameObject는 Memory GameObject
		public Dictionary<GameObject, List<GameObject>> poolList = new Dictionary<GameObject, List<GameObject>>();

		void Awake(){
			if (ins == null) {
				ins = this;
			}

			init ();
		}

		private void init(){
			GameObject _go, _prefab;
			int _len = objList.Count;
			List<GameObject> _list;
			int _count, i, j; 
			for (j = 0; j < _len; j++) {
				_prefab = objList [j].prefab;
				_count 	= objList [j].count;
				if (poolList.ContainsKey (_prefab)) {
					Debug.LogWarning ((j+1) + "번째 풀링 프리펩이 동일 GameObject 풀링 : " + _prefab);
					continue;
				} else if (_prefab == null) {
					Debug.LogWarning ((j+1) + "번째 풀링 프리펩이 활당되지 않음.");
					continue;
				}

				_list 	= new List<GameObject> ();
				poolList.Add(_prefab, _list);
				for (i = 0; i < _count; i++) {
					_go = Instantiate (_prefab) as GameObject;
					_go.transform.SetParent (transform);
					_go.SetActive (false);
					_list.Add (_go);
					_go.name += i.ToString ();
				}
			}
		}



		public GameObject Instantiate(GameObject _go, Vector3 _pos, Quaternion _qua){
			GameObject _rtnObject = Instantiate2 (_go);
			_rtnObject.transform.position = _pos;
			_rtnObject.transform.rotation = _qua;

			return _rtnObject;
		}

		public GameObject Instantiate2(GameObject _go){
			if (!poolList.ContainsKey (_go)) {
				Debug.LogError ("풀링에 없음 _name[" + _go.name + "]");
				return null;
			}
			GameObject _rtn = null;
			bool _find = false;

			List<GameObject> _list = poolList [_go];
			for (int i = 0; i < _list.Count; i++) {
				if (!_list[i].activeInHierarchy) {
					_rtn 	= _list[i];
					_find 	= true;
					_rtn.SetActive (true);
					break;
				}
			}

			//not found the pooling gameobject and create gameobject 
			if (!_find && willGrow) {
				GameObject _goTemp = Instantiate (_go) as GameObject;
				_list.Add (_goTemp);
				_goTemp.transform.SetParent (transform);
				_rtn = _goTemp;
			}

			//Debug.Log (3+":" + _rtn.name);
			return _rtn;
		}

	}
}