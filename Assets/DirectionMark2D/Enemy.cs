using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _DirectionMark
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] float speed = 2f;
		[SerializeField] Transform arrow;
		[SerializeField] Transform waypoints;
		int index;
		Vector3 targetPos;
		Transform trans;
		List<Vector3> listPos = new List<Vector3>();

		private void Start()
		{
			trans = transform;
			if (arrow == null) arrow = trans.GetChild(0);
			arrow.SetParent(null);
			for(int i = 0, imax = waypoints.childCount; i < imax; i++)
				listPos.Add(waypoints.GetChild(i).position);

			index		= 0;
			targetPos	= listPos[index];

		}

		// Update is called once per frame
		void Update()
		{
			if(trans.position == targetPos)
			{
				index = (index + 1) % listPos.Count;
				targetPos = listPos[index];
			}

			trans.position = Vector3.MoveTowards(trans.position, targetPos, speed * Time.deltaTime);
		}
	}
}