using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TTTTT2
{
	public class RayCastTest2 : MonoBehaviour
	{
		public LayerMask mask;
		public float distance = 2f;
		SpriteRenderer spriteRenderer;
		private void OnDrawGizmos()
		{
		
			Ray _ray = new Ray (transform.position, transform.right);
			RaycastHit2D _hit;
			Gizmos.DrawRay(_ray.origin, _ray.direction * distance);
			_hit = Physics2D.Raycast(_ray.origin, _ray.direction, distance, mask);
			if (_hit)
			{
				spriteRenderer = _hit.collider.GetComponent<SpriteRenderer>();
				spriteRenderer.color = Color.red;
			}
			else if(spriteRenderer != null)
			{
				spriteRenderer.color = Color.white;
				spriteRenderer = null;
			}
		}
	}
}