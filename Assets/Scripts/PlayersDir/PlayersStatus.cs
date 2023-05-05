using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersStatus : MonoBehaviour
{
    public int[] buff = new int[3];
    public int[] debuff = new int[3];
    // private void Start()
    // {
    //     // for (var i = 0; i < 3; i++)
    //     // {
    //     //     buff[i] = 1;
    //     //     debuff[i] = 1;
    //     // }
    // }
    public void clear()
    {
        buff[1] = 1;
        buff[2] = 1;
    }
}
