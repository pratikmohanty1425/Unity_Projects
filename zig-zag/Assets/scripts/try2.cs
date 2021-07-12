using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class try2 : MonoBehaviour
{
    //public Text recent;
    //public Text high;
    int hi;
    void Start()
    {
        //SCORE s = GameObject.Find("player").GetComponent<SCORE>(); 
        //Debug.Log(s.gethighscore()) ;

        hi = GetComponent<SCORE>().gethighscore();
        Debug.Log(hi);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
