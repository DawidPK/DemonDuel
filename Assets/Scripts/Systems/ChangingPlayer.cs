using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingPlayer : MonoBehaviour
{
    int AktPlayer;
    [SerializeField] roundHandler Game;
    private void Start()
    {
        Game = GameObject.Find("GameHandler").GetComponent<roundHandler>();
    }
    public void changePlayer()
    {
        FindObjectOfType<AudioManager>().Play("click");
        int akt = Game.whichPlayer;
        switch(akt)
        {
            case 1:
                Game.whichPlayer = 2;
                Game.whichEnemy = 1;
                Game.nextRound();
                break;
            case 2:
                Game.whichPlayer = 1;
                Game.whichEnemy = 2;
                Game.nextRound();
                break;
        }
    }
}
