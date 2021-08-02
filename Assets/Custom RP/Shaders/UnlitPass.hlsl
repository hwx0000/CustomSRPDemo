#ifndef CUSTOM_UNLIT_PASS_INCLUDED
#define CUSTOM_UNLIT_PASS_INCLUDED

#include "../ShaderLibrary/Common.hlsl"

// SV代表default system value for the render target
// 这里的0.0会自动构成一个四个值都为0的float4
float4 UnlitPassVertex(float3 positionOS : POSITION) : SV_POSITION{
	float3 positionWS = TransformObjectToWorld(positionOS.xyz);
	return TransformWorldToHClip(positionWS);
}

float4 UnlitPassFragment() : SV_TARGET{
	return float4(1.0,1.0,0,1.0);
}

#endif

