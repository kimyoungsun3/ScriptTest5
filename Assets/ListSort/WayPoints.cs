using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _ListSort
{
	[System.Serializable]
	public class Point
	{
		public Vector3 position;
		public eWayType type;
		public Point(Vector3 _pos, string _tag)
		{
			position	= _pos;
			type		= (eWayType)System.Enum.Parse(typeof(eWayType), _tag, true);
			//switch (_tag)
			//{
			//	case "Up":		type = eWayType.Up;		break;
			//	case "Down":	type = eWayType.Down;	break;
			//	default:		type = eWayType.Common; break;
			//}
		}
	}

	public class WayPoints : MonoBehaviour
	{
		#region singletone
		public static WayPoints ins { get; private set; }
		private void Awake()
		{
			ins = this;
		}
		#endregion

		[SerializeField] Transform transUp, transDown;
		public List<Point> listUp	= new List<Point>();
		public List<Point> listDown	= new List<Point>();
		float distanceUp, distanceDown;
		
		public float GetDistance(eWayType _type)
		{
			List<Point> _list;
			float _distance = 0;
			switch (_type) {
				case eWayType.Up:
					if (distanceUp == 0) {
						_list = listUp;
						for (int i = 0, imax = _list.Count - 1; i < imax; i++)
						{
							distanceUp += Vector3.Distance(_list[i].position, _list[i + 1].position);
						}
					}
					_distance = distanceUp;
					break;
				case eWayType.Down:
					if (distanceDown == 0)
					{
						_list = listDown;
						for (int i = 0, imax = _list.Count - 1; i < imax; i++)
						{
							distanceDown += Vector3.Distance(_list[i].position, _list[i + 1].position);
						}
					}
					_distance = distanceDown;
					break;
			}

			return _distance;
		}


#if UNITY_EDITOR
		[ContextMenu("Way Points  리스트 채우기..")]
		void Editor_ListUpDown()
		{
			listUp.Clear();
			Point _point;
			Transform _t;
			for (int i = 0, imax = transUp.childCount; i < imax; i++)
			{
				_t		= transUp.GetChild(i);
				_point	= new Point(_t.position, _t.gameObject.tag);
				listUp.Add(_point);
			}

			listDown.Clear();
			for (int i = 0, imax = transDown.childCount; i < imax; i++)
			{
				_t		= transDown.GetChild(i);
				_point	= new Point(_t.position, _t.gameObject.tag);
				listDown.Add(_point);
			}
		}

		//eWayType GetFromTag(string _value)
		//{
		//	//if (System.Enum.IsDefined(typeof(T), _value))
		//	//	return default(T);
		//	//return (T)System.Enum.Parse(typeof(T), _value, true);
		//	return
		//}
#endif
	}
}
