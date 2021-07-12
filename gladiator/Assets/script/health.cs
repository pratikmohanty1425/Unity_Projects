using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class health : MonoBehaviour
{
    public float healths = 100;
    private float xdeath = -90;
    private float deathsmooth = 0.9f;
    private float rotatetime = 0.3f;
    private bool playerdied;
    public bool isplayer;
    [SerializeField]
    private Image healthui;

    public static health instance;

    [HideInInspector]
    public bool shieldactive;

    private void Awake()
    {
        if(instance!=null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(playerdied)
        {
            rotateafterdeath();
        }
    }

    public void applydamage(float damage)
    {
        if(shieldactive)
        {
            return;
        }

        healths -= damage;
        if(healthui!=null)
        {
            healthui.fillAmount = healths / 100;
        }
        if(healths<=0)
        {
            sound.instance.die();
            GetComponent<Animator>().enabled = false;
            StartCoroutine(allowrotate());
            if(isplayer)
            {
                GetComponent<playermovement>().enabled = false; 
                GetComponent<playerattack>().enabled = false;
                Camera.main.transform.SetParent(null);

                GameObject.FindGameObjectWithTag("enemy").GetComponent<enemycontroller>().enabled = false;
            }
            else
            {
                GetComponent<enemycontroller>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }

    void rotateafterdeath()
    {
        transform.eulerAngles = new Vector3(Mathf.Lerp(transform.eulerAngles.x,
            xdeath, Time.deltaTime * deathsmooth), transform.eulerAngles.y, transform.eulerAngles.z);

    }

    IEnumerator allowrotate()
    {
        playerdied = true;
        yield return new WaitForSeconds(rotatetime);
        playerdied = false;
    }
}
