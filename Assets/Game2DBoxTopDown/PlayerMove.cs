using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;

namespace Game2DBoxTopDown
{
	public class PlayerMove : MonoBehaviour
	{
		Vector3 move;
		Transform trans;
		Camera cam;
		[SerializeField] float speed = 3f;		
		[SerializeField] Transform spawnPoint;
		[SerializeField] float NEXT_SHOOT = 0.2f;
		float nextShoot;

		void Start()
		{
			trans = transform;
			cam = Camera.main;
		}

		// Update is called once per frame
		void Update()
		{
			move.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
			trans.Translate(move.normalized * speed * Time.deltaTime, Space.World);
			//대각선 이동에서 문제가 있어서 normalized 해둠...

			Vector3 _point = cam.ScreenToWorldPoint(Input.mousePosition);
			Vector3 _dir = _point - trans.position;
			Quaternion _rot = LookRotation2D(_dir);
			trans.rotation = _rot;

			if (Time.time > nextShoot && Input.GetMouseButton(0))
			{
				//Debug.Log(" >>");
				nextShoot = Time.time + NEXT_SHOOT;
				PoolManager.ins.Instantiate("Bullet2D", spawnPoint.position, _rot);
			}
		}

		Quaternion LookRotation2D(Vector3 _dir)
		{
			float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
			return Quaternion.Euler(Vector3.forward * _angle);
		}
	}
}