using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackdamage : MonoBehaviour
{
    public LayerMask layer;
    public float radius = 1;
    public float damage = 1;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layer);
        if(hits.Length>0)
        {
            hits[0].GetComponent<health>().applydamage(damage);
            gameObject.SetActive(false);
        }
    }
}
