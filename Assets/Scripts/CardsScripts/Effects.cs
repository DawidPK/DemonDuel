using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    roundHandler game;
    AnimPlayer anim;
    PlayersStatus stat;
    ShieldBar shield;
    public CardBehaviour usedCard;
    // bool isTarcza = false;
    int[] target;
    private void Start()
    {
        game = GameObject.Find("GameHandler").GetComponent<roundHandler>();
        anim = GameObject.Find("GameHandler").GetComponent<AnimPlayer>();
        stat = GameObject.Find("GameHandler").GetComponent<PlayersStatus>();
    }
    public IEnumerator Attack(int dmg, int multi, int times)
    {
        //sprawdza, czy ma tarcze, jak tak to ustawia ją na cel
        checkShield();
        if(times > 1)
        {
            float wait = 0.5f;
            for (int i = 0; i < times; i++)
            {
                //robi animacje ataku
                Debug.Log("atak");
                anim.zrobAtak(0);
                //gra dźwięk
                FindObjectOfType<AudioManager>().Play("slash");
                //zadaje obrażenia celowi
                target[game.whichEnemy] -= dmg * multi;
                checkShield();
                yield return new WaitForSeconds(wait);
            }
            Destroy(gameObject);
        }else{
            anim.zrobAtak(0);
            FindObjectOfType<AudioManager>().Play("slash");
            target[game.whichEnemy] -= dmg * multi;
            yield return new WaitForSeconds(0);
            Destroy(gameObject);
        }
        yield return null;
    }
    public IEnumerator buff()
    {
        if(usedCard != null)
        {
            stat.buff[game.whichPlayer] *= usedCard.howMuchMulti;
            FindObjectOfType<AudioManager>().Play("buff");
        }
        Destroy(gameObject);
        yield return null;
    }
    //efekt dodania tarczy
    public IEnumerator DoShield()
    {
        shield = GameObject.Find("P" + game.whichPlayer + "Shield").GetComponent<ShieldBar>();
        game.PlayersShield[game.whichPlayer] += usedCard.shield;
        FindObjectOfType<AudioManager>().Play("Block");
        shield.SetMaxHealth(game.PlayersShield[game.whichPlayer]);
        Destroy(gameObject);
        yield return null;
    }
    void checkShield()
    {
        if(game.PlayersShield[game.whichEnemy] <= 0)
        {
            // isTarcza = false;
            target = game.PlayersHp;
        }else{
            // isTarcza = true;
            target = game.PlayersShield;
        }
    }
}
