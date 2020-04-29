using UnityEngine;
using System.Collections;


namespace PoolManager8
{
	public class PoolReturnTime : MonoBehaviour
	{
		//지정된 시간이 되면 풀에 돌려주기.
		[SerializeField] float lifeTime;

		protected void OnEnable()
		{
			CancelInvoke();
			Invoke("PoolReturn", lifeTime);
		}

		protected void OnDisalbe()
		{
			CancelInvoke();
		}

		protected void PoolReturn()
		{
			gameObject.SetActive(false);
		}
	}
}
