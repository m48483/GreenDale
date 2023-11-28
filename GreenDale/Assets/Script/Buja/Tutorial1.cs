using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Tutorial1 : MonoBehaviour
{
    public Flowchart flowchart;

    void Start()
    {
        string PlayerName = PlayerPrefs.GetString("PlayerName");
        GameObject.Find("Variables").GetComponent<Flowchart>().SetStringVariable("PlayerName", PlayerName);

        int Day = flowchart.GetIntegerVariable("Day");
        int Seasons = flowchart.GetIntegerVariable("Seasons");
        PlayerPrefs.SetInt("Day", Day);
        PlayerPrefs.SetInt("Seasons", Seasons);
    }
}
