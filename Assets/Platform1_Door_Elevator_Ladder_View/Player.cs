﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform_Door_Elevator
{
	[RequireComponent(typeof(Rigidbody))]
	public class Player : MonoBehaviour
	{
		[SerializeField] float speed = 2f;
		[SerializeField] float jumpPower = 100f;
		Transform trans;
		Rigidbody rigidbody;
		float h, v;
		bool bJump, isJumping;

		//사다리중...
		[SerializeField] KeyCode keyUp		= KeyCode.R;
		[SerializeField] KeyCode keyDown	= KeyCode.F;
		bool bLadder;
		float upDown;
		RigidbodyConstraints rigidbodyConstrainstsOrg;

		//카메라 모드
		CameraRig cameraRig;
		[SerializeField] eCamearView cameraType;


		void Start()
		{
			trans		= transform;
			rigidbody	= GetComponent<Rigidbody>();
			rigidbodyConstrainstsOrg = rigidbody.constraints;
			cameraRig	= GetComponentInChildren<CameraRig>();
			if(cameraType != eCamearView.None)
				cameraRig.SetToCameraView(cameraType);
		}

		private void Update()
		{
			h		= Input.GetAxisRaw("Horizontal");
			v		= Input.GetAxisRaw("Vertical");
			bJump	= Input.GetButtonDown("Jump");

			if (Input.GetKey(keyUp))
			{
				upDown = 1;
			}
			else if (Input.GetKey(keyDown))
			{
				upDown = -1;
			}
			else
			{
				upDown = 0;
			}
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			float _h = h;
			float _v = v;
			bool _bJump = bJump;
			h = v = 0;
			bJump = false;

			//상하좌우....
			if (_h != 0 || _v != 0)
			{
				trans.Translate(new Vector3(_h, 0, _v).normalized * speed * Time.deltaTime);
			}

			//사다리 타기중...
			if (bLadder && upDown != 0)
			{
				//Debug.Log(bLadder + ":" + upDown);
				trans.Translate(upDown * Vector3.up * speed * Time.deltaTime);
			}

			//점프하기..
			if (_bJump && !isJumping)
			{
				isJumping = true;
				rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
			}
		}


		public void SetToCameraView(eCamearView _type)
		{
			Debug.Log("카메라 모드시도:" + _type);
			if (cameraType == _type) return;
			Debug.Log(" >> 변경한다...");
			cameraType = _type;
			cameraRig.SetToCameraView(_type);
		}


		public void SetLadder(bool _bLadder)
		{
			bLadder = _bLadder;
			//Debug.Log(this + " SetLadder " + _bLadder);

			//사다리 등반... >> kinematic 
			//				--> 음... 통과버그....
			//rigidbody.isKinematic = _bLadder;

			//중력제거... >> 오르거나 내리기, 
			//               떨어질때는 가속도가 적용되어서 자연스러움.
			rigidbody.useGravity = !_bLadder;

			//y가 중력 적용을 제거...>> 상단으로 올라갈때 약간 부자연스러운 부분이 있다..
			//if(_bLadder)
			//	rigidbody.constraints = rigidbodyConstrainstsOrg | RigidbodyConstraints.FreezePositionY;
			//else
			//	rigidbody.constraints = rigidbodyConstrainstsOrg;
		}

		private void OnCollisionEnter(Collision _col)
		{
			if (_col.gameObject.CompareTag("Ground"))
			{
				isJumping = false;
			}
		}
	}
}