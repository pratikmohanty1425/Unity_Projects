using UnityEngine;

public class soundmanager : MonoBehaviour
{
    static public soundmanager instance;

    [SerializeField]
    private AudioSource gold,stone,laugh,timer,rope,stretch,over;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }    
    }

    public void goldfx()
    {
        gold.Play();
    }

    public void stonefx()
    {
        stone.Play();
    }

    public void ropefx(bool playfx)
    {
        if (playfx)
        {
            if (!rope.isPlaying)
            {
                rope.Play();
            }
        }
        else
        {
            if (rope.isPlaying)
            {
                rope.Stop();
            }
        }
    }

    public void stretchfx(bool playfx)
    {
        if(playfx)
        {
            if(!stretch.isPlaying)
            {
                stretch.Play();
            }
        }
        else
        {
            if(stretch.isPlaying)
            {
                stretch.Stop();
            }
        }
    }

    public void laughfx()
    {
        laugh.Play();
    }

    public void timerfx(bool playfx)
    {
        if (playfx)
        {
            if (!timer.isPlaying)
            {
                timer.Play();
            }
        }
        else
        {
            if (timer.isPlaying)
            {
                timer.Stop();
            }
        }
    }

    public void overfx()
    {
        over.Play();
    }
}
