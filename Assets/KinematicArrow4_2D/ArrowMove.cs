using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicArrow4{
	public class ArrowMove : MonoBehaviour {
		//public Transform target;
		public float h = 25f;
		public float gravity = -18f;

		//void Start(){
		//	CoShooting ();
		//}

		public void CoShooting(Vector3 _pos, Transform _target){
			StopAllCoroutines ();
			StartCoroutine (Co_Shooting (_pos, _target));	
		}

		IEnumerator Co_Shooting(Vector3 _pos, Transform _target){
			transform.position 			= _pos;
			Util.StructInitData _data	= Util.CalculateInitVelocityParabola (transform.position, _target.position, h, gravity);

			Vector3 _velocity 		= _data.initVelocity;
			float _time 			= Time.time + _data.time;
			Vector3 _beforePos		= transform.position;
			//Debug.Log (_velocity + ":" + _data.time);

			while(Time.time < _time){
				//move (gravity + initialVelocity)
				_velocity += gravity * Time.deltaTime * Vector3.up;				//velocity += deltaVelocity
				transform.Translate (_velocity * Time.deltaTime, Space.World);	//move

				//rotation
				transform.rotation = Util.GetQuaternionFromDir2D (transform.position - _beforePos);
				_beforePos = transform.position;
				yield return null;
			}

			yield return new WaitForSeconds (1f);
			Destroy ();
		}

		void Destroy(){
			gameObject.SetActive (false);
		}
	}
}
