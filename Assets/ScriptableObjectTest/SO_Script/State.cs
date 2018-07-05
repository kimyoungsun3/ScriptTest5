using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="Pluggleable/State")]
public class State : ScriptableObject {
	//public int speedTurn;
	//public int speedMove;
	public Action[] action;

	public void UpdateState(ControllerState _cs){
		for (int i = 0; i < action.Length; i++)
			action [i].Act (_cs);
	}

}
