using UnityEngine;

public class GunShooting : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D col = Physics2D.OverlapCircle(mousePos, 0.01f);

            if (col != null && col.CompareTag("Target"))
            {
                Target target = col.GetComponentInParent<Target>();
                target.Hit(mousePos);
            }
        }
    }

}
