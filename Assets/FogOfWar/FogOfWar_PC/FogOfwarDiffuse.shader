// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Custom/FogOfWarDiffuse" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_FogRadius ("FogRadius", Float) = 1.0
		_FogMaxRadius("FogMaxRadius", Float) = 0.5
		_Player1_Pos ("_Player1_Pos", Vector) = (0,0,0,1)
		_Player2_Pos ("_Player2_Pos", Vector) = (0,0,0,1)
		_Player3_Pos ("_Player3_Pos", Vector) = (0,0,0,1)
	}

	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 200
		//Blend SrcAlpha OneMinusSrcAlpha
		Cull Off

		CGPROGRAM
		#pragma surface surf Lambert alpha vertex:vert
		
		sampler2D	_MainTex;
		fixed4		_Color;
		float		_FogRadius;
		float		_FogMaxRadius;
		float4		_Player1_Pos;
		float4		_Player2_Pos;
		float4		_Player3_Pos;

		struct Input {
			float2 uv_MainTex;
			float2 location; 
		};

		float powerForPos(float4 pos, float2 nearVertex);

		void vert(inout appdata_full vertexData, out Input outData) {
			//float4 pos		= UnityObjectToClipPos(vertexData.vertex);
			float4 posWorld		= mul(unity_ObjectToWorld, vertexData.vertex);
			outData.uv_MainTex	= vertexData.texcoord;
			outData.location	= posWorld.xz;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 baseColor = tex2D(_MainTex, IN.uv_MainTex) * _Color;

			o.Albedo	= baseColor.rgb; 
			o.Alpha		= baseColor.a;   
		}		

		ENDCG
	}

	Fallback "Legacy Shaders/Transparent/VertexLit"
}