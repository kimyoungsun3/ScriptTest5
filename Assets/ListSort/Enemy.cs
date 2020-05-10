using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _ListSort
{
	public enum eWayType { Up, Down, Common }
	public class Enemy : MonoBehaviour
	{
		[SerializeField] float speed = 1f;
		[SerializeField] TextMesh textMesh;
		[Header("이하는 생성시 세팅되는것임")]
		public eWayType wayType;
		public float distance;
		public float health;
		float damage;

		Transform trans;
		int index;
		List<Point> wayPoints;
		public Point point;

		//private void Start()
		//{
		//	InitData();
		//}

		public void SetData(float _health, eWayType _wayType)
		{
			health	= _health;
			wayType = _wayType;
			gameObject.SetActive(true);

			if (wayType == eWayType.Up)
				wayPoints = WayPoints.ins.listUp;
			else
				wayPoints = WayPoints.ins.listDown;

			index = 0;
			point = wayPoints[index];
			distance = WayPoints.ins.GetDistance(wayType);

			trans = transform;
			trans.position = point.position;
			textMesh.text = string.Format("{0}", health);
		}

		[SerializeField] bool bSlow;
		private void Update()
		{
			float _moveDistance = (bSlow ? 0.5f : 1f) * speed * Time.deltaTime;
			distance	-= _moveDistance;
			if (damage != 0)
			{
				health	-= damage;
				damage	= 0;
				textMesh.text = string.Format("{0}", health);				
			}			

			if(health <= 0f)
			{
				//Healt is Die
				Debug.Log("@포인트획득");
				Spawner.ins.RemoveEnemy(this);
				gameObject.SetActive(false);
				return;
			}
			else if (trans.position == point.position)
			{
				index = index + 1;
				if(index == wayPoints.Count)
				{
					//목표 지점에 도달...
					Spawner.ins.RemoveEnemy(this);
					gameObject.SetActive(false);
					return;
				}

				point = wayPoints[index];
				//remainDistance = WayPoints.ins.GetDistance(wayType);
			}

			trans.position = Vector3.MoveTowards(trans.position, point.position, _moveDistance);
		}

		public void TakeDamage(float _damage)
		{
			damage += _damage;
		}
	}
}