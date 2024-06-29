using UnityEngine;

[DisallowMultipleComponent]
[ExecuteInEditMode]
public class PerObjectMaterialProperties : MonoBehaviour
{
    static MaterialPropertyBlock block;

    static int baseColorId = Shader.PropertyToID("_BaseColor");

    [SerializeField]
    Color baseColor = Color.white;

    void OnValidate()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        block.SetColor(baseColorId, baseColor);
        GetComponent<Renderer>().SetPropertyBlock(block);
    }

    void Awake()
    {
        OnValidate();
    }

    private void OnDestroy()
    {
        GetComponent<Renderer>().SetPropertyBlock(null);

    }
}