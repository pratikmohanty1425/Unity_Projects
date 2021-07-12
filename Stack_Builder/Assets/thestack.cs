using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thestack : MonoBehaviour
{
    public Color32[] gamecolor = new Color32[5];
    public Material stackmat;

    private const float boundsSize = 2.5f;
    public const float stackmovingspeed = 5;
    private const float errormargin = 0.1f;
    private const float stackboundgain = 0.25f;
    private const float combostackgain= 3;

    private GameObject[] stack;
    private Vector2 stackbounds = new Vector2(boundsSize, boundsSize);

    private int stackindex;
    [SerializeField]
    private int score = 1;
    private int combo = 0;

    private float tiletransition = 0.01f;
    private float tilespeed = 2.5f;
    private float scndpos;

    private bool ismovinginx = true;
    private bool gameover = false;

    private Vector3 desiredpos;
    private Vector3 lasttilepos;

    public Text scores;
    void Start()
    {
        stack = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount ; i++)
        {
            stack[i] = transform.GetChild(i).gameObject;
            colourmesh(stack[i].GetComponent<MeshFilter>().mesh);
        }
        stackindex = transform.childCount - 1;
    }

    void colourmesh(Mesh mesh)
    {
        Vector3[] verices = mesh.vertices;
        Color32[] colour = new Color32[verices.Length];
        float f = Mathf.Sin(score * .025f);
        for (int i = 0; i < verices.Length; i++)
        {
            colour[i] = lerp4(gamecolor[0], gamecolor[1], gamecolor[2], gamecolor[3], gamecolor[4],f);
            
        }

        mesh.colors32 = colour;
    }

    Color32 lerp4(Color32 a, Color32 b, Color32 c, Color32 d, Color32 e,float t)
    { 
        if(t<0.33f)
        {
            return Color.Lerp(a,b,(t / 0.33f));
        }
        else if (t < 0.66f)
        {
            return Color.Lerp(b, c, (t-.33f / 0.33f));
        }
        else if (t < 0.99f)
        {
            return Color.Lerp(c, d, (t-.66f / 0.33f));
        }
        else 
        {
            return Color.Lerp(d, e, (t-0.99f / 0.33f));
        }

    }

    private void Update()
    {
        
        if(gameover)
        {
            return;
        }
        else
        {
            scores.text = (score+combo-1).ToString();
            if(Input.GetMouseButtonDown(0))
            {
                if(placetile())
                {
                    spawntile();
                    score++;
                }
                else
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                }
            }
            
            movetile();
            transform.position = Vector3.Lerp(transform.position, desiredpos, stackmovingspeed * Time.deltaTime);
        }
    }

    void spawntile()
    {
        lasttilepos = stack[stackindex].transform.localPosition;
        stackindex--;
        if (stackindex < 0)
           stackindex = transform.childCount - 1;

        desiredpos = Vector3.down * score;
        stack[stackindex].transform.localPosition = new Vector3(0, score, 0);
        stack[stackindex].transform.localScale = new Vector3(stackbounds.x, 1, stackbounds.y);
        colourmesh(stack[stackindex].GetComponent<MeshFilter>().mesh);

    }

    private bool placetile()
    {
        Transform t = stack[stackindex].transform;
        if(ismovinginx)
        {
            float deltax = lasttilepos.x - t.position.x;
            if(Mathf.Abs(deltax)>errormargin)
            {
                combo = 0; 
                stackbounds.x -= Mathf.Abs(deltax);

                if (stackbounds.x<=0)
                {
                    return false;
                }
                else
                {
                    float mid = lasttilepos.x + t.position.x / 2;
                    t.localScale = new Vector3(stackbounds.x, 1, stackbounds.y);
                    createrubble(new Vector3((t.position.x > 0) ? t.position.x + (t.localScale.x / 2) : t.position.x - (t.localScale.x / 2), t.position.y, t.position.z),
                        new Vector3(Mathf.Abs(deltax), 1, t.localScale.z));
                    t.localPosition = new Vector3(mid - (lasttilepos.x / 2), score, lasttilepos.z);

                }
            }
            else
            {
                if(combo>combostackgain)
                {
                    stackbounds.x += stackboundgain;
                    if(stackbounds.x>boundsSize)
                    {
                        stackbounds.x = boundsSize;
                    }
                    else
                    {

                        float mid = lasttilepos.x + t.position.x / 2;
                        t.localScale = new Vector3(stackbounds.x, 1, stackbounds.y);
                        t.localPosition = new Vector3(mid - (lasttilepos.x / 2), score, lasttilepos.z/2);

                    }
                }
                combo++;

                t.localPosition = new Vector3(lasttilepos.x, score, lasttilepos.z);
            }

        }
        else
        {
            float deltaz = lasttilepos.z - t.position.z;
            if (Mathf.Abs(deltaz) > errormargin)
            {
                combo = 0;
                stackbounds.y -= Mathf.Abs(deltaz);

                if (stackbounds.y <= 0)
                {
                    return false;
                }
                else
                {

                    float mid = lasttilepos.z + t.position.z / 2;
                    t.localScale = new Vector3(stackbounds.x, 1, stackbounds.y);
                    createrubble(new Vector3(t.position.x, t.position.y, (t.position.z > 0) ? t.position.z + (t.localScale.z / 2) : t.position.z - (t.localScale.z / 2)), new Vector3(t.localScale.x, 1, Mathf.Abs(deltaz)));
                    t.localPosition = new Vector3(lasttilepos.x/2, score, mid - (lasttilepos.z / 2));

                }
            }
            else
            {
                if (combo > combostackgain)
                {
                    stackbounds.y += stackboundgain;
                    if (stackbounds.y > boundsSize)
                    {
                        stackbounds.y = boundsSize;
                    }

                    float mid = lasttilepos.x + t.position.x / 2;
                    t.localScale = new Vector3(stackbounds.x, 1, stackbounds.y);
                    t.localPosition = new Vector3(lasttilepos.x / 2, score, mid - (lasttilepos.z / 2));
                }
                combo++;

                t.localPosition = new Vector3(lasttilepos.x, score, lasttilepos.z);
            }
        }

        scndpos = ismovinginx ? t.localPosition.x : t.localPosition.z;
        ismovinginx = !ismovinginx;

        return true;
    }

    void createrubble(Vector3 pos,Vector3 scale)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.localPosition = pos;
        go.transform.localScale = scale;
        go.AddComponent<Rigidbody>();

        go.GetComponent<MeshRenderer>().material = stackmat;
        colourmesh(go.GetComponent<MeshFilter>().mesh);
    }

    private void movetile()
    {

        tiletransition += Time.deltaTime * tilespeed;
        if(ismovinginx)
        {
            //Debug.Log("x"+ Mathf.Sin(tiletransition));
            stack[stackindex].transform.localPosition = new Vector3(Mathf.Sin(tiletransition) * boundsSize, score, scndpos);
        }
        else
        {
            //Debug.Log("y" + Mathf.Sin(tiletransition));
            stack[stackindex].transform.localPosition = new Vector3(scndpos, score, Mathf.Sin(tiletransition) * boundsSize);
        }
    }
}
