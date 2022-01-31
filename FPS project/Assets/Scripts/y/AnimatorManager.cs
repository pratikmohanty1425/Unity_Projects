using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private Animator animator;

    private int horizontal;
    private int vertical;

    public static AnimatorManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float Hmovement,float Vmovement)
    {
        /*float snappedHorizontal;
        float snappedVertical;

        #region Snapped Horizontal
        if (Hmovement>0 && Hmovement < 0.55f)
        {
            snappedHorizontal = 0.5f;
        }
        else if(Hmovement>0.55f){
            snappedHorizontal = 1;
        }
        else if(Vmovement<0 && Hmovement > -0.55f)
        {
            snappedHorizontal = -0.5f;
        }
        else if (Hmovement < 0.55f)
        {
            snappedHorizontal = -1;
        }
        else
        {
            snappedHorizontal = 0;
        }
        #endregion
        #region Snapped Vertical
        if (Vmovement > 0 && Vmovement < 0.55f)
        {
            snappedVertical = 0.5f;
        }
        else if (Vmovement > 0.55f)
        {
            snappedVertical = 1;
        }
        else if (Vmovement < 0 && Vmovement > -0.55f)
        {
            snappedVertical = -0.5f;
        }
        else if (Vmovement < 0.55f)
        {
            snappedVertical = -1;
        }
        else
        {
            snappedVertical = 0;
        }
        #endregion*/
        animator.SetFloat(horizontal, Hmovement, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, Vmovement, 0.1f, Time.deltaTime);
    }
}
