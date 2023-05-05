using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardBehavior : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //dragData.pointerDrag to aktualna karta upuszczona na miejsce
    public void OnDrop(PointerEventData dragData)
    {
        CardBehaviour card = dragData.pointerDrag.GetComponent<CardBehaviour>();
        if(card != null)
        {
            card.newParent = this.transform;
        }
    }
    public void OnPointerEnter(PointerEventData dragData)
    {

    }
    public void OnPointerExit(PointerEventData dragData)
    {

    }
}
