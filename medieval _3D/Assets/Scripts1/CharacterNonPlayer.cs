using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterNonPlayer : Character
{
    Slider sliderHealth;
    Camera cam;

    public override void Awake()
    {
        base.Awake();
        sliderHealth = transform.Find("Frames/BarHealth").GetComponent<Slider>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        sliderHealth.gameObject.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
        sliderHealth.maxValue = maxHealth;
        sliderHealth.value = health;

        if (health != maxHealth)
        {
            Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, gameObject.transform.position);
            position.x = position.x - sliderHealth.GetComponentInParent<RectTransform>().rect.width / 2;
            position.y = position.y - 40;

            sliderHealth.GetComponentInParent<Transform>().position = position;
            sliderHealth.gameObject.SetActive(true);
        }
        else
        {
            sliderHealth.gameObject.SetActive(false);
        }

        if (IsDead())
        {
            sliderHealth.gameObject.SetActive(false);
        }
    }
}
