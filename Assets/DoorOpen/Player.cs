using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorTest
{
	public class Player : MonoBehaviour
	{
		[SerializeField] float speed = 2f;
		Transform trans;
		void Start()
		{
			trans = transform;
		}

		// Update is called once per frame
		void Update()
		{
			float _h = Input.GetAxisRaw("Horizontal");
			float _v = Input.GetAxisRaw("Vertical");
			if(_h != 0 || _v != 0)
			{
				trans.Translate(new Vector3(_h, 0, _v) * speed * Time.deltaTime);
			}
		}
	}
}