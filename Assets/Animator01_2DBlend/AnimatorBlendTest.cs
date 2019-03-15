using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimatorTest01
{
	public class AnimatorBlendTest : MonoBehaviour
	{
		Animator animator;
		string strCharStats		= "CharStats";
		float charStats			= 0;

		void Start()
		{
			animator = GetComponent<Animator>();
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				charStats = 0;
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				charStats = 1;
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				charStats = 2;
			}

			animator.SetFloat(strCharStats, charStats);
		}
	}
}