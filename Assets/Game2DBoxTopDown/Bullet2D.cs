using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;

namespace Game2DBoxTopDown
{
	public class Bullet2D : MonoBehaviour
	{
		Transform trans;
		[SerializeField] float speed = 20f;
		[SerializeField] LayerMask maskHit;
		float plusCheckRadius = .1f;
		private static Vector3 limit;

		// Start is called before the first frame update
		void Start()
		{
			trans = transform;

			if(limit == Vector3.zero)
			{
				Camera _cam		= Camera.main;
				float _size		= _cam.orthographicSize;
				float _aspect	= _cam.aspect;
				limit.Set(_size * _aspect, _size, 0);
			}
		}

		// Update is called once per frame
		void Update()
		{
			Vector3 _deltaMove = Vector3.right * speed * Time.deltaTime;
			float _distance = _deltaMove.magnitude;

			RaycastHit2D _hit = Physics2D.Raycast(trans.position, trans.right, _distance, maskHit);
			if (_hit)
			{
				//Sound, Particle
				ParticleSystem _p = PoolManager.ins.Instantiate("ShellExplosion", _hit.point, Quaternion.identity).GetComponent<ParticleSystem>();
				_p.Stop();
				_p.Play();

				PoolReturn();
			}
			else
			{
				trans.Translate(_deltaMove);
			}

			if (trans.position.x < -limit.x || trans.position.x > limit.x
				|| trans.position.y < -limit.y || trans.position.y > limit.y)
			{
				PoolReturn();
			}
		}

		void PoolReturn()
		{
			gameObject.SetActive(false);
		}
	}
}