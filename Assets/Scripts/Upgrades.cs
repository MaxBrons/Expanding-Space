﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{

    [SerializeField] private float cost = 15;
    public Text AmountOfMaterials, Warning;

    void FixedUpdate()
    {
        AmountOfMaterials.text = UI.materials.ToString();
    }

    //hier upgrade je je health
    // je voegt 1 punt toe aan de health
    // er wordt 1 van de Resources af gehaald
    public void UpgradeHealth()
    {
        if (UI.materials >= cost)
        {
            playerController.health += 1;
            UI.materials -= cost;
        }
        else
            StartCoroutine(MaterialWarning());
    }

    //speed upgrade 
    //je voegt 1 punt toe aan de speed
    // er wordt 1 van de Resources af gehaald
    public void UpgradeSpeed()
    {
        if (UI.materials >= cost)
        {
            playerController.speed += 1;
            UI.materials -= cost;
        }
        else
            StartCoroutine(MaterialWarning());
    }

    //Shield upgrade 
    //je voegt 1 punt toe aan de shield
    // er wordt 1 van de Resources af gehaald
    public void UpgradeShield()
    {
        if(UI.materials >= cost) {
            playerController.shield += 1;

            UI.materials -= cost;
        }
        else
            StartCoroutine(MaterialWarning());
    }


    //Adds a extra point to the damage of the player
    public void UpgradeDamage()
    {
        //Only upgrades the damage if the players damage is not already upgraded
        if(playerController.damage < 2)
        {
            if (UI.materials >= cost)
            {
                playerController.damage += 1;

                UI.materials -= cost;
            }
            else
                StartCoroutine(MaterialWarning());
        }
    }

    public IEnumerator MaterialWarning()
    {
        if(Warning)
        {
            Warning.GetComponent<Text>().enabled = true;

            yield return new WaitForSeconds(3);
            Warning.GetComponent<Text>().enabled = false;
        }
    }
}