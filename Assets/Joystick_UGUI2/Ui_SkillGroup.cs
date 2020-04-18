using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Input = Joystick_UGUI2.Input;


namespace Joystick_UGUI2
{
	public enum eSkillNumber { None, Skill1, Skill2, Skill3, Skill4};
	public class Ui_SkillGroup : MonoBehaviour
	{
		private void Start()
		{
			skill1.gameObject.SetActive(false);
			skill2.gameObject.SetActive(false);
			skill3.gameObject.SetActive(false);
			skill4.gameObject.SetActive(false);
		}

#if UNITY_EDITOR
		private void Update()
		{
			if (Input.GetKeyUp(KeyCode.L))
			{
				Inovke_Skill1();
			}
			else if (Input.GetKeyUp(KeyCode.K))
			{
				Inovke_Skill2();
			}
			else if (Input.GetKeyUp(KeyCode.O))
			{
				Inovke_Skill3();
			}
			else if (Input.GetKeyUp(KeyCode.P))
			{
				Inovke_Skill4();
			}
		}
#endif

		[SerializeField] PlayerMove player;
		[SerializeField] Image skill1;
		public void Inovke_Skill1()
		{
			if (!skill1.gameObject.activeSelf)
			{
				//1. 스킬발동 전달...		
				player.SetSkill(eSkillNumber.Skill1);

				//2. 스킬 쿨타임 가동...
				StartCoroutine(Co_Skill(skill1, UserData.ins.skill1));
			}
		}

		[SerializeField] Image skill2;
		public void Inovke_Skill2()
		{
			if (!skill2.gameObject.activeSelf)
			{
				//1. 스킬발동 전달...
				player.SetSkill(eSkillNumber.Skill2);

				//2. 스킬 쿨타임 가동...
				StartCoroutine(Co_Skill(skill2, UserData.ins.skill2));
			}
		}

		[SerializeField] Image skill3;
		public void Inovke_Skill3()
		{
			if (!skill3.gameObject.activeSelf)
			{
				//1. 스킬발동 전달...
				player.SetSkill(eSkillNumber.Skill3);

				//2. 스킬 쿨타임 가동...
				StartCoroutine(Co_Skill(skill3, UserData.ins.skill3));
			}
		}

		[SerializeField] Image skill4;
		public void Inovke_Skill4()
		{
			if (!skill4.gameObject.activeSelf)
			{
				//1. 스킬발동 전달...
				player.SetSkill(eSkillNumber.Skill4);

				//2. 스킬 쿨타임 가동...
				StartCoroutine(Co_Skill(skill4, UserData.ins.skill4));
			}
		}

		IEnumerator Co_Skill(Image _skill, float _duration)
		{
			_skill.gameObject.SetActive(true);
			float _speed		= 1f / _duration;
			float _percent		= 1f;
			_skill.fillAmount	= _percent;
			while(_percent >= 0f)
			{
				_percent -= _speed * Time.deltaTime;
				_skill.fillAmount = _percent;
				yield return null;
			}
			_skill.fillAmount = 0f;
			_skill.gameObject.SetActive(false);
		}


	}
}