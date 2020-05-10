using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NGUI_108_ButtonParticlle
{
	public class UIWayPoint : MonoBehaviour
	{
		[SerializeField] float speed = 1f;
		public bool bHandle = true;
		public List<Vector3> wayPointsLocal = new List<Vector3>();
		Vector3[] wayPoints;
		int index = 0;
		Vector3 targetPos;
		Transform trans;

		private void Start()
		{
			trans = transform;			

			wayPoints = new Vector3[wayPointsLocal.Count];
			for (int i = 0, imax = wayPointsLocal.Count; i < imax;  i++)
			{
				wayPoints[i] = trans.TransformPoint(wayPointsLocal[i]);
			}
			targetPos	= wayPoints[index];
			index		= (index + 1) % wayPoints.Length;
			trans.position = targetPos;
		}


		void Update()
		{
			if(trans.position == targetPos)
			{
				targetPos = wayPoints[index];
				index = (index + 1) % wayPoints.Length;
			}

			trans.position = Vector3.MoveTowards(trans.position, targetPos, speed * Time.deltaTime);
		}
	}
}