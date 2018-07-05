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
using PM3;


namespace PM3{
	public class PoolManager : MonoBehaviour {
		[System.Serializable]
		public class GameObjectInfo{
			public GameObject prefab;
			public int count = 10;
			//public int index = 0;
		}
		//[System.Serializable]
		public class GameObjectData{
			public List<GameObject> list;
			public int front 	= 0;
			public int max 		= 0;

			public GameObjectData(List<GameObject> _list, int _max){
				list 	= _list;
				max 	= _max;
			}
		}

		public static PoolManager ins;
		public List<GameObjectInfo> objList = new List<GameObjectInfo>();
		public bool willGrow = true;

		//1. 첫번째 Prefab 파일. 
		//2. 두번째 GameObject는 Memory GameObject
		Dictionary<GameObject, GameObjectData> poolList = new Dictionary<GameObject, GameObjectData>();

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
			GameObjectData _dataList;
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

				_list 		= new List<GameObject> ();
				_dataList 	= new GameObjectData (_list, _count);
				poolList.Add(_prefab, _dataList);
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
			GameObject _rtnObject = InstantiateInner (_go);
			_rtnObject.transform.position = _pos;
			_rtnObject.transform.rotation = _qua;

			return _rtnObject;
		}

		public GameObject InstantiateInner(GameObject _prefab){
			if (!poolList.ContainsKey (_prefab)) {
				Debug.LogError ("풀링에 없음 _name[" + _prefab.name + "]");
				return null;
			}

			GameObject _rtn = null;
			GameObjectData _dataList 	= poolList [_prefab];
			List<GameObject> _list 		= _dataList.list;
			if (!_list [_dataList.front].activeInHierarchy) {
				//Not use gameobject > return data
				_rtn = _list [_dataList.front];
				_rtn.SetActive (true);

				_dataList.front++;
				if (_dataList.front >= _dataList.max) {
					_dataList.front = 0;
				}
			} else if (willGrow) {
				//not found the pooling gameobject and create gameobject 
				GameObject _goTemp = Instantiate (_prefab) as GameObject;
				_goTemp.transform.SetParent (transform);
				_list.Insert (_dataList.front, _goTemp);
				_goTemp.name += _dataList.max.ToString ();
				_rtn = _goTemp;

				//Debug.Log ("add front:" + _dataList.front);

				_dataList.front++;
				_dataList.max++;
				if (_dataList.front >= _dataList.max) {
					_dataList.front = 0;
				}
				//Debug.Log ("info front:" + _dataList.front + " max:" + _dataList.max);
			} else {
				Debug.LogWarning (" 성장이 아닌데 여유가 없다 > 논리 오류");
			}

			return _rtn;
		}

	}
}
