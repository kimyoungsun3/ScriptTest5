using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTTTT2
{
	public class Spowner : MonoBehaviour
	{
		public Transform transParent;
		public Transform obstaclePrefab;
		public float startPosZ = 40f;
		public float NEXT_POINT = 1f;
		float nextPoint;
		public List<Transform> list = new List<Transform>();

		Transform trans;
		private void Start()
		{
			trans = transform;
		}


		void Update()
		{
			float _z = trans.position.z;
			if (_z >= startPosZ)
			{
				if(_z > nextPoint)
				{
					nextPoint	= trans.position.z + NEXT_POINT;

					int _index	= Random.Range(0, list.Count);
					Transform _t1 = list[_index];
					Transform _t2 = Instantiate(obstaclePrefab, _t1.position, Quaternion.identity);
					_t2.gameObject.SetActive(true);

					_t2.SetParent(transParent);
				}
			}
		}
	}
}