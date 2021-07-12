using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;

    private gamedata game_data;

    [HideInInspector]
    public int StarScore, scoreCount, selectedIndex;

    [HideInInspector]
    public bool[] heroes;

    [HideInInspector]
    public bool playsound = true;

    private string datapath = "GameData.dat";

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        initializegamedata();
    }

    private void Start()
    {
        print(Application.persistentDataPath + datapath);
        if (game_data != null)
        {
            print("data loaded");
        }
    }

    void initializegamedata()
    {
        loadgamedata();

        if (game_data == null)
        {
            StarScore = 9000;
            scoreCount = 0;
            selectedIndex = 0;
            heroes = new bool[9];
            heroes[0] = true;

            for(int i=1;i<heroes.Length;i++)
            {
                heroes[i] = false;
            }

            game_data = new gamedata();
            game_data.Heroes = heroes;
            game_data.starSore = StarScore;
            game_data.ScoreCount = scoreCount;
            game_data.SelectedIndex = selectedIndex;

            savegamedata();

        }
    }

    public void savegamedata()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath+ datapath);
            if (game_data != null)
            {
                game_data.Heroes = heroes;
                game_data.starSore = StarScore;
                game_data.ScoreCount = scoreCount;
                game_data.SelectedIndex = selectedIndex;

                bf.Serialize(file, game_data);
            }
        }
        catch(Exception e)
        {

        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

    void loadgamedata()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + datapath,FileMode.Open);
            game_data = (gamedata)bf.Deserialize(file);

            if (game_data != null)
            {
                heroes = game_data.Heroes;
                StarScore = game_data.starSore;
                scoreCount=game_data.ScoreCount;
                selectedIndex = game_data.SelectedIndex;
            }
        }
        catch(Exception e)
        {

        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

}
