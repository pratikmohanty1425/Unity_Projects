using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class knife : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 3;
    private bool wood;
    private spawner sp;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sp = GameObject.Find("sk").GetComponent<spawner>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !wood)
        {
            rb.velocity = new Vector3(0, speed,0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="wood")
        {
            gameObject.transform.SetParent(other.transform);
            rb.velocity = Vector3.zero;
            wood = true;
            sp.spknife();
        }
        if(other.tag=="KNIFE")
        {
            Debug.Log("hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
