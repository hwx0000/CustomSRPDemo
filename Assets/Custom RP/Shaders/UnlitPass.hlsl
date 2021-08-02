#ifndef CUSTOM_UNLIT_PASS_INCLUDED
#define CUSTOM_UNLIT_PASS_INCLUDED

// SV代表default system value for the render target
// 这里的0.0会自动构成一个四个值都为0的float4
float4 UnlitPassVertex(float3 positionOS : POSITION) : SV_POSITION{
	return float4(positionOS, 1.0);
}


float4 UnlitPassFragment() : SV_TARGET{
	return 0.0;
}

#endif

