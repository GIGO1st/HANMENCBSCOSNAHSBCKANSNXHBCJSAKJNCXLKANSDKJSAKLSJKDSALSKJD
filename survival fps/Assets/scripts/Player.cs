using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //varables
    public float maxHealth, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;
    private float health, thirst, hunger;

    public bool dead;

    //functions
    public void Start()
    {
        health = maxHealth;
    }
    public void Update()
    {
        if (!dead)
        {
            thirst += thirstIncreaseRate * Time.deltaTime;
            hunger += hungerIncreaseRate * Time.deltaTime;
        }
        if (thirst >= maxThirst)
        {
            Die();
        }
        if (hunger >= maxHunger)
        {
            Die();
        }
        

    }


    public void Die()
    {
        dead = true;
        print("you have died from thirst or hunger");
    }


    public void Drink(float decreaseValue)
    {
        thirst -= decreaseValue;

    }

}
