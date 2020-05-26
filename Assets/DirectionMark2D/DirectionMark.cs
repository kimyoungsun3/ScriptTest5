using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _DirectionMark
{
	[System.Serializable]
	public class EnemyData
	{
		public Transform trans;
		public SpriteRenderer mark;
		[HideInInspector] public Transform markTrans;

		public void SetDiectionVisual(bool _b)
		{
			if (_b && !mark.gameObject.activeSelf)
				mark.gameObject.SetActive(_b);
			else if(!_b && mark.gameObject.activeSelf)
				mark.gameObject.SetActive(_b);
		}

		public void SetDirectionMark(Vector3 _pos, Vector3 _dir)
		{
			if(markTrans == null)
				markTrans = mark.transform;

			markTrans.position = _pos;
			//markTrans.rotation = Quaternion.Euler(0f, 0f, GetDirToAngle(_dir));
		}

		float GetDirToAngle(Vector3 _dirNormal)
		{
			return Mathf.Atan2(_dirNormal.y, _dirNormal.x) * Mathf.Rad2Deg;
		}
	}

	public class DirectionMark : MonoBehaviour
	{
		#region singleton
		public static DirectionMark ins { get; private set; }
		private void Awake()
		{
			ins = this;
		}
		#endregion

		public List<EnemyData> list = new List<EnemyData>();
		Transform trans;
		float nextTime;
		[SerializeField] float NEXT_TIME = 0.2f;
		[SerializeField] LayerMask maskBounds;
		[Header("좌우상하로 등록...")]		
		[SerializeField] List<Transform> listTestBounds = new List<Transform>();


		void Start()
		{
			trans = transform;
		}

		void Update()
		{
			if(Time.time > nextTime)
			{	
				nextTime = Time.time + NEXT_TIME;
				//CheckTestBounds();
				CheckDirectionBounds();
			}

		}

		//void CheckTestBounds()
		//{
		//	//경계라인 계산...
		//	for (int i = 0, imax = listTestBounds.Count; i < imax; i++)
		//	{
		//	}
		//}

		void CheckDirectionBounds()
		{
			Vector3 _dir, _dirN;
			RaycastHit2D _hit;
			EnemyData _target;
			for (int i = 0, imax = list.Count; i < imax; i++)
			{
				_target	= list[i];
				_dir	= _target.trans.position - trans.position;
				_dirN	= _dir.normalized;

				_hit = Physics2D.Raycast(trans.position, _dirN, _dir.magnitude, maskBounds);
				if (_hit)
				{
					//Debug.Log(i + ": Hit");
					_target.SetDiectionVisual(true);
					_target.SetDirectionMark(_hit.point, _dirN);
				}
				else
				{
					//Debug.Log(i + ": Close");
					_target.SetDiectionVisual(false);
				}
			}
		}
	}
}
