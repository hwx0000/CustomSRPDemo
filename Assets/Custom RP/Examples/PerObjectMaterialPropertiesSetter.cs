using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialPropertiesSetter : MonoBehaviour
{
    static int baseColorId = Shader.PropertyToID("_BaseColor");
    // ͨ���������������Material���Property, �������ǹ���һ��Material, ������һ��static����
    static MaterialPropertyBlock block;

    [SerializeField]
    Color baseColor = Color.white;

    private void Awake()
    {
        OnValidate();
    }

    // ��Inspector�ϸı���ֵʱ, ������������, ����Inspectorֻ��¶��һ��Color��Property
    // ����ֻҪ�޸����������ɫֵ�ͻ���ô˺���
    void OnValidate()
    {
        if (block == null)
            block = new MaterialPropertyBlock();

        // ����MaterialPropertyBlock��SetColor����
        block.SetColor(baseColorId, baseColor);
        // ��ȡ�������ϵ�MeshRenderer, 
        GetComponent<Renderer>().SetPropertyBlock(block);
    }
}
