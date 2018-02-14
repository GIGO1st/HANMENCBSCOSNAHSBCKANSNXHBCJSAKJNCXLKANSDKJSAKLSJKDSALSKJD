using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    public GameObject inventory;
    public GameObject slotHolder;
    private bool inventoryEnabled;

    private int slots;
    private Transform[] slot;

    private GameObject itemPickedUp;


    public void Start()
    {
        //slots being decteded
        slots = slotHolder.transform.childCount;
        slot = new Transform[slots];
        detectInventorySlots();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
            inventory.SetActive(true);
        else
            inventory.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            print("colideing");
            itemPickedUp = other.gameObject;
            AddItem(itemPickedUp);
        }
    }

    public void AddItem(GameObject item)
    {
        for(int i= 0; i < slots; i++)
        {
            if (slot[i].GetComponent<slot>().empty)
            {
                slot[i].GetComponent<slot>().item = itemPickedUp;
                slot[i].GetComponent<slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
            }
        }
    }

    public void detectInventorySlots()
    {
        for (int i = 0; i < slots; i++)
        {
            slot[1] = slotHolder.transform.GetChild(i);
        }

    }

}
