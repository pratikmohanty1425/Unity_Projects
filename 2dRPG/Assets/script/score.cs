using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static score instance;
    public int points=0;

    [SerializeField]
    public Text scoretext;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {

    }


    public void scores()
    {
        points++;
        scoretext.text = points.ToString();
    }
}
