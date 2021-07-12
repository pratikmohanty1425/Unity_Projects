using UnityEngine;

public class hookmovement : MonoBehaviour
{
    public float minzangle = -55, maxzangle = 55;

    public float rotatespeeed = 5;
    public float movespeed = 3;

    private float rotateangle;
    private bool rotateright;
    private bool canrotate;

    private float initialspeed;

    public float miny = -2.886f;
    private float initialy;

    private bool movedown;

    public static hookmovement instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        initialy = transform.position.y;
        initialspeed = movespeed;

        canrotate = true;
    }

    void Update()
    {
        rotatehook();
        getinput();
        moveroop();
    }

    void rotatehook()
    {
        if (!canrotate)
        {
            return;
        }

        if(rotateright)
        {
            rotateangle += rotatespeeed * Time.deltaTime;
        }
        else
        {
            rotateangle -= rotatespeeed * Time.deltaTime;
        }
        transform.rotation = Quaternion.AngleAxis(
            rotateangle, Vector3.forward);

        if(rotateangle>=maxzangle)
        {
            rotateright = false;
        }
        else if(rotateangle<=minzangle)
        {
            rotateright = true;
        }
    }

    void getinput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (canrotate)
            {
                canrotate = false;
                movedown = true;
                soundmanager.instance.stretchfx(true);
            }
        }
    }

    void moveroop()
    {
        if(canrotate)
        {
            return;
        }

        if(!canrotate)
        {
            
            Vector3 temp = transform.position;
            if(movedown)
            {
                temp -= transform.up * Time.deltaTime * movespeed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * movespeed;
            }

            transform.position = temp;

            if(temp.y<=miny)
            {
                movedown = false;
            }
            if(temp.y>=initialy)
            {
                roperenderer.instance.renderline(temp, false) ;
                canrotate = true;
                movespeed = initialspeed;
                soundmanager.instance.stretchfx(true);
            }
            roperenderer.instance.renderline(transform.position, true);
        }
    }

    public void hookattached()
    {
        movedown = false;
    }
}
