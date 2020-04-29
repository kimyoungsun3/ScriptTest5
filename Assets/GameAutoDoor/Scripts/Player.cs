using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameShoot
{
	public class Player : MonoBehaviour
	{

		[SerializeField] float speed = 2f;
		[SerializeField] float speedTurn = 180f;
		Transform trans;
		Vector3 move;
		float mouseX, mouseY;
		[SerializeField] float SHOOT_PER_COUNT = 4.5f;
		float shootSpeed;
		float shootTime;
		[SerializeField] LayerMask mask;
		[SerializeField] Transform spawnPoint;
		[SerializeField] Transform spawnPointBody;
		[SerializeField] Transform cameraRig;
		Vector3 spawnPointPos, spawnPointPos2;
		Action onClear;

		public List<Bullet> list = new List<Bullet>();
		Bullet bullet;
		[SerializeField] ParticleSystem bulletEffect;

		// Use this for initialization
		void Start()
		{
			shootSpeed = 1f / SHOOT_PER_COUNT;
			trans = transform;
			bullet = list[0];
			spawnPointPos = spawnPointBody.localPosition;
			spawnPointPos2 = spawnPointBody.localPosition - Vector3.forward * .5f;
		}

		// Update is called once per frame
		void Update()
		{
			float _h = Input.GetAxisRaw("Horizontal");
			float _v = Input.GetAxisRaw("Vertical");
			move.Set(_h, 0, _v);
			if (Input.GetMouseButton(1))
			{
				mouseX = Input.GetAxis("Mouse X");
				mouseY = Input.GetAxis("Mouse Y");
			}
			else
			{
				mouseX = 0;
				mouseY = 0;
			}
			

			if (Input.GetMouseButton(0) && Time.time > shootTime)
			{
				shootTime = Time.time + shootSpeed;
				bool _b = Physics.CheckSphere(spawnPoint.position, 0.1f, mask, QueryTriggerInteraction.Ignore);
				if (!_b)
				{
					Bullet _bullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation) as Bullet;
					_bullet.SetData(this);
					onClear += _bullet.OnThisClear;
				}
				//파티클 생성하고 일정 시간후에 소멸...
				//ParticleSystem _ps = Instantiate(bulletEffect, spawnPoint.position, spawnPoint.rotation) as ParticleSystem;
				//_ps.Stop();
				//_ps.Play();
				//Destroy(_ps.gameObject, _ps.main.duration);

				//CameraController.ins.ShakeUp();
				//onClear += _bullet.OnThisClear;
				ShakeGun();
			}

			ReWindGun();

			if (Input.GetKeyDown(KeyCode.C) && onClear != null)
			{
				onClear();
				onClear = null;
			}
		}

		void ShakeGun()
		{
			spawnPointBody.localPosition = spawnPointPos2;
		}

		void ReWindGun()
		{
			spawnPointBody.localPosition = Vector3.Lerp(spawnPointBody.localPosition, spawnPointPos, Time.deltaTime);
		}

		private void FixedUpdate()
		{
			if (move.x != 0f || move.z != 0f)
			{
				trans.Translate(move.normalized * speed * Time.deltaTime);
			}

			if (mouseX != 0f)
				trans.Rotate(mouseX * Vector3.up * speedTurn * Time.deltaTime);

			if (mouseY != 0f)
				cameraRig.Rotate(-mouseY * Vector3.right * speedTurn * Time.deltaTime);
		}

		public void ClearAction(Bullet _bullet)
		{
			onClear -= _bullet.OnThisClear;
		}
	}
}