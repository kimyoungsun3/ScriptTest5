using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platform_Door_Elevator
{
	public class Ui_Score : MonoBehaviour
	{
		#region singletone
		public static Ui_Score ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion

		public Text text;
		int totalCoins;

		private void Start()
		{
			totalCoins = 0;
			text.text = "0";
		}

		public void SetScore(int _plusCoin)
		{
			totalCoins += _plusCoin;
			text.text = "" + totalCoins;
		}
	}
}