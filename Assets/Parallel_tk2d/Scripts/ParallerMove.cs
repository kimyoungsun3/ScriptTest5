using UnityEngine;
using System.Collections;

namespace tk2d_parallel{
	public class ParallerMove : MonoBehaviour {
		Transform trans;
		Player scpPlayer;
		float DEPTH_MAX = 1000;
		public float depth = 100;
		float moveSpeed;
		// Use this for initialization
		void Start () {
			trans = transform;
			scpPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

			moveSpeed = Mathf.Lerp (0, scpPlayer.moveSpeed, depth / DEPTH_MAX);
		}
		
		// Update is called once per frame
		void Update () {
			if (scpPlayer.bDie) {
				return;
			}
			trans.Translate (Vector3.right * moveSpeed * Time.deltaTime);

		
		}
	}
}
