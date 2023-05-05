using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Random;

public class Toss : MonoBehaviour
{
    // // Start is called before the first frame update
    public List<GameObject> deckP1, deckP2 = new List<GameObject>();
    List<List<GameObject>> decks = new List<List<GameObject>>();
    public List<List<GameObject>> useDecks = new List<List<GameObject>>();
    float cardTaken;
    roundHandler game;
    public GameObject board;
    void Awake()
    {
        game = GetComponent<roundHandler>();
        board = GameObject.Find("Hand").gameObject;
        decks.Add(new List<GameObject>());
        decks.Add(new List<GameObject>(deckP1));
        decks.Add(new List<GameObject>(deckP2));
        useDecks = decks;
        // StartCoroutine(deployCards());
    }
    public IEnumerator deployCards()
    {
        cardTaken = Random.Range(0, useDecks[game.whichPlayer].Count - 1);
        // Debug.Log(cardTaken);
        if(useDecks[game.whichPlayer][(int)cardTaken] == null)
            yield break;
        var card = Instantiate(useDecks[game.whichPlayer][(int)cardTaken], board.transform);
        FindObjectOfType<AudioManager>().Play("draw");
        useDecks[game.whichPlayer].Remove(useDecks[game.whichPlayer][(int)cardTaken]);

        yield return null;
    }
    public void cleanBoard()
    {
        foreach (Transform child in board.transform) {
            GameObject.Destroy(child.gameObject);
        }
        useDecks[1] = new List<GameObject>(deckP1);
        useDecks[2] = new List<GameObject>(deckP2);
    }
    // /*typ danych*/ karta1, karta2, karta3, karta4, karta5, karta6, karta7;
    // void Start()
    // {
    //     Random r = new Random();
    //     //nie wiem jakiego typu danych sa te karty
    //     /*typ karty*/[] tasowanie = {/*odnosnik karta1*/, /*odnosnik karta2*/,/*etc*/}
    //     karta1 = tasowanie[r.Next(0,30)];
    //     karta2 = tasowanie[r.Next(0,30)];
    //     karta3 = tasowanie[r.Next(0,30)];
    //     karta4 = tasowanie[r.Next(0,30)];
    //     karta5 = tasowanie[r.Next(0,30)];
    //     karta6 = tasowanie[r.Next(0,30)];
    //     karta7 = tasowanie[r.Next(0,30)];
    //     //teraz te karty wrzucasz do gry i masz wylosowane 7 kart
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
