using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SurfaceMove2 : MonoBehaviour {
	public LayerMask mask;
	public float speed = 3f, speedTurn = 180f;
	public float distance = 2f;
	public SurfaceBullet bulletPrefab;
	public Transform spawn;
	public float intervalTime = 0.3f;
	float nextTime;
	Ray ray;
	RaycastHit hit;
	Transform trans;
	//Vector3 move;
	float h, v;
	int count;
	//Vector3 scale;
	//float angleY;
	Rigidbody rigidbody;

	void Start () {
		trans = transform;
		//scale = trans.lossyScale;
		nextTime = 0;
		rigidbody = GetComponent<Rigidbody> ();


		Debug.Log (Vector3.Cross (Vector3.right, Vector3.up));
		Debug.Log (Vector3.Cross (Vector3.up, Vector3.right));
		
	}

	void Update () {
		h = Input.GetAxisRaw ("Horizontal");
		v = Input.GetAxisRaw ("Vertical");
		//h = 1;
		//v = 1;

		//move, rotate -> ch
		//move...
		if (v != 0) {
			trans.Translate (v * Vector3.forward * speed * Time.deltaTime);
		}	

		//Rotate...
		if (h != 0) {
			trans.Rotate (h * Vector3.up * speedTurn * Time.deltaTime);
		}

		ray.direction = -trans.up;
		ray.origin = trans.position;
		//angleY = trans.eulerAngles.y;

		//Debug.Log ("----------------");
		//Debug.Log("----------------"+ Physics.Raycast(ray, out hit, distance, mask));
		if(Physics.Raycast(ray, out hit, distance, mask)){
			trans.position = hit.point;
			//trans.rotation = Quaternion.FromToRotation (trans.up, hit.normal);	// 이상함...
			//trans.rotation = Quaternion.FromToRotation (Vector3.up * trans.eulerAngles.y, hit.normal);

			//trans.rotation = Quaternion.FromToRotation (Vector3.up, hit.normal);	//방향은 맞는데... 회전하면...

			//이동... 회전 ... 어느순가 이상함....
			//angleY = trans.eulerAngles.y;
			//trans.rotation = Quaternion.FromToRotation (Vector3.up, hit.normal);
			//trans.Rotate (Vector3.up * angleY);

			//Surface move
			//trans.rotation = Quaternion.FromToRotation (Vector3.up, hit.normal) * trans.rotation;	//이상함...
			//trans.rotation = Quaternion.FromToRotation (trans.up, hit.normal);	//이상함...
			trans.rotation = Quaternion.FromToRotation (trans.up, hit.normal) * trans.rotation;
			//Debug.Log (hit.point);
		}	

		if (Time.time > nextTime){
		//if (Time.time > nextTime && Input.GetKey (KeyCode.Space)) {
			nextTime = Time.time + intervalTime;
			SurfaceBullet _bullet = Instantiate (bulletPrefab, spawn.position, spawn.rotation) as SurfaceBullet;
			_bullet.Init ();
			_bullet.name += count++;
		}

		//잔여 물리 에너지를 클리어 해준다...
		//if (h == 0 && v == 0 && rigidbody.velocity != Constant.V3_ZERO) {
			rigidbody.velocity = Constant.V3_ZERO;
			rigidbody.angularVelocity = Constant.V3_ZERO;
		//}
	}

	void OnDrawGizmos(){
		if (hit.collider != null) {
			Gizmos.color = Color.red;
			Gizmos.DrawCube (hit.point, Vector3.one * 0.1f);
		}
	}
}
