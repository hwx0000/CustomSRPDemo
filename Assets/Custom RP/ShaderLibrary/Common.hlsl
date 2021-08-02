#ifndef CUSTOM_COMMON_INCLUDED
#define CUSTOM_COMMON_INCLUDED
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

// 这里使用到了uniform的东西
#include "UnityInput.hlsl"

// UnityInput.hlsl里声明的一些矩阵跟这个函数里面使用的不是一个名字
// 所以要加相关的别名（宏定义）

// W矩阵
#define UNITY_MATRIX_M unity_ObjectToWorld
// W逆矩阵
#define UNITY_MATRIX_I_M unity_WorldToObject
// V矩阵
#define UNITY_MATRIX_V unity_MatrixV
// VP矩阵
#define UNITY_MATRIX_VP unity_MatrixVP
// P矩阵
#define UNITY_MATRIX_P glstate_matrix_projection


#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/SpaceTransforms.hlsl"

#endif