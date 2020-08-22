using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace _GameSelectBox
{
	public class PuzzleNumber : PuzzleMaster
	{
		public int number;
		public bool bOk;
		TextMesh text;
		Color colorOrg;

		public override void SetInit(int _number)
		{
			gameObject.SetActive(true);
			number = _number;
			text = GetComponent<TextMesh>();
			text.text = number.ToString();
			colorOrg = text.color;
		}

		public override void SetColor(Color _color, bool _bOk)
		{
			text.color = _color;
			bOk = _bOk;
		}
		public override void Reset()
		{
			text.color = colorOrg;
		}
	}
}