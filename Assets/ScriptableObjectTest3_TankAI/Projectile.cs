using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest3{
	public class Projectile : MonoBehaviour {
		public int damage = 1;
		public float speed = 10f;
		public LayerMask mask;
		float MOVE_LIMIT = 10f;

		GameObject gameo;
		Transform trans;
		Ray ray;
		RaycastHit hit;
		float plusCheckRadius = .1f;
		float moveDistance, moveTotal;

		//-----------------------------
		void Awake(){
			trans = transform;
			gameo = gameObject;
		}

		public void SetSpeedAndShoot(float _speed, int _damage){
			speed 		= _speed;
			damage 		= _damage;
			moveTotal	= 0f;
		}

		void Update(){
			if (moveTotal > MOVE_LIMIT) {
				OnDestory ();
			} else {
				moveDistance = speed * Time.deltaTime + plusCheckRadius;
				moveTotal += moveDistance;

				//Debug.Log (trans);
				ray.origin = trans.position;
				ray.direction = trans.forward;
				if (Physics.Raycast (ray, out hit, moveDistance, mask, QueryTriggerInteraction.Collide)) {
					OnHitOjbect (hit.collider, hit.point);
				}
				trans.Translate (Vector3.forward * moveDistance);
			}
		}

		void OnHitOjbect(Collider _col, Vector3 _point){
			IDamageable _scp = _col.GetComponent<IDamageable> ();
			if (_scp != null) {
				_scp.TakeHit (damage, _point, trans.forward);
			}
			OnDestory ();
		}

		void OnDestory(){
			gameo.SetActive (false);
		}
	}
}