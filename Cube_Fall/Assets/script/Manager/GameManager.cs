using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text text;
    int score = 0;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    public void restart()
    {
        Invoke("restartaftertime", 2);
    }
    public void scores()
    {
        score++;
        text.text = score.ToString();
    }
    void restartaftertime()
    {
        SoundManager.instance.gameoversound();
        SceneManager.LoadScene(0);
    }
}
