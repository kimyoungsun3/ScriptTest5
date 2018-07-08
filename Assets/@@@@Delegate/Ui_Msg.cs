using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Msg : MonoBehaviour {
	UILabel label;

	void Awake(){
		label = GetComponent<UILabel> ();
	}

	public void SetMsg(string _msg){
		label.text = _msg;
	}
}
