using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace SoundManager8{
	public class SoundManager : MonoBehaviour {
		[Serializable]
		public class SoundData{
			[SerializeField] string name;  
			[SerializeField] AudioClip[] clips;
			[SerializeField] AudioMixerGroup mixer;
			[SerializeField] int sourcesCount;
			[Header("----AudioSouce 자동생성---")]
			[SerializeField] AudioSource[] sources;
			[HideInInspector] public int index;
			[HideInInspector] public int hashID;

			public void Init(Transform _parent) {
				hashID = name.GetHashCode();
			}

			public void CreateAudioSource(Transform _parent)
			{ 
				sources = new AudioSource[sourcesCount];
				GameObject _go;
				for (int i = 0; i < sourcesCount; i++)
				{
					_go = new GameObject(name + i);
					_go.transform.SetParent(_parent);
					sources[i] = _go.AddComponent<AudioSource>();
					sources[i].playOnAwake = false;
					if (mixer != null) sources[i].outputAudioMixerGroup = mixer;
				}				
			}

			public void Play(bool _bLoop, int _clipIdx = -1){
				//Debug.Log (name + ", " + index);
				if (_clipIdx == -1) {
					_clipIdx = Random.Range (0, clips.Length);
				}
				//Debug.Log ("play:" + _clipIdx + ":" + index);

				sources [index].Stop ();
				sources [index].loop 	= _bLoop;
				sources [index].clip 	= clips[_clipIdx];
				sources [index].Play ();

				//indexBefore = index;
				index = ( index + 1 ) % sources.Length; 
			}

			//public void Stop(){
			//	sources [indexBefore].Stop ();
			//}

			public void AllStop(){
				for (int i = 0, iMax = sources.Length; i < iMax; i++) {
					sources [i].Stop ();
				}
			}			
		}

		public static SoundManager ins { get; private set; }
		public List<SoundData> listSoundData	= new List<SoundData> ();
		Dictionary<int, SoundData> dicSoundData = new Dictionary<int, SoundData>();
		SoundData beforeData, currentData;

		void Awake(){
			ins = this;
			Init();
		}


		public void Init()
		{			
			// Holder Create
			Transform _holder = transform.Find("Holder");
			if (_holder != null)
			{
				DestroyImmediate(_holder.gameObject);
			}
			_holder = (new GameObject("Holder")).transform;
			_holder.SetParent(transform);

			//Data Create
			SoundData _data;
			for (int i = 0, imax = listSoundData.Count; i < imax; i++) {
				_data = listSoundData [i];
				_data.Init(_holder);
				_data.CreateAudioSource(_holder);
				if (!dicSoundData.ContainsKey(_data.hashID))
				{
					dicSoundData.Add(_data.hashID, _data);
				}
			}
		}

		//Play("xxx", true)   	-> xxx 1번 loop
		//Play("xxx", false)  	-> xxx 1번 one shoot
		//Play("xxx", -1) 		-> xxx 1번 one shoot
		public void Play(string  _name, bool _bLoop, int _clipIdx = -1){
			//Debug.Log ("name:" + _name + " loop:" + _bLoop);
			int _hashID = _name.GetHashCode();
			Play (_hashID, _bLoop, _clipIdx);
		}

		public void Play(int _hashID){
			Play (_hashID, false);
		}

		public void Play(int _hashID, bool _bLoop, int _clipIdx = -1){
			//Debug.Log ("SoundManager Play _bLoop:" + _bLoop);
			bool _rtn = false;
			if (beforeData != null && beforeData.hashID == _hashID) {
				currentData = beforeData;
			}else{
				currentData = FindSound (_hashID, string.Empty);
			}
			beforeData = currentData;

			if (currentData != null) {
				currentData.Play (_bLoop, _clipIdx);
			}
		}

		public void Stop(string  _name){
			//Debug.Log ("SoundManager Stop _name:" + _name);
			int _hashID = _name.GetHashCode();
			SoundData _data = FindSound (_hashID, _name);
			if (_data != null) {
				_data.AllStop ();
			}
		}

		SoundData FindSound(int _hashID, string _name){
			//Debug.Log ("SoundManager FindSound _hashID:" + _hashID);
			SoundData _data = null;
			if (dicSoundData.ContainsKey (_hashID)) 
			{
				_data = dicSoundData [_hashID];
			} else {
				Debug.LogError ("사운드 이름(hashID):" + _name + ":" + _hashID);
			}

			return _data;
		}
	}
}
