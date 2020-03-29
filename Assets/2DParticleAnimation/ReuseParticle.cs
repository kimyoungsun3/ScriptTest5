using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _2DParticleAnimation
{
	public class ReuseParticle : MonoBehaviour
	{

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				ParticleSystem _ps = GetComponent<ParticleSystem>();
				if(_ps != null)
				{
					_ps.Stop();
					_ps.Play();
				}
			}
		}
	}
}