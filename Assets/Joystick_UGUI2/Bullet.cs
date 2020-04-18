using UnityEngine;
using System.Collections;


namespace Joystick_UGUI2
{
	public class Bullet : MonoBehaviour
	{
		public float moveSpeed = 40f;


		Ray ray = new Ray();
		RaycastHit hit;
		float moveDistance;
		float moveDistanceTotal;
		void Update()
		{
			ray.origin		= transform.position;
			ray.direction	= transform.forward;

			moveDistance	= moveSpeed * Time.deltaTime;
			moveDistanceTotal += moveDistance;
			if (Physics.Raycast(ray, out hit, moveDistance))
			{
				//TankHealth _tank = hit.collider.GetComponent<TankHealth> ();
				//if (_tank != null) {
				//	_tank.TakeDamage (damage);
				//}	

				//Sound, Particle
				//ParticleSystem _p = PoolManager.ins.Instantiate(explosion, hit.point, Quaternion.identity).GetComponent<ParticleSystem>();
				//_p.Stop();
				//_p.Play();

				//SoundManager.ins.Play ("ShellExplosion", -1);
				//PoolReturn();
			}

			transform.Translate(Vector3.forward * moveDistance);

			if (moveDistanceTotal > 50f)
				Destroy(gameObject);
		}
	}
}