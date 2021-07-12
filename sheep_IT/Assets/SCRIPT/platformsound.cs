using UnityEngine;

public class platformsound : MonoBehaviour
{
    private AudioSource audio;

    public static platformsound instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        audio = GetComponent<AudioSource>();
    }

    public void playaudio(bool play)
    {
        if(play)
        {
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }
}
