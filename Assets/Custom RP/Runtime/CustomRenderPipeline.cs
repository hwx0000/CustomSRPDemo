using UnityEngine;
using UnityEngine.Rendering;


public class CustomRenderPipeline : RenderPipeline
{
    CameraRenderer cameraRenderer = new CameraRenderer();

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameraRenderer.Render(context, cameras[i]);
            //Debug.Log("��" + i + "����" + cameras[i] + " �ܸ�����" + cameras.Length);
        }
    }
}