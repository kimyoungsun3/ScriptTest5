using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _GameSelectBox
{
	public class PuzzleBox : PuzzleMaster
	{
		public int number;
		public bool bOk;
		Material material;
		Color colorOrg;

		private void OnMouseDown()
		{
			PuzzleManager.ins.CheckNumber(number);
		}

		public override void SetInit(int _number)
		{
			gameObject.SetActive(true);
			number = _number;
			material = GetComponent<Renderer>().material;
			colorOrg = material.color;
		}

		public override void SetColor(Color _color, bool _bOk)
		{
			material.color	= _color;
			bOk				= _bOk;
		}

		public  override void Reset()
		{
			material.color = colorOrg;
		}
	}

}