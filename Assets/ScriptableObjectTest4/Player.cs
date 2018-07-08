using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest4{
	public class Player : MonoBehaviour {
		public Plane plane;

		public float speed = 5f;
		public PlayerMoveSO scpPlayerMoveSO;
		public PlayerLookSO scpPlayerLookSO;

		// Use this for initialization
		void Start () {
			plane = new Plane (-Vector3.forward, Vector3.zero); 
		}

		// Update is called once per frame
		void Update () {
			//----------------------------
			//move
			//----------------------------
			if (scpPlayerMoveSO != null) {
				scpPlayerMoveSO.Move (this);
			}

			//----------------------------
			//dir
			//----------------------------
			if (scpPlayerLookSO != null) {
				scpPlayerLookSO.Move (this);
			}
		}

		//public Quaternion GetQuaternionFromDir2D(Vector3 _dir){
		//	float _angle = Mathf.Atan2 (_dir.y, _dir.x) * Mathf.Rad2Deg;
		//	Quaternion _q = Quaternion.Euler (Vector3.forward * _angle);
		//	return _q;
		//}
	}
}
