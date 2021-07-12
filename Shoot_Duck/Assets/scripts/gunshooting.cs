using UnityEngine;
using UnityEngine.UI;
public class gunshooting : MonoBehaviour
{
    int score=0;
    public Text scores;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D col = Physics2D.OverlapCircle(mpos, 0.01f);
            if (col != null && col.gameObject.tag == "Target") 
            {
                Debug.Log(col.gameObject.name);
                if (col.gameObject.name == "FirstRowDuckTarget")
                {
                    score += 2;
                }
                else if (col.gameObject.name == "SecondRowDuckTarget")
                {
                    score++;
                }
                else if(col.gameObject.name == "CircleTarget")
                {
                    score += 3;
                }
                targets Targets = col.GetComponentInParent<targets>();
                Targets.hit(mpos);
            }

        }
        Debug.Log(score);
        scores.text = score.ToString();
    }
}
