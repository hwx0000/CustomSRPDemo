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

    // 代表所有Unity默认的shaders
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


    // 绘制Shader不正常的本不应该可见的Geometry(megenta color)
    partial void DrawUnsupportedShaders()
    {
        if (errorMaterial == null)
        {
            errorMaterial =
                new Material(Shader.Find("Hidden/InternalErrorShader"));
        }

        // DrawingSettings里最少需要一个基本的Pass, 这里传入第一个
        var drawingSettings = new DrawingSettings(legacyShaderTagIds[0], new SortingSettings(camera))
        {
            overrideMaterial = errorMaterial
        };

        // 然后添加剩下的Shader Passes
        for (int i = 1; i < legacyShaderTagIds.Length; i++)
        {
            // 添加Shader的名字, 有啥用啊？
            drawingSettings.SetShaderPassName(i, legacyShaderTagIds[i]);
        }

        // 这里用的默认的filtering, 也就是不做任何filter处理吧
        var filteringSettings = FilteringSettings.defaultValue;

        // cullingResults是整帧都不会变化的数据
        context.DrawRenderers(
            cullingResults, ref drawingSettings, ref filteringSettings
        );
    }
#endif
}
