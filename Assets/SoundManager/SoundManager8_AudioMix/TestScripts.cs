using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundManager8
{
	public class TestScripts : MonoBehaviour
	{
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				SoundManager.ins.Play("BGM", true);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				SoundManager.ins.Play("ItemEat", false);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				SoundManager.ins.Play("PlayerAttack", false);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				SoundManager.ins.Play("PlayerJump", false);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				SoundManager.ins.Play("PlayerAttack", false);
			}
		}
	}
}
