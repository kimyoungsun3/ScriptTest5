using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

namespace SoundManager6{
	public class SoundManager : MonoBehaviour {
		[Serializable]
		public class SoundData{
			public string name;  
			public AudioClip[] clips;
			public AudioSource[] sources;
			[HideInInspector] public int index;
			[HideInInspector] public int hashID;

			public void Init(){
				hashID = name.GetHashCode();
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
		public List<SoundData> listSoundData = new List<SoundData> ();
		Dictionary<int, SoundData> dicSoundData = new Dictionary<int, SoundData>();
		SoundData beforeData, currentData;

		void Awake(){
			ins = this;
			Init ();
		}

		public void Init(){
			SoundData _data;
			for (int i = 0, iMax = listSoundData.Count; i < iMax; i++) {
				_data = listSoundData [i];
				_data.Init ();

				if (!dicSoundData.ContainsKey (_data.hashID)) {
					dicSoundData.Add (_data.hashID, _data);
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
