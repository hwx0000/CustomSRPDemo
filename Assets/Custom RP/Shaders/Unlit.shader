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
			// 这一行directive, 会让Unity为这个Shader生成两个新的版本
			// 一个是带GPU Instancing的版本, 一个是不带GPU Instancing的版本
			#pragma multi_compile_instancing 
			#pragma vertex UnlitPassVertex
			#pragma fragment UnlitPassFragment
			#include "UnlitPass.hlsl"
			ENDHLSL
		}
	}
}