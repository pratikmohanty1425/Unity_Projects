using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animcontroller : MonoBehaviour
{
    [SerializeField]
    private Animator playerchoiseanim, choiseanim;
    public void resteanim()
    {
        playerchoiseanim.Play("show");
        choiseanim.Play("remove");

    }
    public void playermadechoise()
    {
        playerchoiseanim.Play("remove");
        choiseanim.Play("show_ch");
    }
}
