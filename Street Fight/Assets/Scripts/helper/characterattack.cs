using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterattack : MonoBehaviour
{
    public LayerMask collisionlayer;
    public float radius = 1;
    public float damage = 2;
    public bool isplayer, isenemy;
    public GameObject hitfix;

    void Update()
    {
        detectcollision();
    }

    void detectcollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionlayer);
        if (hit.Length > 0)
        {
            if (isplayer)
            {
                Vector3 hitfxpos = hit[0].transform.position;
            }
            gameObject.SetActive(false); 
        }
    }
}
