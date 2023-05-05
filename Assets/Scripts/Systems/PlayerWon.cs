using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerWon : MonoBehaviour
{
    [SerializeField] Camera cum;
    [SerializeField] float speed = 100f;
    [SerializeField] TextMeshProUGUI display;
    [SerializeField] GameObject[] Players;
    public Transform[] Targets; 
    public Transform Target;
    public AudioSource music;
    Adaptation adapt;
    roundHandler game;
    GameObject hand, Ui;
    private Vector3 velocity = Vector3.zero;
    bool starter = false;
    private void Start()
    {
        //pobranie danych
        cum = Camera.main;
        Target = Targets[0];
        game = GetComponent<roundHandler>();
        display = GameObject.Find("WonText").gameObject.GetComponent<TextMeshProUGUI>();
        hand = GameObject.Find("Hand");
        Ui = GameObject.Find("Ui");
        display.enabled = false;
        adapt = GetComponent<Adaptation>();
    }
    public IEnumerator Won(int player)
    {
        //ustawia cel dla kamery
        Target = Targets[player];
        Debug.Log(game.gracze[player].transform.name);
        Debug.Log(player);
        //tworzy obiekt tańczącego gracza
        var dancep = Instantiate(adapt.dancer, Players[player].transform);
        dancep.transform.parent = Players[player].transform.parent;
        //wyłącza niepotrzebne obiekty
        Players[1].SetActive(false);
        Players[2].SetActive(false);
        Debug.Log(player);
        //daje znać by rozpocząć ruch kamery
        starter = true;
        hand.SetActive(false);
        Ui.SetActive(false);
        game.enabled = false;
        //daje odpowiednie elementy UI
        display.text = "Player " + player + " wins";
        display.enabled = true;
        music.Stop(); 
        //włącza muzykę
        FindObjectOfType<AudioManager>().Play("victory");
        yield return new WaitForSeconds(7f);
        //przechodzi do następnej sceny
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
    private void FixedUpdate()
    {
        //sprawdza, czy może zacząć poruszać kamerą, jak tak to porysza
        if(starter)
        {
            StartCoroutine(moveCum());
        }
    }
    public IEnumerator moveCum()
    {
        //przeniesienie kamery do punktu odpowiedniego gracza
        cum.transform.position = Vector3.SmoothDamp(cum.transform.position, Target.position,ref velocity, speed);
        speed -= 0.01f;
        yield return new WaitForSeconds(0.5f);
        if(cum.transform.position == Target.position)
        {
            starter = false;
        }
    }
}
