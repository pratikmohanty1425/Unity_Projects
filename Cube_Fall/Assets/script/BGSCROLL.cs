using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSCROLL : MonoBehaviour
{
    public float scrollspeed = 0.3f;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        scroller();
    }

    void scroller()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scrollspeed;
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }    
}
