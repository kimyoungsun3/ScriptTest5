using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceBullet : MonoBehaviour {
	public LayerMask maskMove, maskBomb, maskEnemy;
	int maskEnemyLayer;
	public float speed = 30f;
	Ray rayDown, rayForward;
	RaycastHit hit;
	Transform trans;
	float distance = 100f;
	float moveDistance, deltaMove;
	public float moveMax = 30;

	void Awake(){
		trans = transform;	
		maskEnemyLayer = (int)Mathf.Log (maskEnemy.value, 2);
		//Debug.Log (maskEnemyLayer);
	}

	//void Start(){
	//	Init ();
	//}

	public void Init(){
		moveDistance = 0;
		Collider[] _cols = Physics.OverlapSphere (trans.position, .5f, maskBomb);
		if (_cols.Length > 0) {
			if (_cols [0].gameObject.layer == maskEnemyLayer) {
				Destroy (_cols [0].gameObject);
			}
			Destroy(gameObject);
		}
		Debug.DrawRay (trans.position, trans.forward * .5f, Color.red);
	}

	void Update () {
		rayForward.origin 		= trans.position;
		rayForward.direction 	= trans.forward;
		deltaMove = speed * Time.deltaTime;
		moveDistance += deltaMove;
		if (moveDistance > moveMax) {
			Destroy (gameObject);
			return;
		}

		//1. 이동 -> 검사...
		trans.Translate (Vector3.forward * deltaMove);

		//2. 검사방향...
		rayDown.origin 		=  trans.position;
		rayDown.direction 	= -trans.up;
		if(Physics.Raycast(rayDown, out hit, distance, maskMove)){
			trans.position = hit.point;
			trans.rotation = Quaternion.FromToRotation (trans.up, hit.normal) * trans.rotation;
			//Debug.Log (hit.point);
		}

		//새로운 상태에서 총알 움직일 거리 만큼에서 충돌시....
		#if UNITY_EDITOR
			//Debug.DrawRay(trans.position, trans.forward * deltaMove, Color.white);
			Debug.DrawRay(rayForward.origin, rayForward.direction * deltaMove, Color.green);
		#endif
		if (Physics.Raycast (rayForward, out hit, deltaMove, maskBomb, QueryTriggerInteraction.Collide)) {
			if (hit.collider.gameObject.layer == maskEnemyLayer) {
				Destroy (hit.collider.gameObject);
			}
			Destroy (gameObject);
		}
	}
}
