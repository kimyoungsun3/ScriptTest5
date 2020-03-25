using UnityEngine;
using System.Collections;

public enum eGameState {
	None,
	Ready, 
	Round, 
	Gaming, 
	Result
};


public delegate void DelegateVoidFunVoid();
public delegate void VOID_FUN_VOID();
public delegate void VOID_FUN_INT(int i);
public delegate void VOID_FUN_FLOAT(float f);
public delegate void VOID_FUN_GAMEOBJECT(GameObject _obj);
public delegate void VOID_FUN_TRANSFORM(Transform _tran);

public class Constant {
	public static readonly Vector3 zero 	= Vector3.zero; 
	public static readonly Vector3 one 		= Vector3.one;
	public static readonly Vector3 forward 	= Vector3.forward;
	public static readonly Vector3 up		= Vector3.up;
	public static readonly Vector3 down		= Vector3.down;
	public static readonly Vector3 right	= Vector3.right;
	public static readonly Vector3 left		= Vector3.left;

	public static readonly Vector3 V3_UP 		= Vector3.up; 
	public static readonly Vector3 V3_FORWARD 	= Vector3.forward; 
	public static readonly Vector3 V3_BACK 		= Vector3.back; 
	public static readonly Vector3 V3_RIGHT 	= Vector3.right; 
	public static readonly Vector3 V3_ONE 		= Vector3.one; 
	public static readonly Vector3 V3_ZERO 		= Vector3.zero; 

	public static readonly Vector2 V2_ONE 		= Vector2.one; 
	public static readonly Vector2 V2_ZERO 		= Vector2.zero;


	//public static readonly int SPAWNER_MATERIAL_POOL_INIT_COUNT 		= 3;
	//public static readonly int BULLETSHELL_MATERIAL_POOL_INIT_COUNT 	= 10;

	//public const float BULLET_ALIVE_TIME 		= 2f;
	//public const float BULLET_SHELL_POWER 		= 150f;
	//public const float BULLET_SHELL_ALIVE_TIME 	= 3f;
	//public const float ENEMY_SEARCH_RATE 		= .25f;

	//public static readonly float ALPHA_SELECT 	= 1f;
	//public static readonly float ALPHA_NOSELECT = .3f;  
	//public const int INT_MAX = int.MaxValue;


	//Turret...
	//public const int WEAPON_ATTACT_ANGLE = 20;

	//GameData

	public const bool DEBUG_ENEMY = false;
	
}
