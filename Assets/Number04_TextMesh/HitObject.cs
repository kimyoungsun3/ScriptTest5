using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM6;
using SoundManager7;
using PoolManager7;

namespace Number02_TextMesh
{
	public class HitObject : MonoBehaviour
	{
		Transform trans;
		Camera camera;
		//Plane ground;
		Quaternion rot = Quaternion.identity;

		[SerializeField] Transform target;	
		[SerializeField] float speed = 3f;
		//[SerializeField] List<Transform> list_WayPoints = new List<Transform>();
		//List<Vector3> list_LocalWayPoints = new List<Vector3>();
		[SerializeField] WayPoints wayPoints;
		int index;
		Vector3 targetPos;

		//HealthNumber healthScp;
		int health = 9999;
		[SerializeField]TextMesh healthText;

		private void Start()
		{
			Application.runInBackground = true;
			Screen.sleepTimeout = SleepTimeout.NeverSleep;

			trans	= transform;
			camera	= Camera.main;
			if (target == null) target = transform;
			//ground	= new Plane( -camera.transform.forward, Vector3.zero);

			//for (int i = 0, imax = list_WayPoints.Count; i < imax; i++)
			//{
			//	list_LocalWayPoints.Add(list_WayPoints[i].position);
			//}
			index		= 0;
			targetPos	= wayPoints.GetPos(index);
			index		= (index + 1) % wayPoints.Count;
			

			//if (healthScp == null)
			//{
			//	healthScp = PoolManager.ins.Instantiate("HealthNumber", trans.position, rot).GetComponent<HealthNumber>();
			//	healthScp.SetData(9999);
			//}
			//Debug.Log(healthScp);

			//if(textMesh == null)
			//	textMesh = GetComponentInChildren<TextMesh>();
			//textMesh.text = health.ToString();
		}

		[SerializeField] float NEXT_TIME = 0.05f;
		float time;
		private void Update()
		{
			if (Time.time > time)
			{
				time			= Time.time + NEXT_TIME;
				Vector3 _pos	= camera.WorldToScreenPoint(target.position);
				HitNumber _scp	= PoolManager.ins.Instantiate("HitNumber", _pos, rot).GetComponent<HitNumber>();
				_scp.SetData(_pos, (int)Random.Range(10, 900));

				health -= 1;
				healthText.text = health.ToString();
			}

			if(trans.position == targetPos)
			{
				targetPos	= wayPoints.GetPos(index);
				index		= (index + 1) % wayPoints.Count;
			}

			trans.position = Vector3.MoveTowards(trans.position, targetPos, speed * Time.deltaTime);
			//healthScp.SetMove(camera.WorldToScreenPoint(trans.position));
			//healthScp.DisplayHealth(8789);
		}
	}
}
