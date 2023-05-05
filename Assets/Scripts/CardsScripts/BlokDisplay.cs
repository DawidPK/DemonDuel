using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlokDisplay : MonoBehaviour
{
    private TextMeshProUGUI description;
    [SerializeField] CardBehaviour card;
    // Start is called before the first frame update
    void Start()
    {
        description = GetComponent<TextMeshProUGUI>();
        card = transform.parent.parent.gameObject.GetComponent<CardBehaviour>();
        description.text = "Blokuje następne " + card.shield + " obrażeń";
    }
}
