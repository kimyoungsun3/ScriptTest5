using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Algorim{
	public static class  SSUtil {

		/*public static void BubbleSort(float[] _arr){
			int i, j;
			int iMax = _arr.Length - 1;
			int jMax;
			float _temp;
			for (i = 0; i < iMax; i++) {
				jMax = iMax - i;
				for (j = 0; j < jMax; j++) {
					if (_arr [j] > _arr [j + 1]) {
						_temp = _arr [j];
						_arr [j] = _arr [j + 1];
						_arr [j + 1] = _temp;
					}
				}
			}
		}*/

		public static void BubbleSort<T>(T[] _arr) where T: System.IComparable<T>
		{
			int i, j;
			int iMax = _arr.Length - 1;
			int jMax;
			T _temp;
			for (i = 0; i < iMax; i++) {
				jMax = iMax - i;
				for (j = 0; j < jMax; j++) {
					if (_arr [j].CompareTo(_arr [j + 1]) > 0) {
						_temp = _arr [j];
						_arr [j] = _arr [j + 1];
						_arr [j + 1] = _temp;
					}
				}
			}
		}


		public static void SelectSort<T>(T[] _arr) where T: System.IComparable<T>
		{
			int i, j;
			int iMax = _arr.Length;
			int _idx;
			T _min, _temp;
			for (i = 0; i < iMax; i++) {
				_min = _arr [i];
				_idx = i;

				for (j = i + 1; j < iMax; j++) {
					if (_min.CompareTo(_arr [j]) > 0) {
						_min = _arr [j];
						_idx = j;
					}
				}

				_temp 			= _arr [_idx];
				_arr [_idx] 	= _arr [i];
				_arr [i] 		= _temp;
			}
		}



		public static void Display(float[] _arr){
			System.Text.StringBuilder _sb = new System.Text.StringBuilder ();
			for (int i = 0, iMax = _arr.Length; i < iMax; i++) {
				_sb.Append (_arr [i]);
				_sb.Append (" ");
			}
			Debug.Log (_sb.ToString ());
		}
	}
}