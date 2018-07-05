using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
	public bool bAuto;
	public float speedTurn = 90f;

	public Bullet bulletPrefab;
	public Transform spawn;

	public delegate void VOID_FUN_VOID ();
	public VOID_FUN_VOID callback;
	public Text lvCount;

	int count = 1;
	void Update () {
		transform.Rotate (Vector3.up * speedTurn * Time.deltaTime);

		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetMouseButtonDown(0)) {
			if (callback != null) {
				callback ();
				callback = null;
			}
			count = 0;
		}else if (Input.GetKey (KeyCode.Space) || bAuto) {
			Bullet _bullet = Instantiate (bulletPrefab, spawn.position, spawn.rotation) as Bullet;
			//_bullet.transform.SetParent (spawn);
			callback += _bullet.OnDestroy;
			_bullet.boss = this;

			_bullet.name += count++;
		}

		lvCount.text = "" + count;
	}
}
