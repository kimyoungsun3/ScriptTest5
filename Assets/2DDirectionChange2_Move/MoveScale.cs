using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectionChange2{
	public class MoveScale : MonoBehaviour {
		public float moveSpeed = 2f;
		Vector3 move;
		Vector3[] dir = new Vector3[]{
			new Vector3(1, 1, 1),
			new Vector3(-1, 1, 1)
		};
		Vector3 zero;

		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
			move.Set (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0);

			if (move.x > 0 && transform.localScale.x != 1) {
				transform.localScale = dir[0];
			} else if (move.x < 0 && transform.localScale.x != -1) {
				transform.localScale = dir[1];
			}

			if(move != zero)
				transform.Translate(move.normalized * moveSpeed * Time.deltaTime);
		}
	}
}
