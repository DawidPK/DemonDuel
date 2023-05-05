using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider; 
    roundHandler game;
    HpDisplay text;
    AnimPlayer anim;
    [SerializeField] CanvasGroup vis;
    [SerializeField] int owner;
    void Start()
    {
        anim = GameObject.Find("GameHandler").GetComponent<AnimPlayer>();
        vis = GetComponent<CanvasGroup>();
        game = GameObject.Find("GameHandler").GetComponent<roundHandler>();
        text = GameObject.Find("S" + owner + "text").GetComponent<HpDisplay>();
        
        // if(game.PlayersShield[owner] == 0 && vis != null)
        // {
        //     vis.alpha = 1f;
        // }
        // SetMaxHealth(game.PlayersHp[0]);
        // slider = gameObject.GetComponent<Slider>();
    }
    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) {
        slider.value = health;
    }
    private void Update()
    {
        if(game.PlayersShield[owner] <= 0)
        {
            vis.alpha = 0;

            anim.zrobBlok(false, owner);
        }else{
            vis.alpha = 1;
            SetMaxHealth(game.PlayersShield[owner]);
            text.whichDisplay(game.PlayersShield, (int)slider.maxValue);
            anim.zrobBlok(true, owner);
            // SetMaxHealth();
        }
        // SetHealth(game.PlayersHp[owner]);
    }
}
