using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Snake
{
	public class SnakeHeader3 : MonoBehaviour
	{
		[SerializeField] float speed = 5f;
		[SerializeField] [Range(0, 1f)] float speedNotClickPercent = .3f;
		//public float speedTurn = 400f;
		//private float turnDir = 0f;
		//public Transform header;
		[Range(.1f, 10f)] public float distance = .5f;
		public List<Transform> list = new List<Transform>();
		//[Range(0.01f, 1f), SerializeField] float duration = 0.5f;
		//private Vector3 dummySpeed;
		public float tailSize = .8f;
		public float speedTailAdd = 5f;


		Plane ground;
		Ray ray;
		float hitDistance;
		Camera camera;
		// Use this for initialization
		void Start()
		{
			ground = new Plane(Vector3.forward, Vector3.zero);
			camera = Camera.main;
		}

		// Update is called once per frame
		void Update()
		{
			//InputKeyBoard();
			InputMousePoint();

			//body
			Transform _t0 = list[0];
			Transform _t1 = null;			
			for (int i = 1; i < list.Count; i++)
			{
				_t1 = list[i];
				Vector3 _dir = _t0.position - _t1.position;				
				if (_dir.sqrMagnitude > distance * distance)
				{
					_t1.position = _t0.position - _dir.normalized* distance;
					//list[i].position = Vector3.Lerp(list[i].position, list[i - 1].position, damping * Time.deltaTime);
					if (_dir != Vector3.zero)
					{
						list[i].rotation = Quaternion.LookRotation(_dir);
					}
				}
				_t0 = _t1;
			}
		}

		//void InputKeyBoard()
		//{
		//	//move
		//	if (Input.GetKey(KeyCode.W))
		//	{
		//		transform.Translate(Vector3.up * speed * Time.deltaTime);
		//	}


		//	//rotation
		//	if (Input.GetKey(KeyCode.A)) turnDir = +1f;
		//	else if (Input.GetKey(KeyCode.D)) turnDir = -1f;
		//	else turnDir = 0f;
		//	transform.Rotate(Vector3.forward * turnDir * speedTurn * Time.deltaTime);
		//}

		void InputMousePoint()
		{
			if (Input.GetMouseButton(0))
			{
				ray = camera.ScreenPointToRay(Input.mousePosition);
				if (ground.Raycast(ray, out hitDistance))
				{
					Vector3 _hitPoint = ray.GetPoint(hitDistance);
					Vector3 _direction = _hitPoint - transform.position;
					_direction.z = 0f;

					//Quaternion _dirQ = Quaternion.LookRotation(_direction);
					//transform.rotation = Quaternion.Slerp(transform.rotation, _dirQ, 0.2f);
					transform.rotation = Quaternion.LookRotation(_direction);
					transform.Translate(Vector3.forward * speed * Time.deltaTime);

					//float _angle = 90f;// GetAngle(_direction);
					//_angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, _angle, 0.1f);
					//transform.Rotate(Vector3.forward * _angle);
					//transform.position += _direction.normalized * speed * Time.deltaTime;
					//transform.rotation = Quaternion.LookRotation(Vector3.forward * _angle);
				}
			}
			else
			{
				transform.Translate(Vector3.forward * speedNotClickPercent * speed * Time.deltaTime);
			}
		}

		private void OnTriggerEnter(Collider _other)
		{
			if (_other.CompareTag("Coin"))
			{
				// 기존에 작동하는 것들은 유지...
				// 새롭게 추가된것들이 들어옴...
				_other.transform.SetParent(null);
				_other.transform.localScale *= tailSize;
				Destroy(_other.GetComponent<Collider>());
				SnakeSpawner.ins.RemoveItem(_other.transform);
				StartCoroutine(Co_AddSnakeTail(list[list.Count - 1], _other.transform));
			}
		}

		IEnumerator Co_AddSnakeTail(Transform _t0, Transform _t1)
		{
			float _plusDistance = distance + 0.2f;
			Vector3 _dir = (_t0.position - _t1.position).normalized * distance;
			while (Vector3.Distance(_t0.position, _t1.position) > _plusDistance)
			{
				_t1.position = Vector3.Lerp(_t0.position - _dir, _t1.position, speedTailAdd * Time.deltaTime);
				yield return null;
			}
			list.Add(_t1.transform);
		}
	}

}