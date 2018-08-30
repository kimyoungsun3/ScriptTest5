using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AIPeople{
	public class People : MonoBehaviour {
		NavMeshAgent agent;
		float time;
		public Vector2 TIME_WAIT = new Vector2(2f, 8f);
		public List<Vector3> list = new List<Vector3> ();


		// Use this for initialization
		void Start () {
			agent = GetComponent<NavMeshAgent> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (Time.time > time) {

				NextPosition ();
			}
		}

		void NextPosition(){
			time = Time.time + Random.Range(TIME_WAIT.x, TIME_WAIT.y);


			Vector3 _pos = WayPoint.ins.GetPoint ().position;
			agent.SetDestination (_pos);
			list.Add (_pos);
		}
	}
}