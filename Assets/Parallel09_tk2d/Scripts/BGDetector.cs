using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace tk2d_Parallel{
	public enum BG_TYPE { BG_FAR, BG_MIDDLE, BG_NEAR, BG_FRONT};
	public class BGDetector : MonoBehaviour {
		[System.Serializable]
		public class BGClass
		{
			//public string name;
			public BG_TYPE type;
			public float width;
			public List<Transform> listTrans = new List<Transform> ();
			[HideInInspector] public Vector3 startPos;
		}

		public static BGDetector ins;
		Transform trans;
		public List<BGClass> listBG = new List<BGClass> ();

		void Awake(){
			ins = this;
			trans = transform;
		}

		void Start () {
			ReArrange ();
		
		}

		public void Reset(){
			BGClass _c;
			for(int i = 0, iMax = listBG.Count; i < iMax; i++)
			{
				_c = listBG[i];
				_c.startPos = _c.listTrans[0].position;
			}
			ReArrange ();
		}


		[ContextMenu("Do ReArrange")]
		void ReArrange()
		{
			//Pipe Re-arrange position x and position y
			Vector3 _pos;
			Transform _t, _t1, _t2;
			float _firstX = 0;
			BGClass _c;

			for(int i = 0, iMax = listBG.Count; i < iMax; i++){
				_c = listBG[i];
				for (int j = 0, jMax = _c.listTrans.Count; j < jMax; j++) {
					_t = _c.listTrans [j];
					_pos = _t.position;
					if (j == 0) {						
						_firstX = _pos.x;
						_c.startPos = _t.position;
					} else {
						_pos.x = _firstX + j * _c.width;
					}
					_t.position = _pos;
				}
			}
		}

		void OnTriggerEnter2D(Collider2D _col){
			//Debug.Log (_col.name);
			BGObject _scp = _col.GetComponent<BGObject>();
			if(_scp != null){
				BGClass _c = GetBGList(_scp.type);
				if (_c != null) {
					Vector3 _pos = _col.transform.position;
					_pos.x += _c.width * _c.listTrans.Count;
					_col.transform.position = _pos;
				}
			}
		}

		BGClass GetBGList(BG_TYPE _type){
			for (int i = 0, iMax = listBG.Count; i < iMax; i++) {
				if (listBG [i].type == _type) {
					return listBG [i];
				}
			}

			return null;
		}
	}
}
