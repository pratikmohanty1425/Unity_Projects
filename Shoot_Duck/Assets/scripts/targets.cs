using UnityEngine;
using System;
using System.Collections;

public class targets : MonoBehaviour
{
    public SpriteRenderer spritrenderer=null;
    public Animator anim=null;
    public Transform partorotate= null;

    private Vector3 loc;
    public float staytime;
    private float speed = 2.5f;

    public bool ishit { get; private set; }

    private bool _ismoving = false;
    private bool _isstaying = false;
    private bool _ismovingout = false;

    private float _timeleft = 1;

    public event Action isout;
    
    private void OnEnable()
    {
        ishit = false;
        _ismoving = false;
        _ismovingout = false;
        _isstaying = false;
        anim.enabled = false;
    }

    void Update()
    {
        if (gameObject.transform.position.x==0)
        {
            StartCoroutine(change());
        }
        if(_isstaying)
        {
            _timeleft -= Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(transform.position.x - loc.x) < 0.01f)
            {
                transform.position = loc;
                if(_ismovingout)
                {
                    gameObject.SetActive(false);
                    isout?.Invoke();
                    return;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, loc, speed * Time.deltaTime);
            }
        }
    }

    IEnumerator change()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.25f, 1));

        loc = (loc.x < 0 ? new Vector3(-25, 0) : new Vector3(25, 0));
        Destroy(gameObject, 2);
    }
    void movingout()
    {
        _ismoving = false;
        _isstaying = false;
        loc = (loc.x < 0 ? new Vector3(-11, 0) : new Vector3(11, 0));
        _ismovingout = true;
    }

    public void hit(Vector2 pos)
    {
        if (ishit)
            return;

        ishit = true;
        anim.enabled = true;
        movingout();
    }
}
