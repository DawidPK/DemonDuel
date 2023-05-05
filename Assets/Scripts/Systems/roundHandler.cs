using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class roundHandler : MonoBehaviour
{
    public int whichPlayer, whichEnemy, startMana, currentMana;
    public int[] PlayersHp = {100, 100, 100};
    public int[] PlayersShield = {0, 0, 0};
    public int[] PlayersMana = {5, 5, 5}; 
    public GameObject[] gracze = new GameObject[3];
    public GameObject aktGracz, aktEnemy, wonPlayer, pointer;
    public Transform[] Targets; 
    [SerializeField] PlayerWon endGame;
    TextMeshProUGUI Thrashdisplay;
    PlayersStatus stat;
    public int thrash;
    Toss cardDealer;
    int i;
    
    // bool GameOver = false;

    private void Start()
    {
        //pobranie wszystkich potrzebnych danych
        gracze[1] = GameObject.Find("P1_hitbox");
        gracze[2] = GameObject.Find("P2_hitbox");
        whichEnemy = 2;
        whichPlayer = 1;
        startMana = PlayersMana[0];
        currentMana = startMana;
        stat = GetComponent<PlayersStatus>();
        endGame = GetComponent<PlayerWon>();
        Thrashdisplay = GameObject.Find("ThrashText").gameObject.GetComponent<TextMeshProUGUI>();
        cardDealer = GetComponent<Toss>();
        StartCoroutine(Game(stat));
        pointer = GameObject.Find("Pointer");
    }
    //zakończ i rozpocznij runde
    public void nextRound()
    {
        //to po to by nie dobierało dodatkowych kart
        StopCoroutine(Game(stat));
        StartCoroutine(Game(stat));
    }
    //ciąg gry
    public IEnumerator Game(PlayersStatus plStat)
    {
        // zmień gracza
        Debug.Log("Gracz " + whichPlayer + " Rozpoczął turę");
        switch(whichPlayer)
        {
            case 1:
                aktGracz = gracze[1];
                aktEnemy = gracze[2];
                currentMana = startMana;
                break;
            case 2:
                aktGracz = gracze[2];
                aktEnemy = gracze[1];
                currentMana = startMana;
                break;
        }
        // wyczyść
        thrash = 0;
        plStat.clear();
        cardDealer.cleanBoard();
        PlayersShield[whichPlayer] = 0;
        // dobierz karty
        for (i = 0; i < 6; i++)
        {
            StartCoroutine(cardDealer.deployCards());
            Debug.Log(i);
            yield return new WaitForSeconds(0.2f);
        }
        Debug.Log("Gracz " + whichPlayer + " Dobrał 7 kart");
        yield return null;
    }
    public void EndGame()
    {
        //sprawdza, który gracz wygra i wywołuje korutynę do rozpoczęcia sekwencji
        if(PlayersHp[1] <= 0)
        {
            Debug.Log("gracz 1 przegrał");
            StartCoroutine(endGame.Won(2));
        }else if(PlayersHp[2] <= 0)
        {
            Debug.Log("gracz 2 przegrał");
            StartCoroutine(endGame.Won(1));
        }else{
            return;
        }
    }
    void Update()
    {
        EndGame();
        Thrashdisplay.text = thrash.ToString();
        pointer.transform.position = Targets[whichPlayer].position;
    }
}
