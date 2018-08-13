using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectionChange2{
	public class MoveRotate : MonoBehaviour {
		public float moveSpeed = 2f;
		Vector3 move;
		SpriteRenderer render;

		// Use this for initialization
		void Start () {
			render = GetComponent<SpriteRenderer> ();
		}
		
		// Update is called once per frame
		void Update () {
			move.Set (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0);
			//Debug.Log (move);
			transform.Translate ( move.x * Vector3.right * moveSpeed * Time.deltaTime, Space.World);

			if (move.x > 0 && transform.eulerAngles.y != 0) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			} else if (move.x < 0 && transform.eulerAngles.y != 180) {
				transform.rotation = Quaternion.Euler (0, 180, 0);
			}
		}
	}
}