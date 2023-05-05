using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CardBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //zmienne do poruszania kartą
    [SerializeField] float dumpSpeed = .05f;
    private Vector3 velocity = Vector3.down;
    public Transform newParent = null;
    private RectTransform tf;
    public roundHandler game;
    
    public enum rodzaj
    {
        blank,
        Atak,
        pancerz,
        boost,
        debuff,
        trick
    }
    //rodzaj karty, przyda się do sprawdzania, czy dobrze jej użyłeś
    public rodzaj rKarty;

    //efekty, czyli co ma zrobić karta po użyciu
    [SerializeField] Effects use;
    PlayersStatus stat;
    //statystyki karty

    //obrażenia
    public int dmg = 7;
    //boost do obrażeń
    public int multi = 1;
    //czy ma zadać więcej niż raz
    public int iterate = 1;
    //koszt użycia karty
    public int manaCost = 1;
    //ile razy wzmocnic postać kartą
    public int howMuchMulti = 1;
    //ile tarczy dać po użyciu karty
    public int shield = 0;


    private void Awake()
    {
        // Debug.Log((int)rKarty);
        tf = transform as RectTransform;
        game = GameObject.Find("GameHandler").GetComponent<roundHandler>();
        use = GetComponent<Effects>();
        stat = GameObject.Find("GameHandler").GetComponent<PlayersStatus>();
    }
    private void Update()
    {
        GetValues();
    }
    public void OnDrag(PointerEventData dragData)
    {
        Debug.Log("Dragging");
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(tf, dragData.position, dragData.pressEventCamera, out var mousePosition))
        {
            tf.position = Vector3.SmoothDamp(tf.position, mousePosition, ref velocity, dumpSpeed);
            // tf.position = mousePosition;
        }
        
        // this.transform.position = dragData.position;
    }
    public void OnBeginDrag(PointerEventData dragData)
    {
        //na początku ciągnięcia ustawia obiekt rodziny na canvas
        transform.SetParent(transform.parent.parent);
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //na koniec poruszania kartą, sprawdza gdzie karta została rzucona
    public void OnEndDrag(PointerEventData dragData){
        transform.SetParent(newParent);
        switch(newParent.name)
        {
            //gdy gracz zdecyduje, że chce odłożyć karte
            case "Hand":
                this.GetComponent<CanvasGroup>().blocksRaycasts = true;
                break;
            //gdy gracz używa karty na g1
            case "P1_hitbox":
                reakcja_na_p1();
                break;
            //gdy gracz używa karty na g2
            case "P2_hitbox":
                reakcja_na_p1();
                break;
        }
        //sprawdza jakiego typu jest karta i używa jej efektu
        void reakcja_na_p1()
        {
            //sprawdzamy czy to buff/tarcza/leczenie i czy używa ich na sobie
                if(((int)rKarty == 2 || (int)rKarty == 3) && newParent.name == game.aktGracz.name && game.currentMana >= manaCost)
                {
                    switch ((int)rKarty)
                    {
                        case 2:
                            Debug.Log("Karta została użyta na graczy nr 1");
                            use.usedCard = GetComponent<CardBehaviour>();
                            StartCoroutine(use.DoShield());
                            game.currentMana -= manaCost;
                            game.thrash +=1;
                            break;
                        case 3:
                            Debug.Log("Karta została użyta na graczy nr 1");
                            use.usedCard = GetComponent<CardBehaviour>();
                            StartCoroutine(use.buff());
                            game.currentMana -= manaCost;
                            game.thrash +=1;
                            break;
                    }
                }
                //jak nie to sprawdzamy, czy to karta atakujące/osłabiająca i czy atakuje przeciwnika
                else if(((int)rKarty == 1 || (int)rKarty == 4) && newParent.name == game.aktEnemy.name && game.currentMana >= manaCost)
                {
                    Debug.Log("Karta została użyta na graczy nr 2");
                    StartCoroutine(use.Attack(dmg, multi, iterate));
                    game.currentMana -= manaCost;
                    game.thrash +=1;
                }
                else if(game.currentMana < manaCost)
                {
                    Debug.Log("Karta wymaga więcej many niż posiada gracz");
                    transform.SetParent(GameObject.Find("Hand").transform);
                    this.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
                else
                {
                    //jak nie to po prostu wraca karte na stół
                    Debug.Log("Karta nie może zostać użyta na tym graczu");
                    transform.SetParent(GameObject.Find("Hand").transform);
                    this.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
        }
    }
    //zdobywa dane o ilości buffa
    public void GetValues()
    {
        multi = stat.buff[game.whichPlayer];
    }
}
