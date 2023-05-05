using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    [SerializeField] Animator[] anim = new Animator[3];
    [SerializeField] GameObject[] players;
    roundHandler game;
    int act, enem;
    // Start is called before the first frame update
    void Start()
    {
        anim[0] = null;
        game = GetComponent<roundHandler>();
        players = GameObject.FindGameObjectsWithTag("Player");
        przypisz();
    }
    void przypisz()
    {
        if(players[0].transform.name == "P2")
        {
            // Debug.Log("P1");
            anim[2]= players[0].GetComponent<Animator>();
            anim[1] = players[1].GetComponent<Animator>();
        }
        else if(players[0].transform.name == "P1")
        {
            // Debug.Log("P1");
            anim[1]= players[0].GetComponent<Animator>();
            anim[2] = players[1].GetComponent<Animator>();
        }
    }
    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    public void zrobAtak(float timer)
    {
        act = game.whichPlayer;
        enem = game.whichEnemy;
        if(anim[act] != null)
        {
            anim[act].speed = 2 + timer;
            anim[act].Play("Atak");
            anim[enem].speed = 0.5f;
            anim[enem].Play("takeDamage");
            Debug.Log("Atak dokonany!");
        }
        anim[act].speed = 1;
        anim[enem].speed = 1;
    }
    public void zrobBlok(bool tak, int gracz)
    {
        act = game.whichPlayer;
        // switch (tak)
        // {
        //     case true:
        //         if(anim[act].GetBool("blok") == true)
        //         {
        //             return;
        //         }else{
        //             anim[act].SetBool("blok", tak);
        //         }
        //         break;
        //     case false:
        //         if(anim[act].GetBool("blok") == false)
        //             {
        //                 return;
        //             }else{
        //                 anim[act].SetBool("blok", tak);
        //             }
        //         break;
        //     // default:
        //     //     break;
        // }
        
        anim[gracz].SetBool("blok", tak);
    }
}
