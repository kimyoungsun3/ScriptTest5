using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2_Door_Elevator_Ladder_FreeView
{
	public class Platform_Elevator : MonoBehaviour
	{
		//0번 자기 자신
		//1
		[Header("처음은 자기 자신을 넣어주세요")]
		public List<Transform> listWay = new List<Transform>();
		List<Vector3> listPoint = new List<Vector3>();
		Vector3 nextPoint;
		int index;

		public float speed = 1f;
		float delayTime;
		public float DELAY_TIME = 1f;
		public bool bAutoMove = true;

		void Start()
		{
			int imax = listWay.Count;
			for (int i = 0; i < imax; i++)
			{
				listPoint.Add(listWay[i].position);
			}

			index = -1;
			NextPoint();
		}

		void NextPoint()
		{
			//0 -> 1 -> ... -> n -> 0 -> 1 ....
			index = (index + 1) % listPoint.Count;
			nextPoint = listPoint[index];
			delayTime = Time.time + DELAY_TIME;
		}

		public void SetMovePlatform()
		{
			bAutoMove = true;
		}

		// Update is called once per frame
		void Update()
		{
			//Debug.Log(Time.time + ":" + Time.deltaTime);
			if (bAutoMove && Time.time > delayTime)
			{
				transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
				if (transform.position == nextPoint)
				{
					NextPoint();
				}
			}
		}

		private void OnTriggerEnter(Collider _col)
		{
			if (_col.CompareTag("Player"))
			{
				_col.transform.SetParent(transform);
			}
		}

		private void OnTriggerExit(Collider _col)
		{
			if (_col.CompareTag("Player"))
			{
				_col.transform.SetParent(null);
			}
		}


		private void OnDrawGizmos()
		{
			Vector3 _p0 = Vector3.zero;
			Vector3 _p1 = Vector3.zero;
			Gizmos.color = Color.green;

			if (Application.isPlaying == false)
			{
				List<Transform> _listTrans = listWay;
				if (_listTrans.Count >= 2)
				{
					for (int i = 0, imax = _listTrans.Count - 1; i < imax; i++)
					{
						_p0 = _listTrans[i].position;
						_p1 = _listTrans[i + 1].position;
						Gizmos.DrawLine(_p0, _p1);
					}
				}
			}
			else
			{
				List<Vector3> _listPos = listPoint;
				if (_listPos.Count >= 2)
				{
					for (int i = 0, imax = _listPos.Count - 1; i < imax; i++)
					{
						_p0 = _listPos[i];
						_p1 = _listPos[i + 1];
						Gizmos.DrawLine(_p0, _p1);
					}
				}
			}
		}
	}
}