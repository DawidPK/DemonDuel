using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adaptation : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject[] dancers;
    public GameObject terrain, dancer;
    public Material[] mats;
    void Awake()
    {
        Debug.Log(MySettings.settingsIndex);
        players = GameObject.FindGameObjectsWithTag("Player");
        terrain = GameObject.Find("terrain");
        dancer = dancers[MySettings.settingsIndex];
        switch(MySettings.settingsIndex)
        {
            case 0:
                wlosy(false);
                terrain.GetComponent<Renderer>().material = mats[0];
                break;
            case 1:
                wlosy(true);
                terrain.GetComponent<Renderer>().material = mats[1];
                break;
        }
    }
    void wlosy(bool active)
    {
        foreach (var child in players)
        {
            child.transform.Find("Mesh").gameObject.SetActive(active);
        }
    }
}
