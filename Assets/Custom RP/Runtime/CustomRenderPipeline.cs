using UnityEngine;
using UnityEngine.Rendering;


public class CustomRenderPipeline : RenderPipeline
{
    public CustomRenderPipeline()
    {
        GraphicsSettings.useScriptableRenderPipelineBatching = true;
    }

    CameraRenderer cameraRenderer = new CameraRenderer();

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameraRenderer.Render(context, cameras[i]);
            //Debug.Log("第" + i + "个：" + cameras[i] + " 总个数：" + cameras.Length);
        }
    }
}