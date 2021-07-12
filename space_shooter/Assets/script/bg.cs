using UnityEngine;
using UnityEngine.UI;

public class bg : MonoBehaviour
{
    private float speed = 0.3f;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.x += speed * Time.deltaTime;
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
