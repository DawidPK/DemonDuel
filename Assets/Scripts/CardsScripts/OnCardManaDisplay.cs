using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnCardManaDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI display;
    int mana;
    // [SerializeField] GameObject card;
    [SerializeField] CardBehaviour card;
    // Start is called before the first frame update
    void Start()
    {
        card = transform.parent.parent.gameObject.GetComponent<CardBehaviour>();
        display = GetComponent<TextMeshProUGUI>();
        display.text = card.manaCost.ToString();
    }

}
