using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour
{
    private Camera cam = null;

    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Vector2 mpos = cam.ScreenToWorldPoint(Input.mousePosition);

        Cursor.visible = mpos.x < -8.5f || mpos.x > 8.5f || mpos.y < -3.5f || mpos.y > 4.5f;

        transform.position = new Vector3(Mathf.Clamp(mpos.x , -8.5f, 8.5f), Mathf.Clamp(mpos.y, -3.5f, 3f));
    }
}
