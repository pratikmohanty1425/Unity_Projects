using System.ComponentModel;
using UnityEngine;

public class roperenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField]
    private Transform linestartpoint;

    private float linewidth = 0.05f;

    public static roperenderer instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = linewidth;
        lineRenderer.enabled = false;
    }

    void Start()
    {
        
    }

    public void renderline(Vector3 endpos,bool enable)
    {
        if(enable)
        {
            if(!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
            }
            lineRenderer.positionCount = 2;
        }
        else
        {
            lineRenderer.positionCount = 0;
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }

        if(lineRenderer.enabled)
        {
            Vector3 temp = linestartpoint.position;
            temp.z = -10;
            linestartpoint.position = temp;

            temp = endpos;
            temp.z = 0;

            endpos = temp;

            lineRenderer.SetPosition(0, linestartpoint.position);
            lineRenderer.SetPosition(1, endpos);
        }
    }
}
