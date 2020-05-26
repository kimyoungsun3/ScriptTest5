using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreadTest
{
	public class ApplicationLife : MonoBehaviour
	{
		private void Awake()		{	Debug.Log(this + " Awake");	}
		private void OnEnable()		{	Debug.Log(this + " OnEnable"); }
		private void Reset()		{	Debug.Log(this + " Reset"); }
		private void OnDisable()	{	Debug.Log(this + " OnDisable"); }
		void Start()				{	Debug.Log(this + " Start"); }
		private void FixedUpdate()	{	Debug.Log(this + " FixedUpdate"); }
		void Update()				{	Debug.Log(this + " Update"); }
		private void LateUpdate()	{	Debug.Log(this + " LateUpdate"); }
		private void OnApplicationPause(bool _pause) { Debug.Log(this + " OnApplicationPause:" + _pause ); }
		private void OnDestroy()	{ Debug.Log(this + " OnDestroy"); }
		private void OnDrawGizmos() { Debug.Log(this + " OnDrawGizmos"); }

		private void OnApplicationQuit()
		{
			Debug.Log(this + " OnApplicationQuit 0");

			Fun1();
			Debug.Log(this + " OnApplicationQuit 1");

			StartCoroutine(Co_XXX(1f));
			Debug.Log(this + " OnApplicationQuit 2");

			Fun3();
			Debug.Log(this + " OnApplicationQuit 3");
		}


		void Fun1()
		{
			Debug.Log(this + " Fun1");
		}

		IEnumerator Co_XXX(float _t)
		{
			Debug.Log(this + " Co_XXX 1:" + _t);
			while (_t >= 0f)
			{
				_t -= Time.deltaTime;
				Debug.Log(this + " Co_XXX 2:" + _t);
				yield return null;
				Debug.Log(this + " Co_XXX 3:" + _t);
			}
			Debug.Log(this + " Co_XXX 4:" + _t);
		}
		void Fun3()
		{
			Debug.Log(this + " Fun3 @@@@ ManyMany Working....@@@@ ");
			int _count = 1000 * 1000 * 500;
			int _ii = 0;
			for (int i = 0; i < _count; i++)
			{
				_ii = i;
			}
		}
	}
}