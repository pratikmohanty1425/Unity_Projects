using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public int tn1 = 0;
     public int tn2 = 0;
    public int win = 5;
    public GameObject p1;
    public GameObject p2;

    void Update()
    {
        if(this.tn1>=this.win)
        {
            Debug.Log("player 1 win");
            
            SceneManager.LoadScene(4);
        }
        else if (this.tn2 >= this.win)
        {
            Debug.Log("player 2 win");

            SceneManager.LoadScene(5);
        }
    }
    public int  ok()
    {
        if (this.tn1 >= this.win)
        {
            return 1;
        }
        else if (this.tn2 >= this.win)
        {
            return 2;
        }
        return 0;
    }

    private void FixedUpdate()
    {
        Text uip1 = this.p1.GetComponent<Text>();
        uip1.text = this.tn1.ToString();

        Text uip2 = this.p2.GetComponent<Text>();
        uip2.text = this.tn2.ToString();
    }

    public void gp1()
    {
        this.tn1++;
    }

    public void gp2()
    {
        this.tn2++;
    }
}
