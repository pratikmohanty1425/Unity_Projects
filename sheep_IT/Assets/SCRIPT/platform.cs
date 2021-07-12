using UnityEngine;
using UnityEngine.WSA;

public class platform : MonoBehaviour
{
    [SerializeField]
    private Transform movepoint;

    private Vector3 startingpoint;

    [SerializeField]
    private float smoothmovement = 0.3f;
    private float initialmovment;

    private bool smoothmovementhalfed;

    private bool canmove;
    private bool movetointial;

    [SerializeField]
    private float halfdistance = 15;

    [SerializeField]
    public bool activatemovement;

    [SerializeField]
    public bool activaterotation;

    private rotateplatform rotateplatform;

    [SerializeField]
    private float timer = 1;

    public bool deactivatedoors;

    public static platform instance;

    private void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
        startingpoint = transform.position;
        initialmovment = smoothmovement;

        if(activaterotation)
        {
            rotateplatform = GetComponent<rotateplatform>();
        }
    }

    void Start()
    {
        if(activatemovement)
        {
            Invoke("activatemove", timer);
        }
    }

    void Update()
    {
        
        moveplatform();
        movetoinitialpos();
    }

    void moveplatform()
    {
        if(canmove)
        {
            transform.position = Vector3.MoveTowards
                (transform.position, movepoint.position, 
                smoothmovement*Time.deltaTime);

            if (Vector3.Distance(
                transform.position, movepoint.position) <= halfdistance)
            {
                if(smoothmovementhalfed)
                {
                    smoothmovement /= 2;
                    smoothmovementhalfed = true;
                }
            }

            if(Vector3.Distance(transform.position,movepoint.position)== 0)
            {
                canmove = false;

                if(smoothmovementhalfed)
                {
                    smoothmovement = initialmovment;
                    smoothmovementhalfed = false;
                }
                platformsound.instance.playaudio(false);
                if(deactivatedoors)
                {
                    doorcontroller.instance.opendoor();
                }
            }
        }
    }

    public void activatemove()
    {
        canmove = true;
        if(activaterotation)
        {
            rotateplatform.activerotate();
        }
        platformsound.instance.playaudio(true);
    }

    public void activatemovetoinitial()
    {
        movetointial = true; 
        platformsound.instance.playaudio(true);
    }

    void movetoinitialpos()
    {
        if(movetointial)
        {
            transform.position = Vector3.MoveTowards(transform.position
                , startingpoint, smoothmovement*Time.deltaTime);

            if (Vector3.Distance(
                transform.position, startingpoint) <= halfdistance)
            {
                if (!smoothmovementhalfed)
                {
                    smoothmovement /= 2;
                    smoothmovementhalfed = true;
                }
            }

            if (Vector3.Distance(transform.position, 
                startingpoint) == 0)
            {
                movetointial = false;
                if (smoothmovementhalfed)
                {
                    smoothmovement = initialmovment;
                    smoothmovementhalfed = false;
                }
                platformsound.instance.playaudio(false);
            }
        }
    }
}
