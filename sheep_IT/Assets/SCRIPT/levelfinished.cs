using UnityEngine;
using UnityEngine.SceneManagement;

public class levelfinished : MonoBehaviour
{
    [SerializeField]
    private string nextlvlname;

    [SerializeField]
    private float timer=2;

    private bool lvlfinished;

    private void Awake()
    {
        
    }

    void loadnewlvl()
    {
        SceneManager.LoadScene(nextlvlname);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!lvlfinished)
            {
                lvlfinished = true;
                platformsound.instance.playaudio(true);

                if (!nextlvlname.Equals(""))
                {
                    Invoke("loadnewlvl", timer);
                }

            }
        }
    }
}
