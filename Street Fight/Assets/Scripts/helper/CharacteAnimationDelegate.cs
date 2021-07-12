using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteAnimationDelegate : MonoBehaviour
{
    public GameObject leftarmattackpoint, rightarmattackpoint, leftfootattackpoint, rightfootattackpoint;

    void leftarmON()
    {
        leftarmattackpoint.SetActive(true);
    }
    void leftarmOFF()
    {
        if (leftarmattackpoint.activeInHierarchy)
        {
            leftarmattackpoint.SetActive(false);
        }
    }

    void rightarmON()
    {
        rightarmattackpoint.SetActive(true);
    }
    void rightarmOFF()
    {
        if (rightarmattackpoint.activeInHierarchy)
            rightarmattackpoint.SetActive(false);
    }

    void leftfootON()
    {
        leftfootattackpoint.SetActive(true);
    }
    void leftfootOFF()
    {
        if (leftfootattackpoint.activeInHierarchy)
            leftfootattackpoint.SetActive(false);
    }

    void rightfootON()
    {
        rightfootattackpoint.SetActive(true);
    }
    void rightfootOFF()
    {
        if (rightfootattackpoint.activeInHierarchy)
            rightfootattackpoint.SetActive(false);
    }
}
