using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public int damage = 1;
	public float speed = 10f;
	public LayerMask mask;
	public float moveLimit = 100f;

	GameObject gameo;
	Transform trans;
	Ray ray;
	RaycastHit hit;
	float plusCheckRadius = .1f;
	float moveDistance, moveTotal;
	Coroutine cor;

	//void Start () {
	//}

	public void SetSpeedAndShoot(float _speed, int _damage){
		speed = _speed;
		damage = _damage;

		if (trans == null) {
			trans = transform;
			gameo = gameObject;
		}

		if (cor != null) {
			StopCoroutine (cor);
		}
		cor = StartCoroutine (BulletMove());
	}

	IEnumerator BulletMove () {
		moveTotal = 0;
		while (moveTotal < moveLimit) {
			moveDistance = speed * Time.deltaTime + plusCheckRadius;
			moveTotal += moveDistance;

			//Debug.Log (trans);
			ray.origin = trans.position;
			ray.direction = trans.forward;
			if(Physics.Raycast(ray, out hit, moveDistance, mask, QueryTriggerInteraction.Collide)){
				OnHitOjbect(hit.collider, hit.point);
				break;
			}
			trans.Translate (Vector3.forward * moveDistance);
			yield return null;
		}

		OnDestory ();
	}

	void OnHitOjbect(Collider _col, Vector3 _point){
		IDamageable _scp = _col.GetComponent<IDamageable> ();
		if (_scp != null) {
			_scp.TakeHit (damage, _point, trans.forward);
		}
		//OnDestory ();
	}

	void OnDestory(){
		gameo.SetActive (false);
	}
}
