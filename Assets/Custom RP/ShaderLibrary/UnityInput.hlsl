#ifndef CUSTOM_UNITY_INPUT_INCLUDED
#define CUSTOM_UNITY_INPUT_INCLUDED

float4x4 unity_ObjectToWorld;
float4x4 unity_WorldToObject;
float4x4 unity_MatrixVP;
float4x4 unity_MatrixV;
float4x4 glstate_matrix_projection;

// �����real4����pipelines.core/ShaderLibrary/Common.hlsl��
// ����ı���, �������Ǹ�float4����half4
// ֻ����ΪҪinclude��׼�����SpaceTransform.hlsl�żӽ�����
real4 unity_WorldTransformParams;

#endif