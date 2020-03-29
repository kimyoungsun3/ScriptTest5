using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMLTest01
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager ins;
		public void Awake()
		{
			ins = this;
		}
		public void ChangeState()
		{

		}
	}
}
