using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionContactPoint
{
	public class ParticleContactPoint : MonoBehaviour
	{
		public ParticleSystem particles;
		//private void OnCollisionEnter(Collision _collision)
		//{
		//	foreach(ContactPoint _contact in _collision.contacts)
		//	{
		//		GameObject _particle = Instantiate(
		//			particles.gameObject, 
		//			_contact.point, 
		//			Quaternion.LookRotation(_contact.normal));
		//		Destroy(_particle, 2f);
		//	}
		//}

		private void OnCollisionEnter(Collision _col)
		{
			foreach (ContactPoint _contact in _col.contacts)
			{
				ParticleSystem _ps = Instantiate(particles,
					_contact.point,
					Quaternion.LookRotation(_contact.normal));

				Destroy(_ps.gameObject, _ps.main.duration);
			}
		}
	}
}