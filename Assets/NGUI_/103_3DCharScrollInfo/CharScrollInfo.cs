using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_3DCharScrollInfo
{
	public class CharScrollInfo : MonoBehaviour
	{
		bool isPress;
		[SerializeField] Transform target;
		float speedTurn = 50f;
		Vector3 posBefore;
		
		void OnPress(bool _isPress)
		{
			if (_isPress)
			{
				posBefore = Input.mousePosition;
			}
			isPress = _isPress;
		}

		// Update is called once per frame
		void Update()
		{
			if (isPress)
			{
				if(posBefore != Input.mousePosition)
				{
					Vector3 _dir = Input.mousePosition - posBefore;
					target.Rotate(Vector3.up * -_dir.x * Time.deltaTime * speedTurn);
					posBefore = Input.mousePosition;
				}
			}
		}
	}
}
