using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI display;
    Toss talie;
    roundHandler game;
    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<TextMeshProUGUI>();
        talie = GameObject.Find("GameHandler").gameObject.GetComponent<Toss>();
        game = GameObject.Find("GameHandler").gameObject.GetComponent<roundHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = (talie.useDecks[game.whichPlayer].Count).ToString();
        // Debug.Log(talie.useDecks[game.whichPlayer].Count);
    }
}
