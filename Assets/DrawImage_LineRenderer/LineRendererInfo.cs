using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrawImageLineRendererTest
{
	public class LineRendererInfo : MonoBehaviour
	{
		LineRenderer line;
		List<Vector3> list = new List<Vector3>();
		Rigidbody rigidbody;
		Collider collider;

		public void InitData(LineInfo _lineInfo)
		{
			if (line == null)
				line = GetComponent<LineRenderer>();

			gameObject.SetActive(true);
			list.Clear();
			line.positionCount = 0;
			line.startColor = _lineInfo.currentColor;
			line.endColor	= _lineInfo.currentColor;
			line.startWidth = _lineInfo.width;
			line.endWidth = _lineInfo.width;
		}

		public void Destroy()
		{
			Destroy(gameObject);
		}

		public void SetActiveObject()
		{
			if (rigidbody != null)
				return;

			rigidbody = gameObject.AddComponent<Rigidbody>();
			rigidbody.constraints = RigidbodyConstraints.FreezePositionZ
				| RigidbodyConstraints.FreezeRotationX
				| RigidbodyConstraints.FreezeRotationY;

			collider = gameObject.AddComponent<BoxCollider>();
		}

		public void SetPosition(Vector3 _pos)
		{
			int _count = list.Count;
			if (_count > 0 && list[_count - 1] == _pos)
			{
				return;
			}
			else
			{
				list.Add(_pos);
				line.positionCount = list.Count;
				line.SetPosition(_count, _pos);
			}
		}

	}
}