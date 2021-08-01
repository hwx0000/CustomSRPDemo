using UnityEngine;
using UnityEngine.Rendering;

public partial class CameraRenderer
{

    ScriptableRenderContext context;

    Camera camera;

    const string bufferName = "Render Camera";

    CommandBuffer buffer = new CommandBuffer
    {
        //name = bufferName
    };

    CullingResults cullingResults;

    static ShaderTagId unlitShaderTagId = new ShaderTagId("SRPDefaultUnlit");

    // ��RenderPipeline��Render����ÿ֡���ô˺���
    public void Render(ScriptableRenderContext context, Camera camera)
    {
        this.context = context;
        this.camera = camera;

        PrepareForSceneView();

        if (!Cull())
        {
            return;
        }
        // Update���������
        context.SetupCameraProperties(camera);

        CameraClearFlags flags = camera.clearFlags;
        buffer.ClearRenderTarget(flags <= CameraClearFlags.Depth, flags == CameraClearFlags.Color,
            flags == CameraClearFlags.Color ? camera.backgroundColor.linear:
            Color.clear);
        // ��ÿ����Ⱦ��ʼʱ, ��begin sample
        buffer.name = camera.name;
        buffer.BeginSample(buffer.name);

        // Ȼ��ִ��CommandBuffer, ִ���������
        context.ExecuteCommandBuffer(buffer);
        buffer.Clear();

        // 1. �������пɼ���Geometry
        // ����
        // ��ʵ���ǵ���һ�ѷ�װ�õ�API����
        var sortingSettings = new SortingSettings(camera)
        {
            criteria = SortingCriteria.CommonOpaque
        };

        var drawingSettings = new DrawingSettings(unlitShaderTagId, sortingSettings);
        var filteringSettings = new FilteringSettings(RenderQueueRange.opaque);

        // ����context��DrawRenderers����
        context.DrawRenderers(
            cullingResults, ref drawingSettings, ref filteringSettings
        );

        context.DrawSkybox(camera);

        sortingSettings.criteria = SortingCriteria.CommonTransparent;
        drawingSettings.sortingSettings = sortingSettings;
        filteringSettings.renderQueueRange = RenderQueueRange.transparent;

        context.DrawRenderers(cullingResults, ref drawingSettings, ref filteringSettings);

        DrawUnsupportedShaders();
        DrawGizmos();

        // Ȼ��������Sample����
        buffer.EndSample(buffer.name);
        context.ExecuteCommandBuffer(buffer);
        buffer.Clear();
        context.Submit();
    }

    bool Cull()
    {
        if (camera.TryGetCullingParameters(out ScriptableCullingParameters parameters))
        {
            cullingResults = context.Cull(ref parameters);
            return true;
        }

        return false;
    }
}
