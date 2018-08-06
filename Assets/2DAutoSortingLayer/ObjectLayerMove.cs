using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[ExecuteInEditMode]
public class ObjectLayerMove : ObjectLayer {
	Rigidbody2D rb2D;
	public string sortingLayerName = "";

	void Start(){
		render = GetComponent<SpriteRenderer> ();
		//render.sortingLayerName = sortingLayerName;

		//강체를 강제로 캐릭터처럼 만듬...
		rb2D = GetComponent<Rigidbody2D> ();
		rb2D.gravityScale = 0f;
		rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;


	}

	void Update(){
		if (render != null) {
			render.sortingOrder = -(int)(transform.position.y * 100f);
		}
	}

	//void OnCollisionEnter2D(Collision2D _col){
	//	//
	//}

	void OnCollisionExit2D(Collision2D _col){		
		if (rb2D.velocity != Vector2.zero) {
			rb2D.velocity = Vector2.zero;
		}
	}
}
