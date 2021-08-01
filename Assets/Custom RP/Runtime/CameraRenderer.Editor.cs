using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public partial class CameraRenderer
{
    partial void DrawGizmos();
    partial void DrawUnsupportedShaders();
    partial void PrepareForSceneView();

#if UNITY_EDITOR
    static Material errorMaterial;

    // ��������UnityĬ�ϵ�shaders
    static ShaderTagId[] legacyShaderTagIds = {
        new ShaderTagId("Always"),
        new ShaderTagId("ForwardBase"),
        new ShaderTagId("PrepassBase"),
        new ShaderTagId("Vertex"),
        new ShaderTagId("VertexLMRGBM"),
        new ShaderTagId("VertexLM")
    };

    partial void PrepareForSceneView()
    {
        if (camera.cameraType == CameraType.SceneView)
        {
            ScriptableRenderContext.EmitWorldGeometryForSceneView(camera);
        }
    }

    partial void DrawGizmos()
    {
        if (Handles.ShouldRenderGizmos())
        {
            context.DrawGizmos(camera, GizmoSubset.PreImageEffects);
            context.DrawGizmos(camera, GizmoSubset.PostImageEffects);
        }
    }


    // ����Shader�������ı���Ӧ�ÿɼ���Geometry(megenta color)
    partial void DrawUnsupportedShaders()
    {
        if (errorMaterial == null)
        {
            errorMaterial =
                new Material(Shader.Find("Hidden/InternalErrorShader"));
        }

        // DrawingSettings��������Ҫһ��������Pass, ���ﴫ���һ��
        var drawingSettings = new DrawingSettings(legacyShaderTagIds[0], new SortingSettings(camera))
        {
            overrideMaterial = errorMaterial
        };

        // Ȼ�����ʣ�µ�Shader Passes
        for (int i = 1; i < legacyShaderTagIds.Length; i++)
        {
            // ���Shader������, ��ɶ�ð���
            drawingSettings.SetShaderPassName(i, legacyShaderTagIds[i]);
        }

        // �����õ�Ĭ�ϵ�filtering, Ҳ���ǲ����κ�filter�����
        var filteringSettings = FilteringSettings.defaultValue;

        // cullingResults����֡������仯������
        context.DrawRenderers(
            cullingResults, ref drawingSettings, ref filteringSettings
        );
    }
#endif
}
