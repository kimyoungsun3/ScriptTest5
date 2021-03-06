﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PM1{
	public class PlayerShootTest : MonoBehaviour {
		public GameObject prefab;
		public float rotateSpeed = 90f;
		public float aliveTime = 2f;
		// Update is called once per frame
		void Update () {
			transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
			if (Input.GetKey (KeyCode.Alpha1)) {
				GameObject _go = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
				//Bullet _scp = _go.GetComponent<Bullet> ();
				//if (_scp != null) {
				//	_scp.SetSpeed (10);
				//}
				//_go.transform.SetParent (transform);
				Destroy (_go, aliveTime);
			} else if (Input.GetKey (KeyCode.Alpha2)) { 
				GameObject _go = PoolManager.ins.Instantiate("Bullet2", transform.position, transform.rotation);
				//Bullet _scp = _go.GetComponent<Bullet> ();
				//if (_scp != null) {
				//	_scp.SetSpeed (10);
				//}
			} else if (Input.GetKey (KeyCode.Alpha3)) { 
				GameObject _go = PoolManager.ins.Instantiate("Bullet3", transform.position, transform.rotation);

			} else if (Input.GetKey (KeyCode.Alpha4)) { 
				GameObject _go = PoolManager.ins.Instantiate("Bullet4", transform.position, transform.rotation);

			} else if (Input.GetKey (KeyCode.Alpha5)) { 
				GameObject _go = PoolManager.ins.Instantiate("Bullet5", transform.position, transform.rotation);

			}
		}
	}
}