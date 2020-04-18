using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = Joystick_UGUI2.Input;

//1. VariableJoystick를 우선 순위에서 올려주세요....
//2. Input를 등록해서 사용하시기를 권함....
namespace Joystick_UGUI2
{
	public class PlayerMove : MonoBehaviour
	{
		public float speed = 3f;
		Transform trans;
		Vector3 move;
		Vector3 zero = Vector3.zero;
		eSkillNumber skillNumber;
		[SerializeField] Bullet bullet;
		[SerializeField] List<Transform> firepoint = new List<Transform>();

		void Start()
		{
			trans = transform;
		}

		public void SetSkill(eSkillNumber _skill)
		{
			skillNumber = _skill;
		}

		void Update()
		{
			eSkillNumber _skill = skillNumber;
			skillNumber			= eSkillNumber.None;
			
			move.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
			if(move != zero)
				trans.Translate(move.normalized * speed * Time.deltaTime);

			if (_skill != eSkillNumber.None)
			{
				switch (_skill)
				{
					case eSkillNumber.Skill1:
						Instantiate(bullet, firepoint[0].position, firepoint[0].rotation);
						break;
					case eSkillNumber.Skill2:
						Instantiate(bullet, firepoint[1].position, firepoint[1].rotation);
						Instantiate(bullet, firepoint[2].position, firepoint[2].rotation);
						break;
					case eSkillNumber.Skill3:
						Instantiate(bullet, firepoint[0].position, firepoint[0].rotation);
						Instantiate(bullet, firepoint[1].position, firepoint[1].rotation);
						Instantiate(bullet, firepoint[2].position, firepoint[2].rotation);
						break;
					case eSkillNumber.Skill4:
						Instantiate(bullet, firepoint[0].position, firepoint[0].rotation);
						Instantiate(bullet, firepoint[1].position, firepoint[1].rotation);
						Instantiate(bullet, firepoint[2].position, firepoint[2].rotation);
						Instantiate(bullet, firepoint[3].position, firepoint[3].rotation);
						Instantiate(bullet, firepoint[4].position, firepoint[4].rotation);
						break;
				}
			}
		}
	}
}