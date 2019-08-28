using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletPattern{
	public enum BulletType { 
		Normal, 
		//Delay, 
		SpeedChange,
		Missile
	};
	public enum SpawnType { 
		Circle,
		Circle2,
		Arc
	};

	[System.Serializable]
	public class SpawnInfo{
		public string name;
		public SpawnType type = SpawnType.Circle;

		//circle
		//[Header("Circle 변수")]
		[Space]
		public int circleAmount		= 2;	//circle amount
		public float circleGapTime	= 1f;	//circle - circle (gap time)
		public int circleCount 		= 2;	//compose count, 1 circle
		public float circleRadius	= 1f;
		public float circleRotateStep= 0f;	//회전하면서 분배하면 꽃이된다.

		//Arc
		[Space]
		public int arcAmount		= 1;	//arc amount 
		public float arcGapTime		= .2f;	//arc - arc (gap time)
		public int arcCount 		= 1;	//compose count, 1 circle
		public float arcRadius		= 1f;
		public float arcAngleStep	= 0f;	//회전하면서 분배하면 꽃이된다.
		public bool arcTarget		= false;
		public float arcShake 		= 0;	//5'정도 흔들려서 발사.
	
		//유도탄 (항상 타켓팅).
		[Space]
		public BulletType bulletType = BulletType.Normal;
		public float bulletDelayTime	= 0f;
		public float bulletSpeed 		= 1f;
		public float bulletSpeedChangeTime	= 0f;
		public float bulletSpeedChangeSpeed	= 2f;	//변경되는 스피드.
		public float bulletMissleTime	= 0f;		//0: 유도 시간을 나타냄...
		public float bulletMissleTurnInter= 1f; 		// 1 over is fast turn
	}
}
