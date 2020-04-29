using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Number02_TextMesh
{

	public class WayPoints : MonoBehaviour
	{
		public List<Vector3> list_WayPoins = new List<Vector3>();
		//int count;

		private void Awake()
		{
			CalculateWayPoint();
		}

		private void Start()
		{
			Transform _t = transform;
			for (int i = 0, imax = _t.childCount; i < imax; i++)
			{
				_t.GetChild(i).gameObject.SetActive(false);
			}
			//count = list_WayPoins.Count;
		}

		public Vector3 GetPos(int _idx)
		{
			return list_WayPoins[_idx];
		}

		public int Count
		{
			get { return list_WayPoins.Count; }
		}

		[ContextMenu("웨이 포인트를 리스트 만들기.")]
		void CalculateWayPoint()
		{
			Transform _t = transform;
			list_WayPoins.Clear();
			for (int i = 0, imax = _t.childCount; i < imax; i++)
			{
				list_WayPoins.Add(_t.GetChild(i).position);
			}
		}
	}
}
