#ifndef CUSTOM_UNLIT_PASS_INCLUDED
#define CUSTOM_UNLIT_PASS_INCLUDED

#include "../ShaderLibrary/Common.hlsl"

CBUFFER_START(UnityPerMaterial)
	float4 _BaseColor;
CBUFFER_END

// SV����default system value for the render target
// �����0.0���Զ�����һ���ĸ�ֵ��Ϊ0��float4
float4 UnlitPassVertex(float3 positionOS : POSITION) : SV_POSITION{
	float3 positionWS = TransformObjectToWorld(positionOS.xyz);
	return TransformWorldToHClip(positionWS);
}

float4 UnlitPassFragment() : SV_TARGET{
	return _BaseColor;
}

#endif

