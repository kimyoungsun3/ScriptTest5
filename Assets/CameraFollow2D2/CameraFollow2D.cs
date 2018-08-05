using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraFollow2D2{
	public class CameraFollow2D : MonoBehaviour {
		Transform trans;
		Vector3 dir, pos;

		public Transform player;
		public Transform minT, maxT;
		Vector3 min, max;
		public Vector2 margine = new Vector2(1, 1);		// Distance in the y axis the player can move before the camera follows.
		[Range(.2f, 10f)] public float smooth = 2f;		// How smoothly the camera catches up with it's target movement in the x axis.


		void Start () {
			trans 	= transform;
			CalculateMinMax (ref min, ref max);
		}


		void LateUpdate () {
			if(player != null){
				pos = trans.position;
				dir = player.position - pos;

				//x, y move
				if (Mathf.Abs (dir.x) > margine.x) {
					pos.x = Mathf.Lerp (pos.x, player.position.x, smooth * Time.deltaTime);
				}

				if (Mathf.Abs (dir.y) > margine.y) {
					pos.y = Mathf.Lerp (pos.y, player.position.y, smooth * Time.deltaTime);
				}

				//임계치 범위....
				pos.x = Mathf.Clamp (pos.x, min.x, max.x);
				pos.y = Mathf.Clamp (pos.y, min.y, max.y);


				trans.position = pos;
				//trans.position = Vector3.SmoothDamp (trans.position, pos, ref currentVelocity, 0.15f);
			}			
		}


		//--------------------------------------
		void CalculateMinMax(ref Vector3 _min, ref Vector3 _max){
			float _x = Camera.main.orthographicSize * Camera.main.aspect;
			float _y = Camera.main.orthographicSize;

			_min = minT.position;
			_max = maxT.position;
			//Debug.Log (_x + ":" + _y + ":" + _min + ":" + _max);

			_min.Set (_min.x + _x, _min.y + _y, _min.z);
			_max.Set (_max.x - _x, _max.y - _y, _max.z);
			//Debug.Log (" > " + _min + ":" + _max);
		}

		void OnDrawGizmos(){
			Vector3[] _vs = new Vector3[5];
			CalculateMinMax (ref min, ref max);

			//out line
			_vs [0] = new Vector3 (minT.position.x, minT.position.y, 0);
			_vs [1] = new Vector3 (maxT.position.x, minT.position.y, 0);
			_vs [2] = new Vector3 (maxT.position.x, maxT.position.y, 0);
			_vs [3] = new Vector3 (minT.position.x, maxT.position.y, 0);
			_vs [4] = new Vector3 (minT.position.x, minT.position.y, 0);
			Gizmos.color = Color.red;
			for (int i = 0, iMax = _vs.Length - 1; i < iMax; i++) {
				Gizmos.DrawLine (_vs [i], _vs [i + 1]);
			}

			//real line
			_vs [0].Set(min.x, min.y, 0);
			_vs [1].Set(max.x, min.y, 0);
			_vs [2].Set(max.x, max.y, 0);
			_vs [3].Set(min.x, max.y, 0);
			_vs [4].Set(min.x, min.y, 0);
			Gizmos.color = Color.green;
			for (int i = 0, iMax = _vs.Length - 1; i < iMax; i++) {
				Gizmos.DrawLine (_vs [i], _vs [i + 1]);
			}

			//player line
			if (player != null) {
				_vs [0].Set(player.position.x - margine.x, player.position.y - margine.y, 0);
				_vs [1].Set(player.position.x + margine.x, player.position.y - margine.y, 0);
				_vs [2].Set(player.position.x + margine.x, player.position.y + margine.y, 0);
				_vs [3].Set(player.position.x - margine.x, player.position.y + margine.y, 0);
				_vs [4].Set(player.position.x - margine.x, player.position.y - margine.y, 0);

				Gizmos.color = Color.blue;
				for (int i = 0, iMax = _vs.Length - 1; i < iMax; i++) {
					Gizmos.DrawLine (_vs [i], _vs [i + 1]);
				}
			}
		}
	}
}
