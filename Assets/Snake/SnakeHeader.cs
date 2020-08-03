using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakeHeader : MonoBehaviour {
	[SerializeField] float speed = 3.5f;
	[SerializeField][Range(0, 1f)] float speedNotClickPercent = .3f;
	public float speedTurn = 50f;
	private float turnDir = 0f;
	//public Transform header;
	[Range(1f, 10f)] public float damping;
	public List<Transform> list = new List<Transform>();
	private Vector3 dummySpeed;
	public float distance = 1f;
	public float tailSize = 0.8f;


	Plane ground;
	Ray ray;
	//RaycastHit hit;
	float hitDistance;
	Camera camera;
	// Use this for initialization
	void Start () {
		ground = new Plane(Vector3.forward, Vector3.zero);
		camera = Camera.main;
	}

	// Update is called once per frame
	void Update() {
		//InputKeyBoard();
		InputMousePoint();
		
		//body
		list[0].position = transform.position;
		list[0].rotation = transform.rotation;
		for (int i = 1; i < list.Count; i++)
		{
			Vector3 _dir = list[i - 1].position - list[i].position;
			if (_dir.sqrMagnitude > distance)
			{
				//Debug.Log(i);
				//Vector3.Angle()
				list[i].position = Vector3.Lerp(list[i].position, list[i - 1].position, damping * Time.deltaTime);
				if (_dir != Vector3.zero)
					list[i].rotation = Quaternion.LookRotation(_dir);
			} 
		}
	}

	void InputKeyBoard()
	{
		//move
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		}
			

		//rotation
		if (Input.GetKey(KeyCode.A)) turnDir = +1f;
		else if (Input.GetKey(KeyCode.D)) turnDir = -1f;
		else turnDir = 0f;
		transform.Rotate(Vector3.forward * turnDir * speedTurn * Time.deltaTime);
	}

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
			_other.transform.SetParent(null);
			Destroy(_other.GetComponent<Collider>());
			//_other.gameObject
			_other.transform.localScale *= tailSize;
			list.Add(_other.transform);
		}
	}
}
