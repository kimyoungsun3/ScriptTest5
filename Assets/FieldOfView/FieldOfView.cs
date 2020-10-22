using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FieldOfViewTest
{
	public class FieldOfView : MonoBehaviour
	{
		[Range(1f, 20f)] public float viewRadius = 5f;
		[Range(0f, 360f)]public float viewAngle = 45f;
		[SerializeField, Range(0.09f, 1f)] float meshResolution = 0.1f;
		[SerializeField, Range(1, 10)] int edgeResolution = 8;
		[SerializeField, Range(0.09f, 1f)] float maskMCutawayDst = 0.1f;
		//[SerializeField, Range(0.05f, 1f)] float edgeDstThreshold = 0.1f;
		public LayerMask maskTarget;
		public LayerMask maskObstacle;
		[SerializeField, Range(0.01f, 1f)]float NEXT_FIND_TIME = 0.2f;
		float nextFindTime;
		//public List<Vector3> lll;

		
		public MeshFilter meshFilter;
		Mesh mesh;
		Transform trans;

		[HideInInspector]public List<Transform> listTarget = new List<Transform>();

		private void Start()
		{
			trans		= transform;

			mesh		= new Mesh();
			mesh.name	= "Field Of View";
			meshFilter.mesh = mesh;
		}



		private void Update()
		{
			if(Time.time > nextFindTime)
			{
				FindTarget();
			}
		}

		void FindTarget()
		{
			listTarget.Clear();
			//1. 주위 검색...
			//2.  >> 시야내의 적인지 검색...
			//3.    >> 적군과의 사이에 장애물 없는가?
			Transform _t = transform;
			Transform _target;
			Vector3 _viewDir, _viewDirN;
			float _angle, _distance;
			float _viewAnglehalf = viewAngle * 0.5f;

			Collider[] _cols = Physics.OverlapSphere(transform.position, viewRadius, maskTarget);
			for(int i = 0, _len = _cols.Length; i < _len; i++)
			{
				_target		= _cols[i].transform;
				_viewDir	= _target.position - _t.position;
				_angle		= Vector3.Angle(_t.forward, _viewDir.normalized);
				if(_angle < _viewAnglehalf)
				{
					_viewDirN = _viewDir.normalized;
					_distance = _viewDir.magnitude;
					if(!Physics.Raycast(_t.position, _viewDirN, _distance, maskObstacle))
					{
						// 유저 - ------ - 적
						listTarget.Add(_target);
					}
					//else
					//{
					//	// 유저 - 장애물 - 적
					//}
				}
			}
		}

		public Vector3 GetDirFromAngle(float _angleY, bool _bGlobal = false)
		{
			if (!_bGlobal)
			{
				_angleY += transform.eulerAngles.y;
			}
			return new Vector3( Mathf.Sin(_angleY * Mathf.Deg2Rad), 0f, Mathf.Cos(_angleY * Mathf.Deg2Rad));
		}


		private void LateUpdate()
		{
			DrawFieldOfView();
		}

		void DrawFieldOfView()
		{
			//1. 각도를 분할
			//2.  >> 분할된 각도로 위치점을 계산...
			//3.  >> 위치점을 Mesh로 만든다...
			//       중간 지점에 충돌과 비충돌이 있으면 중간에 분할로 충돌을 좁혀간다...
			int _stepCount		= Mathf.RoundToInt(viewAngle * meshResolution);
			float _stepAngle	= viewAngle / _stepCount;
			float _angleY;
			float _startAngle = trans.eulerAngles.y - viewAngle * 0.5f;
			Vector3 _dir;
			//@@@@ [] - 크게 잡아서 작업...
			List<Vector3> _listViewPoints = new List<Vector3>();
			ViewCastInfo _oldViewCast = new ViewCastInfo();
					   
			for (int i = 0; i <= _stepCount; i++)
			{
				_angleY	= _startAngle + i * _stepAngle;
				ViewCastInfo _newViewCast = ViewCast(_angleY);
				if(i > 0)
				{
					//bool _bEdgeDstThreshold = Mathf.Abs(_oldViewCast.dst - _newViewCast.dst) > edgeDstThreshold;
					//if(_oldViewCast.bHit != _newViewCast.bHit || (_oldViewCast.bHit && _newViewCast.bHit && _bEdgeDstThreshold))
					if(_oldViewCast.bHit != _newViewCast.bHit)
					{
						EdgeInfo _edge = FindEdge(_oldViewCast, _newViewCast);

						//Debug.Log(i
						//	//+ ":" + _bEdgeDstThreshold
						//	+ ":" + _oldViewCast.point + ":" + _newViewCast.point
						//	+ ":" + _edge.minPoint + ":" + _edge.maxPoint);
						if (_edge.minPoint != Vector3.zero)
						{
							_listViewPoints.Add(_edge.minPoint);
						}
						if (_edge.maxPoint != Vector3.zero)
						{
							_listViewPoints.Add(_edge.maxPoint);
						}
					}
				}

				_listViewPoints.Add(_newViewCast.point);
				_oldViewCast = _newViewCast;
			}

			//lll = _listViewPoints;
			//Debug.Log(_listViewPoints.Count);
			//@@@@ 현재 수량과 같으면 그대로 유지...
			//Mesh draw
			int _vertexCount	= _listViewPoints.Count + 1;
			Vector3[] _vertices = new Vector3[_vertexCount];
			int[] _triangles	= new int[(_vertexCount - 2) * 3];

			_vertices[0] = Vector3.zero;
			Vector3 _more = trans.forward * maskMCutawayDst;
			for (int i = 0; i < _vertexCount - 1; i++)
			{
				_vertices[i+1] = trans.InverseTransformPoint(_listViewPoints[i] + _more);

				if(i < _vertexCount - 2)
				{
					_triangles[i * 3 + 0] = 0;
					_triangles[i * 3 + 1] = i + 1;
					_triangles[i * 3 + 2] = i + 2;
				}
			}

			mesh.Clear();
			mesh.vertices = _vertices;
			mesh.triangles = _triangles;
			mesh.RecalculateNormals();
		}

		ViewCastInfo ViewCast(float _angleY)
		{
			Vector3 _dir = GetDirFromAngle(_angleY, true);
			RaycastHit _hit;

			if(Physics.Raycast(trans.position, _dir, out _hit, viewRadius, maskObstacle))
			{
				return new ViewCastInfo(true, _hit.point, _hit.distance, _angleY);
			}
			else
			{
				return new ViewCastInfo(false, trans.position + _dir * viewRadius, viewRadius, _angleY);
			}	
		}

		EdgeInfo FindEdge(ViewCastInfo _minViewCast, ViewCastInfo _maxViewCast)
		{ 
			float _minAngle		= _minViewCast.angle;
			float _maxAngle		= _maxViewCast.angle;
			Vector3 _minPoint	= Vector3.zero;
			Vector3 _maxPoint	= Vector3.zero;
			float _angleY;
			ViewCastInfo _newViewCast;
			
			for (int i = 0; i < edgeResolution; i++)
			{
				_angleY = (_minAngle + _maxAngle) * .5f;
				_newViewCast = ViewCast(_angleY);

				//bool _bEdgeDstThreshold = Mathf.Abs(_minViewCast.dst - _newViewCast.dst) > edgeDstThreshold;
				//Debug.Log(i + ":" + _bEdgeDstThreshold + "" + _minAngle + ":" + _maxAngle + " >> " + _angleY);
				//if (_newViewCast.bHit == _minViewCast.bHit && !_bEdgeDstThreshold)
				if (_newViewCast.bHit == _minViewCast.bHit)
				{
					_minAngle	= _newViewCast.angle;
					_minPoint	= _newViewCast.point;
				}
				else
				{
					_maxAngle	= _newViewCast.angle;
					_maxPoint	= _newViewCast.point;
				}
			}

			return new EdgeInfo(_minPoint, _maxPoint);
		}
	}

	public struct ViewCastInfo
	{
		public bool bHit;
		public Vector3 point;
		public float dst;
		public float angle;

		public ViewCastInfo(bool _bHit, Vector3 _point, float _dst, float _angle)
		{
			bHit	= _bHit;
			point	= _point;
			dst		= _dst;
			angle	= _angle;
		}
	}

	public struct EdgeInfo
	{
		public Vector3 minPoint;
		public Vector3 maxPoint;
		public EdgeInfo(Vector3 _minPoint, Vector3 _maxPoint)
		{
			minPoint = _minPoint;
			maxPoint = _maxPoint;
		}
	}
}