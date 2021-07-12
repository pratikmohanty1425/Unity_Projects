using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class day : MonoBehaviour
{
    [Range(0,24)]
    public float timeofday;
    public float orbitspeed = 1;
    public Light sun;
    public Light moon;
    private bool isnight;
    private void Update()
    {
        timeofday += Time.deltaTime * orbitspeed;
        if(timeofday>24)
        {
            timeofday = 0;
        }
        updatetime();
    }

    private void OnValidate()
    {
        updatetime();
    }

    private void updatetime()
    {
        float alpha = timeofday / 24;
        float sunrotation = Mathf.Lerp(-90, 270, alpha);
        float moonrotation = sunrotation - 180;
        sun.transform.rotation = Quaternion.Euler(sunrotation, -150, 0);
        moon.transform.rotation = Quaternion.Euler(moonrotation, -150, 0);
        checknight();
    }

    void checknight()
    {
        if(isnight)
        {
            if(moon.transform.rotation.eulerAngles.x>180)
            {
                startday();
            }
        }
        else
        {
            if (sun.transform.rotation.eulerAngles.x > 180)
            {
                startnight();
            }
        }
    }

    void startday()
    {
        isnight = false;
        sun.shadows = LightShadows.Soft;
        moon.shadows = LightShadows.None;
    }

    void startnight()
    {
        isnight = true;
        sun.shadows = LightShadows.None;
        moon.shadows = LightShadows.Soft;
    }
}
