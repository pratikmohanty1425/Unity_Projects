using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontroller : MonoBehaviour
{
    public static gamecontroller instance;
    public spwaner sp;
    [HideInInspector]
    public box b;


    public cam camera1;
    int cnt = 0;
    private void Awake()
    {
        if(instance=null)
        {
            instance = this;
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        sp.spawnbox();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void spbox()
    {
        Invoke("newbox", Random.Range(.5f,2));
    }
    void newbox()
    {
        sp.spawnbox();
    }
    public void movecam()
    {
        cnt++;
        if (cnt == 3)
        {
            cnt = 0;
            camera1.targetpos.y += 2;
            
        }
    }
    

}
