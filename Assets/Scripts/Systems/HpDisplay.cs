using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpDisplay : MonoBehaviour
{
    roundHandler game;
    [SerializeField] TextMeshProUGUI display;
    [SerializeField] int owner;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameHandler").GetComponent<roundHandler>();
        display = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // display.text =  game.PlayersHp[owner] + "/" + game.PlayersHp[0];
    }
    public void whichDisplay(int[] show, int full)
    {
        display.text =  show[owner] + "/" + full;
    }
}
