using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest3{
	public class PlayerMove : MonoBehaviour, IDamageable{
		public float speed = 3f;
		Transform trans;
		GameObject gameo;
		Vector3 move;
		public int health;
		protected bool isDead;
		public System.Action callbackDeath;

		void Start () {
			trans = transform;
			gameo = gameObject;
		}

		void Update () {
			move.Set (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
			move = move.normalized * speed * Time.deltaTime;
			trans.Translate(move, Space.World);
		}

		public void TakeHit(int _damage, Vector3 _hitPoint, Vector3 _hitDirection){
			TakeDamage (_damage);
		}

		public void TakeDamage(int _damage){
			health -= _damage;
			if (health <= 0 && !isDead) {
				Die ();
			}
		}

		[ContextMenu("Self Destroy")]
		public void Die(){
			isDead = true;
			if (callbackDeath != null) {
				callbackDeath ();
				callbackDeath = null;
			}
			gameObject.SetActive (false);
		}
	}
}