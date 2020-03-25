using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;

namespace Jump3D_01
{
	public class GrapObject : MonoBehaviour
	{
		[SerializeField] float speed = 2f;
		[SerializeField] float speed2 = 180f;
		[SerializeField] float shootSpeed = 10f;
		Vector3 targetPos;
		Quaternion targetRot;
		[HideInInspector]public bool isTarget = false;
		[SerializeField] LayerMask layerMask;

		public void SetPosition(Transform _parent, float _radius)
		{
			GetComponent<Rigidbody>().isKinematic = true;
			isTarget = true;
			transform.SetParent(_parent);
			targetPos = new Vector3(transform.position.x,
				_parent.position.y + Random.Range(.3f, 1f),
				transform.position.z);
			targetPos = _parent.InverseTransformPoint(targetPos);
			targetRot = Quaternion.Euler(Random.Range(0, 360),
				Random.Range(0, 360),
				Random.Range(0, 360));
			targetPos.y = _parent.position.y + 1f;
			StartCoroutine(Co_MovePostion());
		}

		IEnumerator Co_MovePostion()
		{
			while (transform.localPosition != targetPos)
			{
				//Debug.Log(1);
				transform.localPosition = Vector3.MoveTowards(
					transform.localPosition,
					targetPos, speed * Time.deltaTime);
				transform.rotation = Quaternion.RotateTowards(transform.rotation,
					targetRot, speed2 * Time.deltaTime);

				yield return null;
			}

			while (true)
			{
				transform.Rotate(Vector3.right * 270 * Time.deltaTime);
				yield return null;
			}
		}

		public void Shoot(Vector3 _forward)
		{
			transform.SetParent(null);
			StartCoroutine(Co_Shoot(_forward));
		}

		IEnumerator Co_Shoot(Vector3 _forward)
		{
			while (true)
			{
				float _distance = shootSpeed * Time.deltaTime;
				transform.Translate(_forward * _distance, Space.World);

				if (Physics.Raycast(transform.position, _forward, _distance, layerMask, QueryTriggerInteraction.Collide))
				{
					for (int i = 0; i < 3; i++)
					{
						ParticleSystem _ps = PoolManager.ins.Instantiate("ShellExplosion", transform.position + Random.insideUnitSphere * .2f, Quaternion.identity).GetComponent<ParticleSystem>();
						_ps.Stop();
						_ps.Play();
					}
					//Destroy(gameObject);
					gameObject.SetActive(false);
					yield break;
				}
				yield return null;
			}
		}
	}
}