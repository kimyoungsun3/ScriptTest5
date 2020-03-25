using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectObjectXY
{
	public enum eArrayType { Normal, Reflect}
	public class Arraw : MonoBehaviour
	{


		Transform trans;
		[SerializeField] LayerMask layerMask;
		[SerializeField] LayerMask layerEnemy;
		[SerializeField] float speed = 5f;
		Ray ray;
		RaycastHit hit;
		[SerializeField] eArrayType arrayType;
		System.Action onUpdate;

		private void Start()
		{
			trans = transform;
			switch (arrayType)
			{
				case eArrayType.Normal:		onUpdate = OnUpdate_Normal;		break;
				case eArrayType.Reflect:	onUpdate = OnUpdate_Reflect;	break;
			}
		}

		void OnUpdate_Normal()
		{
			ray.origin = trans.position;
			ray.direction = trans.right;
			Vector3 _deltaPos = trans.right * speed * Time.deltaTime;
			float _distance = _deltaPos.magnitude;

			if (Physics.Raycast(ray, out hit, _distance, layerMask))
			{
				Vector3 _deltaPos2 = ray.origin - hit.point;
				float _distance2 = _deltaPos2.magnitude;
				Vector3 _reflect = Vector3.Reflect(ray.direction, hit.normal).normalized;

				trans.position = hit.point + (_distance - _distance2) * _reflect;
				trans.rotation = Util.GetQuaternionFromDir2D(trans.position - hit.point);
			}
			else
			{
				trans.Translate(_deltaPos, Space.World);
			}
		}

		void OnUpdate_Reflect()
		{
			ray.origin		= trans.position;
			ray.direction	= trans.right;
			Vector3 _deltaPos	= trans.right * speed * Time.deltaTime;
			float _distance		= _deltaPos.magnitude;

			if (Physics.Raycast(ray, out hit, _distance, layerMask))
			{
				int _layer =(int) Mathf.Pow(2, hit.collider.gameObject.layer);
				//Debug.Log(_layer + ":" + layerEnemy.value);
				if (_layer == layerEnemy.value)
				{
					Debug.Log(" effect, hp 감소");
					gameObject.SetActive(false);
				}
				else
				{
					Vector3 _deltaPos2 = ray.origin - hit.point;
					float _distance2 = _deltaPos2.magnitude;
					Vector3 _reflect = Vector3.Reflect(ray.direction, hit.normal).normalized;

					trans.position = hit.point + (_distance - _distance2) * _reflect;
					trans.rotation = Util.GetQuaternionFromDir2D(trans.position - hit.point);
				}
			}
			else
			{
				trans.Translate(_deltaPos, Space.World);
			}
		}

		void Update()
		{
			if(onUpdate != null)
			{
				onUpdate();
			}

		}

	}
}