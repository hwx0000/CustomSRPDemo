using UnityEngine;
using UnityEngine.Rendering;

// 需要继承于RenderPipelineAsset, 此类代表一个pipeline object instance 
// Unity会使用它去做渲染, Asset本质只是一个Handle和一些Settings
[CreateAssetMenu(menuName = "Rendering/Custom Render Pipeline")]
public class CustomRenderPipelineAsset : RenderPipelineAsset
{
    // 获取Handle
    protected override RenderPipeline CreatePipeline()
    {
        return new CustomRenderPipeline();
    }
}