using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_ScrollView
{
	public class CoverFlowUnit : MonoBehaviour
	{
		Transform trans;
		UIPanel panel;
		UIWidget widget;
		float cellWidth = 300f;
		float downScale = 0.35f;
		Vector3 dir, clipPos;

		void Start()
		{
			trans = transform;
			panel = trans.parent.parent.GetComponent<UIPanel>();
			widget = GetComponent<UIWidget>();

		}

		// Update is called once per frame
		void Update()
		{
			clipPos = new Vector3(panel.clipOffset.x, 0, 0);
			dir = trans.localPosition - clipPos;
			float _distance = Mathf.Clamp(Mathf.Abs( dir.x), 0, cellWidth);

			widget.width = (int)(((cellWidth - _distance * downScale) / cellWidth) * cellWidth);
		}
	}

}