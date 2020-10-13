using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 좌우 이동하기...
//2. Spawner하기...
//3. Destroy 하기...
namespace TTTTT2
{
	public class PixelRush2 : MonoBehaviour
	{
		private Rigidbody rb;
		BoxCollider boxCollider;
		[Range(10f, 2000f)] public float jumpPower = 300f;
		[Range(10f, 2000f)] public float spinePower = 150f;
		public LayerMask mask;

		[Range(0.01f, 1f)] public float duration = 0.1f;
		public AnimationCurve curve;
		// Start is called before the first frame update
		void Start()
		{
			rb			= GetComponent<Rigidbody>();
			boxCollider = GetComponent<BoxCollider>();
		}

		// Update is called once per frame
		void Update()
		{
			bool _bLeft		= Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
			bool _bRight	= Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
			bool _bJump		= Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) ;
			Vector3 _vel	= rb.velocity;
			_vel.z			= 5f;
			rb.velocity		= _vel;

			//Debug.DrawLine(transform.position, transform.position + Vector3.down, Color.red);
			if (Physics.Linecast(transform.position, transform.position + Vector3.down, mask))
			{
				//Quaternion _rot		= transform.rotation;
				//_rot.x				= Mathf.Round(_rot.x / 90) * 90;
				//transform.rotation	= _rot;

				//z 한쪽회전....
				Vector3 _angle			= transform.eulerAngles;
				_angle.z				= Mathf.Round(_angle.z / 90) * 90;
				transform.eulerAngles	= _angle;
				if (_bJump)
				{
					//Debug.Log("Jump");
					rb.velocity = Vector3.zero;
					rb.AddForce(Vector3.up * (jumpPower * rb.mass * 20f));
					rb.AddRelativeTorque(Vector3.right * spinePower);
				}

				//좌위 이동...
				if (_bLeft || _bRight)
				{
					Vector3 _pos = transform.position;
					if (_bLeft && _pos.x > -1f)
					{
						// <----
						//Debug.Log("_bLeft");
						StopCoroutine("Co_MoveToward");
						StartCoroutine("Co_MoveToward", -1f);
					}
					else if (_bRight && _pos.x < 1f)
					{
						// --->
						//Debug.Log("_bRight");
						StopCoroutine("Co_MoveToward");
						StartCoroutine("Co_MoveToward", +1f);
					}
				}
			}			
		}


		IEnumerator Co_MoveToward(float _dir)
		{
			Transform _t	= transform;
			Vector3 _pos	= _t.position;
			//-1 0 +1
			//<  <
			//   >  >
			float _posX		= 0f;
			if (_dir == -1f)
			{
				if (_pos.x > 0f)
				{
					_posX = 0f;
				}
				else
				{
					_posX = -1f;
				}
			}
			else if (_dir == 1f)
			{
				if (_pos.x < 0f)
				{
					_posX = 0f;
				}
				else
				{
					_posX = +1f;
				}
			}

			float _speed	= 1f / duration;
			float _percent	= 0f;
			float _interval;
			//Debug.Log("** " + _posX + ":" + _pos.x + ":" + _speed);
			while (_percent < 1f)
			{
				_percent	+= _speed * Time.deltaTime;
				_interval	= curve.Evaluate(_percent);

				//Debug.Log(_percent + ":" + _interval);
				_pos		= _t.position;
				_pos.x		= Mathf.Lerp(_pos.x, _posX, _interval);
				_t.position = _pos;
				yield return null;
			}
		}
	}
}