using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;

namespace Jump3D_01
{
    public class GrapSpawner : MonoBehaviour {
		[SerializeField] Transform pp1, pp2;
		[SerializeField] List<GameObject> list = new List<GameObject>();
        public float WAIT_TIME = 2f;
        float waitTime;
		Vector3 p1, p2;
		public int count = 0;

		private void Start()
		{
			p1 = pp1.position;
			p2 = pp2.position;
		}


		// Update is called once per frame
		void Update() {
            if (Time.time > waitTime && count > 0)
            {
				count--;
                waitTime = Time.time + WAIT_TIME;
                int _idx = Random.Range(0, list.Count);
				Vector3 _pos = new Vector3(Random.Range(p1.x, p2.x), p1.y, Random.Range(p1.z, p2.z));
                PoolManager.ins.Instantiate(list[_idx], _pos, Quaternion.identity);
            }
        }

		private void OnDrawGizmosSelected()
		{
			if(pp1 != null)
			{
				Vector3 _min = Vector3.Min(pp1.position, pp2.position);
				Vector3 _max = Vector3.Max(pp1.position, pp2.position);

				Vector3 _p1 = _min;
				Vector3 _p2 = new Vector3(_min.x, _min.y, _max.z);
				Vector3 _p3 = new Vector3(_max.x, _min.y, _min.z);
				Vector3 _p4 = _max;
				Gizmos.color = Color.white;
				Gizmos.DrawLine(_p1, _p2);
				Gizmos.DrawLine(_p1, _p3);
				Gizmos.DrawLine(_p2, _p4);
				Gizmos.DrawLine(_p3, _p4);
			}
		}
	}
}
