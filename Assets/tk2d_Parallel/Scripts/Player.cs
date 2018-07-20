using UnityEngine;
using System.Collections;

namespace tk2d_parallel{
	public class Player : MonoBehaviour {
		Transform trans;
		public float moveSpeed = 1f;
		public tk2dSpriteAnimator animator;
		//Vector3 moveDir;
		float z;
		[HideInInspector]public bool bDie = false;

		void Start () {
			trans = transform;
			z = trans.position.z;
		}
		
		// Update is called once per frame
		void Update () {
			if (bDie) 
			{
				return;
			}

			//moveDir.Set (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), z);
			//moveDir.Normalize();
			trans.Translate (Vector3.right * moveSpeed * Time.deltaTime);
		}

		void OnTriggerEnter2D(Collider2D _col){
			Debug.Log (this + _col.name);
			if (_col.CompareTag ("Enemy")) {
				animator.Play ("die");
				animator.AnimationCompleted = delegate(tk2dSpriteAnimator arg1, tk2dSpriteAnimationClip arg2) {
					Destroy(gameObject);
				};
				bDie = true;
			}
		}

		//void OnDieAnimationEnd(tk2dUISpriteAnimator _ani, tk2dSpriteAnimationClip _clip){

		//}
	}
}
