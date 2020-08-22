using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform_Door_Elevator
{
	public enum eCamearView
	{
		None,
		ToLOLView,
		ToSideLeftView, ToSideRightView,
		ToTopView
	};

	[System.Serializable]
	public class CameraViewInfo
	{
		public eCamearView type;
		public Transform trans;
	}

	public class CameraRig : MonoBehaviour
	{
		[SerializeField, Range(0.01f, 1f)] float duration = 0.2f;
		[SerializeField] AnimationCurve curve;
		[SerializeField] List<CameraViewInfo> list = new List<CameraViewInfo>();
		Transform trans;
		Transform cameraTrans;	//rig 아래에 있는 카메라를 잡아준다.

		void Start()
		{
			trans		= transform;
			cameraTrans = GetComponentInChildren<Camera>().transform;
		}

		public void SetToCameraView(eCamearView _type)
		{
			StopCoroutine("Co_ChangeView");
			StartCoroutine("Co_ChangeView", _type);
		}

		IEnumerator Co_ChangeView(eCamearView _type)
		{
			yield return null;
			Transform _p = null;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].type == _type)
				{
					_p = list[i].trans;
					break;
				}
			}

			Vector3 _p0 = trans.position;
			Vector3 _p1 = _p.position;
			Quaternion _r0 = trans.rotation;
			Quaternion _r1 = _p.rotation;

			float _speed = 1f / duration;
			float _percent = 0;
			float _interval;

			while (_percent <= 1f)
			{
				_percent += _speed * Time.deltaTime;
				_interval = curve.Evaluate(_percent);

				trans.position = Vector3.Lerp(_p0, _p1, _interval);
				trans.rotation = Quaternion.Lerp(_r0, _r1, _interval);
				yield return null;
			}
		}

		//void LateUpdate()
		//{
		//	cameraTrans.LookAt(trans);
		//}
	}
}