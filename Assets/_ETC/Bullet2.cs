using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour {
	public LayerMask maskEnemy;
	public float speed = 30f;
	Ray rayForward;
	RaycastHit hit;
	Transform trans;
	float moveDistance, deltaMove;
	public float moveMax = 30;

	void Awake(){
		trans = transform;	
	}

	public void Init(){
		moveDistance = 0;
		Collider[] _cols = Physics.OverlapSphere (trans.position, .5f, maskEnemy);
		if (_cols.Length > 0) {
			Destroy(gameObject);
		}
	}

	void Update () {
		rayForward.origin 		= trans.position;
		rayForward.direction 	= trans.forward;
		deltaMove = speed * Time.deltaTime;
		moveDistance += deltaMove;
		if (moveDistance > moveMax) {
			Destroy (gameObject);
		}

		//0. 검사...
		//새로운 상태에서 총알 움직일 거리 만큼에서 충돌시....
		#if UNITY_EDITOR
			Debug.DrawRay(rayForward.origin, rayForward.direction * deltaMove, Color.green);
		#endif
		if (Physics.Raycast (rayForward, out hit, deltaMove, maskEnemy, QueryTriggerInteraction.Collide)) {
			//Destroy (hit.collider.gameObject);
			Destroy (gameObject);
		}

		//1. 이동 -> 
		trans.Translate (Vector3.forward * deltaMove);

	}
}
