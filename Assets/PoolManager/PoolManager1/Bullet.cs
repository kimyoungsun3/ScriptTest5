using UnityEngine;
using System.Collections;


namespace PM1{
	public class Bullet : MonoBehaviour {
		public LayerMask checkMask;
		public float timePoolReturnTime = 2f;
		public float moveSpeed = 10;
		public int damage = 1;
		public bool bDebug = true;
		float plusCheckRadius = .1f;
		//int playerNumber = 1;
		//GameObject owner;

		void OnEnable(){
			CancelInvoke ();
			Invoke("PoolReturn", timePoolReturnTime);
			//owner = null;
		}

		//public void Init(GameObject _owner){
		//	owner = _owner;
		//}
		 
		void OnDisalbe(){
			CancelInvoke ();
		}

		void PoolReturn(){
			gameObject.SetActive (false);
		}

		public void SetSpeed(float _speed){
			moveSpeed = _speed;
		}

		Ray ray = new Ray();
		RaycastHit hit;
		float moveDistance;
		Vector3 oldPosition;
		void Update(){
			ray.origin = transform.position;
			ray.direction = transform.forward;

			moveDistance = moveSpeed * Time.deltaTime + plusCheckRadius;
			//Debug.DrawLine (transform.position, transform.position + transform.forward * moveDistance, Color.red);
			if (Physics.Raycast (ray, out hit, moveDistance, checkMask, QueryTriggerInteraction.Collide)) {
				//TankHealth _tank = hit.collider.GetComponent<TankHealth> ();
				//if (_tank != null) {
				//	_tank.TakeDamage (damage);
				//}	

				//Sound, Particle
				ParticleSystem _p = PoolManager.ins.Instantiate("ShellExplosion", hit.point, Quaternion.identity).GetComponent<ParticleSystem>();
				_p.Stop ();
				_p.Play ();

				//SoundManager.ins.Play ("ShellExplosion", -1);
				PoolReturn ();
			}

			oldPosition = transform.position;
			transform.Translate (Vector3.forward * moveDistance);
			if (bDebug) {
				Debug.DrawLine (oldPosition, transform.position, Color.red); 
			}

		}
	}
}
