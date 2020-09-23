using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
	public class SnakeHeader2 : MonoBehaviour
	{
		public float speed = 3.5f;
		public float speedTurn = 50f;
		float turnDir = 0f;
		[Range(1f, 10f)] public float damping;
		public List<Transform> list = new List<Transform>();
		Vector3 dummySpeed;
		public float distance = 1f;
		public float tailSize = .8f;

		Plane ground;
		Ray ray;
		float hitDistance;
		Camera camera;

		private void Start()
		{
			ground = new Plane(Vector3.forward, Vector3.zero);
			camera = Camera.main;
		}

		private void Update()
		{
			InputMousePoint();

			//list[0].position = transform.position;
			//list[0].rotation = transform.rotation;
			for (int i = 1; i < list.Count; i++)
			{
				Vector3 _dir = list[i - 1].position - list[i].position;
				if (_dir.magnitude > distance)
				{
					list[i].position = Vector3.Lerp(list[i].position, list[i - 1].position, damping * Time.deltaTime);
					if (_dir != Vector3.zero)
						list[i].rotation = Quaternion.LookRotation(_dir);
				}
			}


		}

		void InputKeyBoard()
		{
			if (Input.GetKey(KeyCode.W))
				transform.Translate(Vector3.up * speed * Time.deltaTime);

			if (Input.GetKey(KeyCode.A)) turnDir = +1f;
			else if (Input.GetKey(KeyCode.D)) turnDir = -1f;
			else turnDir = 0f;
			transform.Rotate(Vector3.forward * turnDir * speedTurn);
		}

		void InputMousePoint()
		{
			if (Input.GetMouseButton(0))
			{
				ray = camera.ScreenPointToRay(Input.mousePosition);
				if (ground.Raycast(ray, out hitDistance))
				{
					Vector3 _hitPoint = ray.GetPoint(hitDistance);
					Vector3 _dirction = _hitPoint - transform.position;
					_dirction.z = 0f;

					transform.rotation = Quaternion.LookRotation(_dirction);
					transform.Translate(Vector3.forward * speed * Time.deltaTime);
				}
			}
		}

		private void OnTriggerEnter(Collider _other)
		{
			if (_other.CompareTag("Coin"))
			{
				_other.transform.SetParent(null);
				Destroy(_other.GetComponent<Collider>());

				_other.transform.localScale *= tailSize;
				list.Add(_other.transform);
			}
		}
	}
}