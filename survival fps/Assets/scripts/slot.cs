using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    
    private bool hovered;
    public bool empty;

    public GameObject item;
    public Texture itemIcon;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        hovered = false;
    }

    void Update()
    {
        if (item)
        {
            empty = false;

            itemIcon = item.GetComponent<Item>().icon;
            this.GetComponent<RawImage>().texture = itemIcon;
        }
        else
        {
            empty = true;
            itemIcon = null;
            this.GetComponent<RawImage>().texture = null;
        }
            
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item)
        {
            Item thisItem = item.GetComponent<Item>();

            //check for item type
            if(thisItem.type == "Water")
            {
                player.GetComponent<Player>().Drink(thisItem.decreaseValue);
                Destroy(item);
            }

        }

    }



}
