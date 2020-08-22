using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _GameSelectBox
{
	public abstract class PuzzleMaster : MonoBehaviour
	{
		public abstract void SetInit(int _number);
		public abstract void SetColor(Color _color, bool _bOk);
		public abstract void Reset();
	}
}