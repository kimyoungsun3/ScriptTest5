using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameArrowLegend
{
	public class Bullet : MonoBehaviour
	{
		Transform trans;
		[SerializeField] float speed;
		[SerializeField] LayerMask checkMask;
		[SerializeField] [Range(1, 10)] int hitCount = 1;
		[SerializeField] [Range(.5f, 100)] float power;
		Ray ray;
		RaycastHit hit, hit2;

		private void Start()
		{
			Init(hitCount, 10f);
		}

		public void Init(int _hitCount, float _power)
		{
			trans = transform;
			hitCount = _hitCount;
			power = _power;
		}

		private void Update()
		{
			ray.origin = trans.position;
			ray.direction = trans.forward;
			float _distance = speed * Time.deltaTime;
			Vector3 _deltaPos = ray.direction * _distance;

			if (Physics.Raycast(ray, out hit, _distance, checkMask, QueryTriggerInteraction.Collide))
			{
				//hit -> damage 입력...
				hitCount--;
				IDamageable _damage = hit.collider.GetComponent<IDamageable>();
				if (_damage != null)
				{
					_damage.Damage(power);
				}

				//히트 수량만큼만...
				if (hitCount <= 0)
				{
					Destroy(gameObject);
				}
				else
				{
					Vector3 _moveDir = hit.point - ray.origin;
					float _moveDistance = _moveDir.magnitude;
					Vector3 _reflect = Vector3.Reflect(_moveDir, hit.normal).normalized;
					float _remainDistance = _distance - _moveDistance;

					//2차 충돌...
					if (Physics.Raycast(hit.point, _reflect, out hit2, _remainDistance, checkMask, QueryTriggerInteraction.Collide))
					{
						Vector3 _moveDir2 = hit2.point - hit.point;
						float _moveDistance2 = _moveDir2.magnitude;
						Vector3 _reflect2 = Vector3.Reflect(_moveDir2, hit2.normal).normalized;
						float _remainDistance2 = _remainDistance - _moveDistance2;

						trans.position = hit2.point + _remainDistance2 * _reflect2;
						trans.rotation = Quaternion.LookRotation(_reflect2);
					}
					else
					{
						trans.position = hit.point + _remainDistance * _reflect;
						trans.rotation = Quaternion.LookRotation(_reflect);
					}
				}
			}
			else
			{
				trans.Translate(Vector3.forward * _distance);
			}
		}

		Vector3 Project(Vector3 _dir, Vector3 _base)
		{
			return (Vector3.Dot(_dir, _base) / Vector3.Dot(_base, _base)) * _base;
		}

		Vector3 Project2(Vector3 _dir, Vector3 _base)
		{
			Vector3 _baseN = _base.normalized;
			return Vector3.Dot(_dir, _baseN) * _baseN;
		}

		Vector3 ProjectH(Vector3 _dir, Vector3 _base)
		{
			return _dir - Project(_dir, _base);
		}

		Vector3 ProjectH2(Vector3 _dir, Vector3 _base)
		{
			return _dir - Project2(_dir, _base);
		}

		Vector3 Reflect(Vector3 _inputDir, Vector3 _hitNormal)
		{
			Vector3 _project = Project(-_inputDir, _hitNormal);
			return _inputDir + 2 * _project;
		}
	}

}