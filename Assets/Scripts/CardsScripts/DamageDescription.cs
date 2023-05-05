using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageDescription : MonoBehaviour
{
    private TextMeshProUGUI description;
    [SerializeField] CardBehaviour card;
    // Start is called before the first frame update
    void Start()
    {
        description = GetComponent<TextMeshProUGUI>();
        card = transform.parent.parent.gameObject.GetComponent<CardBehaviour>();
    }
    void Update()
    {
        desc();
    }
    void desc()
    {
        if(card.iterate != 1)
        {
            description.text = "Zadaje " + (card.dmg * card.multi) + " obrażeń " + card.iterate + " razy";
        }else{
            description.text = "Zadaje " + (card.dmg * card.multi) + " obrażeń";
        }
    }
}
