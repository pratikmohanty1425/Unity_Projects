using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float sphereSize = 0.2f;
    public int spheresInRow = 5;

    float spheresPivotDistance;
    Vector3 spheresPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    // Use this for initialization
    void Start()
    {


        //calculate pivot distance
        spheresPivotDistance = sphereSize * spheresInRow / 2;
        //use this value to create pivot vector)
        spheresPivot = new Vector3(spheresPivotDistance, spheresPivotDistance, spheresPivotDistance);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="death")
        {
            explode();
        }
    }
    private void OnTriggerEnter(Collider other)
    {


    }

    public void explode()
    {
        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < spheresInRow; x++)
        {
            for (int y = 0; y < spheresInRow; y++)
            {
                for (int z = 0; z < spheresInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(sphereSize * x, sphereSize * y, sphereSize * z) - spheresPivot;
        piece.transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = sphereSize;
    }
}
