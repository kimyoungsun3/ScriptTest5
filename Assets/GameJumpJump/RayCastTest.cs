using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TTTTT2
{
	public class RayCastTest : MonoBehaviour
	{
		
		public float distance = 2f;
		Material material;
		private void OnDrawGizmos()
		{
			Ray _ray = new Ray (transform.position, transform.right);
			RaycastHit _hit;
			Gizmos.DrawRay(_ray.origin, _ray.direction * distance);
			if (Physics.Raycast(_ray, out _hit, distance))
			{
				material = _hit.collider.GetComponent<Renderer>().material;
				material.color = Color.red;
			}
			else if(material != null)
			{
				material.color = Color.white;
				material = null;
			}
		}
	}
}