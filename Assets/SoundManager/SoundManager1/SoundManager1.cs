using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class SoundManager1 : MonoBehaviour {
	[Serializable]
	public class SoundData{
		public bool pitchRandom = true;
		public AudioClip clip;
		public int channel 	= 1;
		public int channel2 = -1;
		public string name; 
		[HideInInspector]public bool bChange;
	}

	private static SoundManager1 ins_;
	public static SoundManager1 ins{
		get{
			return ins_;
		}
		set{ ins_ = value; }
	}
	public float pitchLower = 0.95f;
	public float pitchUp = 1.05f;
	public AudioSource[] music;
	public List<SoundData> soundDataList = new List<SoundData> ();
	SoundData beforeData;
	bool bInit = false;
	int nameNum = 0;
	int channel;

	void Awake(){
		if (ins == null) {
			ins = this;
		} else if (ins_ != this) {
			//전것존재 -> 또다른것 -> 삭제. 이후는 실행안됨(Start, OnEnable)...
			//Debug.Log ("또생성? 음... 삭제(지금것)");
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);
	}

	//bool bStart = false;
	//void Start(){
	//	bStart = true;
	//}

	//Play("xxx", 1, true)   -> xxx 1번 loop
	//Play("xxx", 1, false)  -> xxx 1번 one shoot
	//Play("xxx", -1) -> xxx 1번 one shoot
	public void Play(string  _name, int _playerNum, bool _bLoop){
		//Debug.Log ("SoundManager Play _name:" + _name + " _playerNum:" + _playerNum + " _bLoop:" + _bLoop);
		if (Play (_name, _playerNum)) {
			music [channel].loop = _bLoop;
		}
	}

	//
	public bool Play(string _name, int _playerNum){
		bool _rtn = false;
		//Debug.Log ("SoundManager Play _name:" + _name + ", _playerNum:" + _playerNum);
		if (beforeData != null && beforeData.name.Equals (_name)) {
			//before data reuse.
			beforeData = beforeData;
		}else{
			//find
			beforeData = FindSound (_name);
		}

		if (beforeData != null) {
			if(_playerNum == -1){
				channel = GetChennel (beforeData);
			}else{
				channel = GetChennel(_playerNum, beforeData);
			}

			if (beforeData.pitchRandom) {
				music [channel].pitch = Random.Range (pitchLower, pitchUp);
			}
			music [channel].Stop ();
			music [channel].clip = beforeData.clip;
			music [channel].Play ();

			_rtn = true;
		}
		return _rtn;
	}


	public void Stop(string  _name, int _playerNum){
		//Debug.Log ("SoundManager Stop _name:" + _name + ", _playerNum:" + _playerNum);
		SoundData _data = FindSound (_name);
		if (_data != null) {
			//Debug.Log (" > name found");
			channel = GetChennel (_playerNum, _data);
			//Debug.Log ("  > " + _name + ", " + _playerNum + " -> " + channel + ":" + music.Length);
			if (channel >= 0 && channel < music.Length && music [channel] != null) {
				//Debug.Log ("  > " + channel);
				music [channel].Stop ();
			}
		//} else {
		//	Debug.Log (" > name not found");
		}
	}

	// 1, 2번 유저...
	int GetChennel(int _playerNum, SoundData _data){
		//Debug.Log ("SoundManager GetChennel _playerNum:" + _playerNum + ", _data:" + _data);
		int _channel = _data.channel;
		switch(_playerNum){
		case 1:
			_channel = _data.channel;
			break;
		case 2:
			_channel = _data.channel2;
			break;
		}
		return _channel;
	}

	//지정이 없으면 효율적으로...
	int GetChennel(SoundData _data){
		//Debug.Log ("SoundManager GetChennel _data:" + _data);
		int _channel = _data.channel;

		if (_data.channel2 == -1) {
			channel = _data.channel;
		} else {
			if (_data.bChange == false) {
				channel = _data.channel;
			} else {
				channel = _data.channel2;
			}
			_data.bChange = !_data.bChange;
		}
		return _channel;
	}

	public void Stop(int _channel){
		//Debug.Log ("SoundManager Stop _channel:"+_channel);
		music [_channel].Stop ();
	}

	SoundData FindSound(string _name){
		//Debug.Log ("SoundManager FindSound _name:"+_name);
		SoundData _data = null;

		for (int i = 0; i < soundDataList.Count; i++) {
			if (soundDataList [i].name.Equals (_name)) {
				_data = soundDataList[i];
				break;
			}
		}

		#if UNITY_EDITOR
		if(_data == null){
			Debug.LogError ("사운드 이름 없음:" + _name);
		}
		#endif

		return _data;
	}
}
