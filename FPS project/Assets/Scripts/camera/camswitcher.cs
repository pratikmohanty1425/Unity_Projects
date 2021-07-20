using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class camswitcher : MonoBehaviour
{
    public GameObject FPPcam;
    public GameObject FppCM;
    public GameObject TPPcam;
    public GameObject TppCM;

    public bool tpp = false;

    public static camswitcher instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        FPPcam.SetActive(true);
        FppCM.SetActive(true);
        TPPcam.SetActive(false);
        TppCM.SetActive(false);
    }
    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            if (tpp == false)
            {
                TPPcam.SetActive(true);
                TppCM.SetActive(true);
                FPPcam.SetActive(false);
                FppCM.SetActive(false);
                tpp = true;
            }
            else
            {
                FPPcam.SetActive(true);
                FppCM.SetActive(true);
                TPPcam.SetActive(false);
                TppCM.SetActive(false);
                tpp = false;
            }
        }
    }
}
