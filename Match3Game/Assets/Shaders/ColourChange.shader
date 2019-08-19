// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
Shader "Custom/RainbowShader"
{
	Properties{
		_Saturation("Saturation",Range(0,1)) = 0.5
		_Luminosity("Luminosity",Range(0,1)) = 0.5
		_Spread("Spread",Range(0,10)) = 4
		_Speed("Speed",Range(-10,10)) = 0
		_Offset("TimeOffset",Range(0,7)) 0
	}
		SubShader{
		Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"
		#include "Shared/ShaderTools.cginc"

		fixed _Saturation;
		fixed _Luminosity
	    half _Spread
	    half _Speed
	    half _Offset

}
	}
}