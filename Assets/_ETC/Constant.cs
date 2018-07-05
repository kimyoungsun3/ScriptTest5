using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAME_STATE {
	None,
	Ready, 
	Round, 
	Gaming, 
	Result
};
public delegate void DelegateVoidFunVoid();
public delegate void VOID_FUN_VOID();

public class Constant {

	public static readonly Vector3 V3_UP 		= Vector3.up; 
	public static readonly Vector3 V3_FORWARD 	= Vector3.forward; 
	public static readonly Vector3 V3_BACK 		= Vector3.back; 
	public static readonly Vector3 V3_RIGHT 	= Vector3.right; 
	public static readonly Vector3 V3_ONE 		= Vector3.one; 
	public static readonly Vector3 V3_ZERO 		= Vector3.zero; 

	public static readonly Vector2 V2_ONE 		= Vector2.one; 
	public static readonly Vector2 V2_ZERO 		= Vector2.zero; 

}
