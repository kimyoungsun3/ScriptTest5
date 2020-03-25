using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AddUnitTest
{
	public class UnitMontor : MonoBehaviour
	{
		Transform trans;
		Camera cam;
		float distance = 100f;
		[SerializeField] LayerMask maskGrasp;
		UnitItem scpTarget;
		Vector3 offset;
		Plane plane;
		Vector3 beforePos;

		void Start()
		{
			Application.targetFrameRate = 55;
			if (cam == null)
				cam = Camera.main;
			plane = new Plane(-cam.transform.forward, Vector3.zero);
		}

		void Update()
		{
			//if (Input.GetMouseButtonDown(1))
			//{
			//	Debug.Log(11);
			//	List<UnitItem> _list = UnitItem.list;
			//	for(int i = 0, iMax = _list.Count; i < iMax; i++)
			//	{
			//		Destroy(_list[i].gameObject);
			//	}
			//	_list.Clear();
			//}

			if (Input.GetMouseButtonDown(0))
			{
				//Debug.Log(11);
				Ray _ray = cam.ScreenPointToRay(Input.mousePosition);
				RaycastHit _hit;
				Debug.DrawRay(_ray.origin, _ray.direction * distance, Color.blue);

				if (Physics.Raycast(_ray, out _hit, distance, maskGrasp, QueryTriggerInteraction.Collide))
				{
					//Debug.Log(12);
					scpTarget = _hit.collider.GetComponent<UnitItem>();
					scpTarget.SetOrder(eUnitSelect.Select);
					if (scpTarget != null)
					{
						//Debug.Log(13);
						offset		= _hit.point - scpTarget.transform.position;
						beforePos	= scpTarget.transform.position;
					}
				}
			}

			if (scpTarget && Input.GetMouseButton(0))
			{
				Ray _ray = cam.ScreenPointToRay(Input.mousePosition);
				RaycastHit _hit;
				float _distance;
				if (plane.Raycast(_ray, out _distance))
				{
					Vector3 _hitPoint2 = _ray.GetPoint(_distance);
					scpTarget.transform.position = _hitPoint2 - offset;
					//scpTarget.transform.position.z = 0;
					Debug.DrawLine(scpTarget.transform.position, _hitPoint2, Color.green);
				}
			}

			if (scpTarget && Input.GetMouseButtonUp(0))
			{
				scpTarget.CheckArea();
				scpTarget = null;
			}
		}
	}
}