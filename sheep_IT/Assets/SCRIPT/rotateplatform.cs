using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateplatform : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotateangle;

    private Quaternion initialrotation;

    [SerializeField]
    private float smoothrotate = 1;

    [SerializeField]
    private bool canrotate;

    private bool backtoinitial;

    [SerializeField]
    private float deactivatetimer;

    private AudioSource audio;

    public static rotateplatform instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        audio = GetComponent<AudioSource>();
        initialrotation = transform.rotation;
    }


    private void Update()
    {
        updateplatform();
    }

    void updateplatform()
    {
        if(canrotate)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation, Quaternion.Euler(
                    rotateangle.x, rotateangle.y, rotateangle.z),
                Time.deltaTime * smoothrotate);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation, Quaternion.Euler(
                    initialrotation.x, initialrotation.y, initialrotation.z),
                Time.deltaTime * smoothrotate);
        }
    }

    public void activerotate()
    {
        if(!canrotate)
        {
            canrotate = true;
            platformsound.instance.playaudio(true);
            Invoke("Deactivaterotation", deactivatetimer);
        }
    }

    void Deactivaterotation()
    {
        canrotate = false;
        platformsound.instance.playaudio(false);
    }
}
