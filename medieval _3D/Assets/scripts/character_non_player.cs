using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character_non_player : character
{
    Slider sliderhealth;
    Camera cam;

    public override void Awake()
    {
        base.Awake();
        sliderhealth = transform.Find("Frames/BarHealth").GetComponent<Slider>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        sliderhealth.gameObject.SetActive(false);
    }
    public override void Update()
    {
        base.Update();
        sliderhealth.maxValue = maxhealth;
        sliderhealth.value = health;

        if(health!=maxhealth)
        {
            Vector3 pos = RectTransformUtility.WorldToScreenPoint(cam,gameObject.transform.position);
            pos.x = pos.x - sliderhealth.GetComponent<RectTransform>().rect.width / 2;
            pos.y -= 40;

            sliderhealth.GetComponentInParent<Transform>().position = pos;
            sliderhealth.gameObject.SetActive(true);
        }
        else
        {
            sliderhealth.gameObject.SetActive(false);
        }

        if(isdead())
        {
            sliderhealth.gameObject.SetActive(false);
        }
    }
}
