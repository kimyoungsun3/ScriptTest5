using UnityEngine;
using System.Collections;

namespace Parallel01_Direct{
	public class ParallerMove : MonoBehaviour {
		public Player scpPlayer;
		float DEPTH_MAX = 1000;
		public float depth = 100;
		float moveSpeed;

		void Update () {
			if (scpPlayer.bPause) {
				return;
			}

			if(scpPlayer.velocity.y < 0)
				moveSpeed = Mathf.Lerp (0, -scpPlayer.velocity.magnitude, depth / DEPTH_MAX);
			else
				moveSpeed = Mathf.Lerp (0, scpPlayer.velocity.y, depth / DEPTH_MAX);

			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);		
		}

		public void ResetPosition(){
			transform.position = Vector3.zero;
		}
	}
}
