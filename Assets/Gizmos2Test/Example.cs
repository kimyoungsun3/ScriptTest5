using UnityEngine;
using System.Collections;

namespace Gizmos2Test{
	public class Example : MonoBehaviour {
		
		//float
		public bool debugPoint;
		public Vector3 debugPoint_Position;
		public float debugPoint_Scale;
		public Color debugPoint_Color;
		
		//vector3
		public bool debugBounds;
		public Vector3 debugBounds_Position;
		public Vector3 debugBounds_Size;
		public Color debugBounds_Color;
		
		//float, vector3
		public bool debugCircle;
		public Vector3 debugCircle_Up;
		public float debugCircle_Radius;
		public Color debugCircle_Color;
		
		//float
		public bool debugWireSphere;
		public float debugWireSphere_Radius;
		public Color debugWireSphere_Color;
		
		//vector3, float
		public bool debugCylinder;
		public Vector3 debugCylinder_End;
		public float debugCylinder_Radius;
		public Color debugCylinder_Color;
		
		//vector3, float
		public bool debugCone;
		public Vector3 debugCone_Direction;
		public float debugCone_Angle;
		public Color debugCone_Color;
		
		//vector3
		public bool debugArrow;
		public Vector3 debugArrow_Direction;
		public Color debugArrow_Color;
		
		//vector3, float
		public bool debugCapsule;
		public Vector3 debugCapsule_End;
		public float debugCapsule_Radius;
		public Color debugCapsule_Color;
		
		void OnDrawGizmos()
		{	
			if(debugPoint) Gizmos2.DrawPoint(debugPoint_Position, debugPoint_Color, debugPoint_Scale);
			if(debugBounds) Gizmos2.DrawBounds(new Bounds(new Vector3(10, 0, 0), debugBounds_Size), debugBounds_Color);
			if(debugCircle) Gizmos2.DrawCircle(new Vector3(20, 0, 0), debugCircle_Up, debugCircle_Color, debugCircle_Radius);
			if(debugWireSphere)
			{
				Gizmos.color = debugWireSphere_Color;
				Gizmos.DrawWireSphere(new Vector3(30, 0, 0), debugWireSphere_Radius);
			}
			if(debugCylinder) Gizmos2.DrawCylinder(new Vector3(40, 0, 0), debugCylinder_End, debugCylinder_Color, debugCylinder_Radius);
			if(debugCone) Gizmos2.DrawCone(new Vector3(50, 0, 0), debugCone_Direction, debugCone_Color, debugCone_Angle);
			if(debugArrow) Gizmos2.DrawArrow(new Vector3(60, 0, 0), debugArrow_Direction, debugArrow_Color);
			if(debugCapsule) Gizmos2.DrawCapsule(new Vector3(70, 0, 0), debugCapsule_End, debugCapsule_Color, debugCapsule_Radius);

		}
		
		// Update is called once per frame
		void Update () 
		{
			Gizmos2.DebugPoint(debugPoint_Position, debugPoint_Color, debugPoint_Scale);
			Gizmos2.DebugBounds(new Bounds(new Vector3(10, 0, 0), debugBounds_Size), debugBounds_Color);
			Gizmos2.DebugCircle(new Vector3(20, 0, 0), debugCircle_Up, debugCircle_Color, debugCircle_Radius);
			Gizmos2.DebugWireSphere(new Vector3(30, 0, 0), debugWireSphere_Color, debugWireSphere_Radius);
			Gizmos2.DebugCylinder(new Vector3(40, 0, 0), debugCylinder_End, debugCylinder_Color, debugCylinder_Radius);
			Gizmos2.DebugCone(new Vector3(50, 0, 0), debugCone_Direction, debugCone_Color, debugCone_Angle);
			Gizmos2.DebugArrow(new Vector3(60, 0, 0), debugArrow_Direction, debugArrow_Color);
			Gizmos2.DebugCapsule(new Vector3(70, 0, 0), debugCapsule_End, debugCapsule_Color, debugCapsule_Radius);
		}
	}
}