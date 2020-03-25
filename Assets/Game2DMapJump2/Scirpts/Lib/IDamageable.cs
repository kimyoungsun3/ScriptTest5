using UnityEngine;

namespace DMapJump2
{
	public interface IDamageable {
		void TakeHit(int _damage, Vector3 _hitPoint, Vector3 _hitDirection);
		void TakeDamage(int _damage);
	}
}