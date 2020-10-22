using UnityEngine;
using System.Collections;
using PoolManager7;

namespace FindOfView
{
	public class Bullet : MonoBehaviour
	{
		Ray ray;
		RaycastHit hit;
		float moveDistance;
		Vector3 oldPosition;

		[SerializeField] LayerMask checkMask;
		[SerializeField] float timePoolReturnTime = 2f;
		float moveSpeed = 40f;
		float damage = 1;
		float plusCheckRadius = .1f;
		//public GameObject explosion;
		//int playerNumber = 1;
		//GameObject owner;
		[SerializeField] bool bDebug = false;

		void OnEnable()
		{
			CancelInvoke();
			Invoke("PoolReturn", timePoolReturnTime);
			//owner = null;
		}

		//public void Init(GameObject _owner){
		//	owner = _owner;
		//}

		void OnDisalbe()
		{
			CancelInvoke();
		}

		void PoolReturn()
		{
			gameObject.SetActive(false);
		}

		public void SetSpeed(float _speed, float _damage)
		{
			moveSpeed	= _speed;
			damage		= _damage;
		}

		void Update()
		{
			ray.origin		= transform.position;
			ray.direction	= transform.forward;

			moveDistance = moveSpeed * Time.deltaTime + plusCheckRadius;
			Debug.DrawLine(transform.position, transform.position + transform.forward * moveDistance, Color.red);
			if (Physics.Raycast(ray, out hit, moveDistance, checkMask, QueryTriggerInteraction.Collide))
			{
				Debug.Log(">> hit");
				//IDamageable _player = hit.collider.GetComponent<IDamageable> ();
				//if (_player != null) {
				//	_player.TakeDamage (damage);
				//}	

				//Sound, Particle
				//ParticleSystem _p = PoolManager.ins.Instantiate("explosion", hit.point, Quaternion.identity).GetComponent<ParticleSystem>();
				//_p.Stop();
				//_p.Play();

				//SoundManager.ins.Play ("ShellExplosion", -1);
				PoolReturn();
			}

			oldPosition = transform.position;
			transform.Translate(Vector3.forward * moveDistance);
			if (bDebug)
			{
				Debug.DrawLine(oldPosition, transform.position, Color.red);
			}
		}
	}
}