using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController21 : MonoBehaviour {
	public float speedMove = 5f;
	public float speedRun = 7f;
	Vector2 input;
	bool bMoveForward, bRun;
	float h,v, speed;
	Vector3 eulerAngles, dir;
	public Bullet2 bullet;
	public Transform[] spawnPoint;

	void Start(){
		speed = speedMove;
	}

	void Update () {
		v = Input.GetAxisRaw ("Vertical");
		h = Input.GetAxisRaw ("Horizontal");
		dir = Constant.V3_FORWARD;

		//auto forward...
		if (Input.GetKeyDown (KeyCode.Tab)) {
			bMoveForward = !bMoveForward;
		} else if (Input.GetKeyDown (KeyCode.Comma)) {
			bRun = !bRun;
			speed = bRun ? speedRun : speedMove;
		} else if (v != 0) {
			eulerAngles = transform.eulerAngles;
			eulerAngles.y = Camera.main.transform.eulerAngles.y;
			transform.eulerAngles = eulerAngles;
		} else if (h != 0) {
			//side move -> left, right
			v = 1;
			dir = Constant.V3_RIGHT * (h < 0 ? -1 : +1);
			if (Input.GetMouseButton (1)) {
				//side + 우클릭...
				eulerAngles = transform.eulerAngles;
				eulerAngles.y = Camera.main.transform.eulerAngles.y;
				transform.eulerAngles = eulerAngles;
			}
		} else if (v < 0) {
			bMoveForward = false;
		}


		//-----------------------
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			Bullet2 _bullet = Instantiate (bullet, spawnPoint[0].position, spawnPoint[0].rotation) as Bullet2;
			//_bullet.transform.SetParent ();
			_bullet.Init ();
		}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			Bullet2 _bullet;
			for (int i = 0, iMax = spawnPoint.Length; i < iMax; i++) {
				_bullet = Instantiate (bullet, spawnPoint [i].position, spawnPoint [i].rotation) as Bullet2;
				//_bullet.transform.SetParent ();
				_bullet.Init ();
			}			
		}

		if (bMoveForward) {
			v = 1;
		}	

		transform.Translate ( v * dir * speed * Time.deltaTime);
	}
}
