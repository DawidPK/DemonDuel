using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; 
    roundHandler game;
    HpDisplay text;
    [SerializeField] int owner;
    void Start()
    {
        game = GameObject.Find("GameHandler").GetComponent<roundHandler>();
        text = GameObject.Find("H" + owner + "text").GetComponent<HpDisplay>();
        SetMaxHealth(game.PlayersHp[0]);
        slider = gameObject.GetComponent<Slider>();
    }
    public void SetMaxHealth(int health) {
        slider.maxValue= health;
        slider.value = health;
    }

    public void SetHealth(int health) {
        slider.value = health;
    }
    public void Update()
    {
        SetHealth(game.PlayersHp[owner]);
        text.whichDisplay(game.PlayersHp, game.PlayersHp[0]);
    }
}
