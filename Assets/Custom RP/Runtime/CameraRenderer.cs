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

    // 由RenderPipeline的Render函数每帧调用此函数
    public void Render(ScriptableRenderContext context, Camera camera)
    {
        this.context = context;
        this.camera = camera;

        PrepareForSceneView();

        if (!Cull())
        {
            return;
        }
        // Update相机的属性
        context.SetupCameraProperties(camera);

        CameraClearFlags flags = camera.clearFlags;
        buffer.ClearRenderTarget(flags <= CameraClearFlags.Depth, flags == CameraClearFlags.Color,
            flags == CameraClearFlags.Color ? camera.backgroundColor.linear:
            Color.clear);
        // 在每次渲染开始时, 先begin sample
        buffer.name = camera.name;
        buffer.BeginSample(buffer.name);

        // 然后执行CommandBuffer, 执行完了清空
        context.ExecuteCommandBuffer(buffer);
        buffer.Clear();

        // 1. 绘制所有可见的Geometry
        // 绘制
        // 其实就是调用一堆封装好的API而言
        var sortingSettings = new SortingSettings(camera)
        {
            criteria = SortingCriteria.CommonOpaque
        };

        var drawingSettings = new DrawingSettings(unlitShaderTagId, sortingSettings);
        var filteringSettings = new FilteringSettings(RenderQueueRange.opaque);

        // 调用context的DrawRenderers函数
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

        // 然后结束这次Sample工作
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
