Shader "Custom RP/Unlit" 
{
	Properties
	{
		_BaseColor("Color", Color) = (0, 0, 1.0, 1)
	}

	SubShader
	{
		Pass
		{
			HLSLPROGRAM
			// ��һ��directive, ����UnityΪ���Shader���������µİ汾
			// һ���Ǵ�GPU Instancing�İ汾, һ���ǲ���GPU Instancing�İ汾
			#pragma multi_compile_instancing 
			#pragma vertex UnlitPassVertex
			#pragma fragment UnlitPassFragment
			#include "UnlitPass.hlsl"
			ENDHLSL
		}
	}
}