using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI display;
    roundHandler game;
    int mana;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameHandler").GetComponent<roundHandler>();
        mana = game.currentMana;
        display = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        mana = game.currentMana;
        display.text = mana.ToString();
    }
}
