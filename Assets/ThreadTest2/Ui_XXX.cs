using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
//using System.Threading.Task;

namespace ThreadTest2
{
	public class Ui_XXX : MonoBehaviour
	{

		[SerializeField] UILabel label1;
		[SerializeField] UILabel label2;
		[HideInInspector] public int data1, data2;
		private void Update()
		{

			label1.text = data1.ToString();
			label2.text = data2.ToString();
		}

		public void InovkeFun1()
		{
			ThreadStart _ts = delegate ()
			{
				int _loop = 0;
				while (_loop < 5)
				{
					_loop++;
					data1++;
					//작동안함...
					//label1.text = data1.ToString();
					Thread.Sleep(100);
				}
			};
			Thread _tt = new Thread(_ts);
			_tt.Start();
		}

		public void InovkeFun2()
		{
			ThreadStart _ts = delegate ()
			{
				int _loop = 0;
				while (_loop < 5)
				{
					_loop++;
					data2++;
					Thread.Sleep(100);
				}
			};
			Thread _tt = new Thread(_ts);
			_tt.Start();

		}
	}
}
