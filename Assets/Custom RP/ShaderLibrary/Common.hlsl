#ifndef CUSTOM_COMMON_INCLUDED
#define CUSTOM_COMMON_INCLUDED
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

// ����ʹ�õ���uniform�Ķ���
#include "UnityInput.hlsl"

// UnityInput.hlsl��������һЩ����������������ʹ�õĲ���һ������
// ����Ҫ����صı������궨�壩

// W����
#define UNITY_MATRIX_M unity_ObjectToWorld
// W�����
#define UNITY_MATRIX_I_M unity_WorldToObject
// V����
#define UNITY_MATRIX_V unity_MatrixV
// VP����
#define UNITY_MATRIX_VP unity_MatrixVP
// P����
#define UNITY_MATRIX_P glstate_matrix_projection


#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/SpaceTransforms.hlsl"

#endif