using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundManager_ETC1
{
	public class SoundManager : MonoBehaviour
	{
		public static SoundManager ins { get; private set; }
		public void Awake()
		{
			ins = this;
		}

		public AudioClip clip1;
		public AudioClip clip2;
		private AudioSource audio_bgm;
		private AudioSource audio_onShot;

		void Start()
		{
			audio_bgm = gameObject.AddComponent<AudioSource>();
			audio_onShot = gameObject.AddComponent<AudioSource>();
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				audio_onShot.PlayOneShot(clip1);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				audio_onShot.PlayOneShot(clip2);
			}

		}
	}

}