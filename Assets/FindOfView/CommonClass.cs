using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindOfView
{

	public enum eEnemyState { None, Wait, Move, Chase, Attack };
	public enum eEnemyAttack { None, HandAttack, GunAttack };

	[System.Serializable]
	public class EnemyData
	{
		public eEnemyAttack attackType = eEnemyAttack.HandAttack;
		public float speedMove = 2f;
		public float speedRun = 3f;
		public float speedTurn = 180f;
		public float waitTime = 2f;
		public Vector3[] localPoint = new Vector3[0];
		[HideInInspector] public Vector3[] wayPoints = new Vector3[0];
		public float searchTime = .5f;
		public float radius = 3f;
		public float radiusMarge = 3f;
		public float radiusAttack = 2f;
		public float attackTime = .5f;

		public float shootSpeed = 6f;
		public float damagePower = 2f;
	}
}