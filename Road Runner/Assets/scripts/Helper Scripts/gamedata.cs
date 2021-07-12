using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class gamedata
{
    private int starscore;
    private int scorecount;

    private bool[] heroes;

    private int selectedindex;

    public int starSore
    {
        get
        {
            return starscore;
        }
        set
        {
            starscore = value;
        }
    }

    public int ScoreCount
    {
        get
        {
            return scorecount;
        }
        set
        {
            scorecount = value;
        }
    }

    public bool[] Heroes
    {
        get
        {
            return heroes;
        }
        set
        {
            heroes = value;
        }
    }

    public int SelectedIndex
    {
        get
        {
            return selectedindex;
        }
        set
        {
            selectedindex = value;
        }
    }

}
