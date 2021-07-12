using System.Xml;
using UnityEngine;

public class COLLACTOR : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pl" || collision.gameObject.tag == "pr" || collision.gameObject.tag == "enemy") 
        {
            Destroy(collision.gameObject,1);
        }

        if(collision.gameObject.tag=="bg")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
