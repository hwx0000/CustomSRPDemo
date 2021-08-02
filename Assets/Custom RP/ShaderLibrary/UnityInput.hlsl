#ifndef CUSTOM_UNITY_INPUT_INCLUDED
#define CUSTOM_UNITY_INPUT_INCLUDED

float4x4 unity_ObjectToWorld;
float4x4 unity_WorldToObject;
float4x4 unity_MatrixVP;
float4x4 unity_MatrixV;
float4x4 glstate_matrix_projection;

// 这里的real4是在pipelines.core/ShaderLibrary/Common.hlsl里
// 定义的别名, 本质上是个float4或者half4
// 只是因为要include标准库里的SpaceTransform.hlsl才加进来的
real4 unity_WorldTransformParams;

#endif