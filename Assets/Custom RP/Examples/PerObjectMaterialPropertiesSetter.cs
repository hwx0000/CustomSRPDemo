using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialPropertiesSetter : MonoBehaviour
{
    static int baseColorId = Shader.PropertyToID("_BaseColor");
    // 通过这个东西来设置Material里的Property, 由于它们共享一个Material, 所以是一个static变量
    static MaterialPropertyBlock block;

    [SerializeField]
    Color baseColor = Color.white;

    private void Awake()
    {
        OnValidate();
    }

    // 当Inspector上改变数值时, 会调用这个函数, 由于Inspector只暴露了一个Color的Property
    // 所以只要修改了上面的颜色值就会调用此函数
    void OnValidate()
    {
        if (block == null)
            block = new MaterialPropertyBlock();

        // 调用MaterialPropertyBlock的SetColor函数
        block.SetColor(baseColorId, baseColor);
        // 获取物体身上的MeshRenderer, 
        GetComponent<Renderer>().SetPropertyBlock(block);
    }
}
