using UnityEngine;
using System.Collections;

namespace tk2d_parallel{
	public class CameraFollow : MonoBehaviour {
		Transform trans;
		Player scpPlayer;

		// Use this for initialization
		void Start () {
			trans = transform;
			scpPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		
		}
		
		// Update is called once per frame
		void Update () {
			if (scpPlayer.bDie) {
				return;
			}
			trans.Translate (Vector3.right * scpPlayer.moveSpeed * Time.deltaTime);
		}
	}
}