using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectionChange2{
	public class MoveFlip : MonoBehaviour {
		public float moveSpeed = 2f;
		Vector3 move;
		public bool bFlipX = false;


		// Use this for initialization
		void Start () {
			
		}

		// Update is called once per frame
		void Update () {
			move.Set (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0);
			//Debug.Log (move);
			transform.Translate ( move * moveSpeed * Time.deltaTime, Space.World);

			if (move.x > 0 && bFlipX != false) {
				SubFlipX (false);
				bFlipX = false;
				//Debug.Log (1);
			} else if (move.x < 0 && bFlipX != true) {
				SubFlipX (true);
				bFlipX = true;
				//Debug.Log (2);
			}
		}

		void SubFlipX(bool _b){
			Transform _t = transform;
			SpriteRenderer _r;
			for (int j = 0, jMax = _t.childCount; j < jMax; j++) {
				_r = _t.GetChild(j).GetComponent<SpriteRenderer> ();
				if(_r != null)
					_r.flipX = _b;
			}
		}
	}
}