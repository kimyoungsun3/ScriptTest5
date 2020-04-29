using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FSM6;
using SoundManager7;
using PoolManager7;

namespace Number03_AllUGUI
{
	public class HitObject : MonoBehaviour
	{
		RectTransform trans;
		//Camera camera;
		//Plane ground;
		Quaternion rot = Quaternion.identity;

		[SerializeField] RectTransform target;	
		[SerializeField] float speed = 3f;
		//[SerializeField] List<Transform> list_WayPoints = new List<Transform>();
		//List<Vector3> list_LocalWayPoints = new List<Vector3>();
		[SerializeField] WayPoints wayPoints;
		int index;
		Vector3 targetPos;

		//HealthNumber healthScp;
		int health = 9999;
		[SerializeField] Text healthText;

		private void Start()
		{
			Application.runInBackground = true;
			Screen.sleepTimeout = SleepTimeout.NeverSleep;

			trans	= (RectTransform)transform;
			//camera	= Camera.main;
			//ground	= new Plane( -camera.transform.forward, Vector3.zero);

			//for (int i = 0, imax = list_WayPoints.Count; i < imax; i++)
			//{
			//	list_LocalWayPoints.Add(list_WayPoints[i].position);
			//}
			index		= 0;
			targetPos	= wayPoints.GetPos(index);
			index		= (index + 1) % wayPoints.Count;

			if (target == null)
				target = (RectTransform)transform;

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
		//[SerializeField] Text ttt, ttt2;
		private void Update()
		{
			if (Time.time > time)
			{
				time			= Time.time + NEXT_TIME;
				//Vector3 _pos	= camera.WorldToScreenPoint(target.position);
				Vector3 _pos	= trans.position;
				HitNumber _scp	= PoolManager.ins.Instantiate("HitNumber", _pos, rot).GetComponent<HitNumber>();
				_scp.SetData(_pos, (int)Random.Range(10, 900));

				health -= 1;
				healthText.text = health.ToString();
			}

			//if(trans.position == targetPos)
			if( (trans.position - targetPos).magnitude < 0.001f)
			{
				targetPos	= wayPoints.GetPos(index);
				index		= (index + 1) % wayPoints.Count;
			}

			//ttt.text = "wc:" + wayPoints.Count + " index:" + index + "\n"
			//	+ (trans.position == targetPos) + ":" + (trans.position - targetPos).magnitude
			//	+ ": " + trans.position 
			//	+ " " + targetPos + "\n"
			//	+ " (" + trans.position.x
			//	+ ", " + trans.position.y
			//	+ ", " + trans.position.z
			//	+ ") (" + targetPos.x
			//	+ ", " + targetPos.y
			//	+ ", " + targetPos.z;
			//ttt2.text = ttt.text;

			trans.position = Vector3.MoveTowards(trans.position, targetPos, speed * Time.deltaTime);
			//healthScp.SetMove(camera.WorldToScreenPoint(trans.position));
			//healthScp.DisplayHealth(8789);
		}

		public Vector3 MoveTowards(Vector3 _current, Vector3 _target, float _maxDistanceDelta)
		{
			Vector3 vector3;
			Vector3 _dir = _target - _current;
			float _distance = _dir.magnitude;
			vector3 = (_distance <= _maxDistanceDelta || _distance < 1.401298E-45f ? _target : _current + ((_dir / _distance) * _maxDistanceDelta));
			return vector3;
		}
	}
}
