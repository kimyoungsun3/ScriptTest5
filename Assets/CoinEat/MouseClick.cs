using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager7;

namespace CoinEat{
	public class MouseClick : MonoBehaviour {
		public Transform target;
		int index = 0;
		public List<GameObject> list = new List<GameObject> ();
		float nextTime;
		public float NEXT_TIME = 0.2f;
		Vector3 randPos, pos;
		
		// Update is called once per frame
		void Update () {


			if (Input.GetMouseButton (0) && Time.time > nextTime) {
				nextTime = Time.time + NEXT_TIME;
				pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				randPos = Random.insideUnitCircle * 100f;
				pos.Set(pos.x + randPos.x, pos.y + randPos.y, 0);


				CoinEat _scp = PoolManager.ins.Instantiate (list [index], pos, Quaternion.identity).GetComponent<CoinEat> ();
				if (_scp != null) {
					_scp.InitFirst (target.position);
				}
			} else if (Input.GetMouseButtonDown (1)) {
				index = (index + 1) % list.Count;
			}
		}
	}
}
