using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _NGUI_107_StepByStep
{
	public class UIStepByStepUGUI : MonoBehaviour
	{
		[SerializeField] Vector3 startAngle = new Vector3(90f, 0f, 0f);
		[SerializeField] Vector3 endAngle	= new Vector3(0f, 0f, 0f);
		[SerializeField] [Range(0f, 1f)] float duration = 0.3f;
		[SerializeField] [Range(0f, 1f)] float criticalPoint = 0.8f;		//0.8f -> 80%을 의미...
		[SerializeField] AnimationCurve curve;
		[SerializeField] List<RectTransform> list = new List<RectTransform>();

		private void Start()
		{
			Init();
		}

		void Init()
		{
			for (int i = 0, imax = list.Count; i < imax; i++)
				list[i].rotation = Quaternion.Euler(startAngle);
		}

		public void PlayAnimation(bool _bForward)
		{
			float _waitTime = 0;
			for (int i = 0, imax = list.Count; i < imax; i++)
			{
				StartCoroutine(Co_ShowBoard(list[i], _waitTime, _bForward));
				_waitTime += duration * criticalPoint;
			}
		}

		IEnumerator Co_ShowBoard(RectTransform _t, float _wait, bool _bForward)
		{
			//Debug.Log(_wait);
			if (_wait > 0f)
				yield return new WaitForSeconds(_wait);

			float _percent = 0;
			float _speed = 1f / duration;
			float _interval = 0;
			Quaternion _q1 = _t.rotation;
			Quaternion _q2 = Quaternion.Euler(_bForward ? startAngle : endAngle);
			while (_percent <= 1f)
			{
				_percent += _speed * Time.deltaTime;
				_interval = curve.Evaluate(_percent);
				_t.rotation = Quaternion.Lerp(_q1, _q2, _interval);
				yield return null;
			}
		}


#if UNITY_EDITOR
		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				PlayAnimation(true);
			}
			else if(Input.GetMouseButtonDown(1))
			{
				PlayAnimation(false);
			}
		}

		[ContextMenu("UGUI 리스트 채워주기")]
		void Editor_ButtonList()
		{
			for(int i = 0, imax = transform.childCount; i < imax; i++)
			{
				list.Add( ( RectTransform ) transform.GetChild( i ) );
			}
		}
#endif
	}
}
