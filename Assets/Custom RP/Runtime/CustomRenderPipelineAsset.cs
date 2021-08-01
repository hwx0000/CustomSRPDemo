using UnityEngine;
using UnityEngine.Rendering;

// ��Ҫ�̳���RenderPipelineAsset, �������һ��pipeline object instance 
// Unity��ʹ����ȥ����Ⱦ, Asset����ֻ��һ��Handle��һЩSettings
[CreateAssetMenu(menuName = "Rendering/Custom Render Pipeline")]
public class CustomRenderPipelineAsset : RenderPipelineAsset
{
    // ��ȡHandle
    protected override RenderPipeline CreatePipeline()
    {
        return new CustomRenderPipeline();
    }
}