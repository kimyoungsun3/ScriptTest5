using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump3D_01{
	[RequireComponent(typeof(CharacterController))]
	public class PlayerMotor2 : MonoBehaviour {
		public float gravity 	= -9.81f;
		float gravity2 = -9.81f;
		public float jumpForce 	= 10f;
		public float moveSpeed 	= 3f;
		public float turnSpeed = 180f;
		public LayerMask layerMask;
		public float radius = 3f;
		public float gravityTime = .2f;
		public Transform body;
		public List<GrapObject> list = new List<GrapObject>();
		//public float checkRadius = 0.01f;
		//public Transform transCheckPoint;
		//public LayerMask checkMask;
		CharacterController controller;
		Vector3 velocity;
		//bool bGround;


		void Start () {
			controller = GetComponent<CharacterController> ();
			//if (transCheckPoint == null) {
			//	transCheckPoint = transform.Find ("CheckPoint");
			//}
		}


		void Update () {
			//x
			//bGround = Physics.CheckCapsule(transform.position, transCheckPoint.position, checkRadius, checkMask);
			//x
			//bGround = Physics.Linecast(transform.position, transCheckPoint.position, checkMask);
			//x
			//bGround = Physics.Raycast(transform.position, -transform.up, checkRadius, checkMask);
			//Debug.Log (controller.isGrounded + ":" + bGround);

			if (Input.GetMouseButtonDown(1))
			{
				Collider[] _cols = Physics.OverlapSphere(transform.position, radius, layerMask);
				for(int i = 0, imax = _cols.Length; i < imax; i++)
				{
					GrapObject _scp = _cols[i].GetComponent<GrapObject>();
					if(_scp != null  && _scp.isTarget == false)
					{
						_scp.SetPosition(transform, radius);
						list.Add(_scp);
					}
				}
				gravity = 0f;
				StartCoroutine(Co_Cloud());
			}
			else if (Input.GetMouseButtonDown(0))
			{
				if(list.Count > 0)
				{
					list[0].Shoot(transform.forward);
					list.RemoveAt(0);
				}

				if(list.Count <= 0)
					isCloud = false;
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				gravity = 0f;
				StartCoroutine(Co_Cloud());
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				isCloud = false;
			}


			velocity.y += gravity * Time.deltaTime;
			if (controller.isGrounded && Input.GetButtonDown ("Jump")) {
				velocity.y = jumpForce;
			}


			//1. 이동방향...
			velocity.Set (0, velocity.y, Input.GetAxisRaw ("Vertical") * moveSpeed);

			//2. 회전하기...
			transform.Rotate(Vector3.up * Input.GetAxisRaw ("Horizontal") * turnSpeed * Time.deltaTime);

			//3. 회전방향으로 이동...
			controller.Move (transform.rotation * velocity * Time.deltaTime);
			
		}

		bool isCloud;
		IEnumerator Co_Cloud()
		{
			isCloud = true;
			float _time = gravityTime;
			while (_time > 0f)
			{
				velocity.y = jumpForce;
				_time -= Time.deltaTime;
				yield return null;
			}
			velocity.y = 0;

			Vector3 _axis = new Vector3(45, 0, 45);
			while (isCloud)
			{
				body.Rotate(_axis * 1f * Time.deltaTime, Space.World);
				yield return null;
			}

			gravity = gravity2;
			body.localRotation = Quaternion.identity;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, radius);
		}
	}
}