using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class button_controller : MonoBehaviour
{
    public platform[] movingplatform;

    [SerializeField]
    private bool movedplatformtopoint;

    [SerializeField]
    private bool whitebtn, redbtn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            if(whitebtn)
            {
                if (other.gameObject.GetComponent<Renderer>().
                    material.color != Color.white)
                {
                    return;
                }
                else
                {
                    Debug.Log("match");
                    //platform.instance.activatemove();
                }
            }

            if(redbtn)
            {
                if (other.gameObject.GetComponent<Renderer>().
                    material.color != Color.red)
                {
                    return;
                }
                else
                {
                    Debug.Log("match");
                    //platform.instance.activatemove();
                }
            }

            if(!movedplatformtopoint)
            {
                movedplatformtopoint = true;
                
                for(int i=0;i<movingplatform.Length; i++)
                {
                    movingplatform[i].activatemove();
                }
            }
            else
            {
                movedplatformtopoint = false;
                for (int i = 0; i < movingplatform.Length; i++)
                {
                    movingplatform[i].activatemovetoinitial();
                }
            }
        }
    }
}
