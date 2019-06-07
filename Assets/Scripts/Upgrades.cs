using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Upgrades : MonoBehaviour
{
    public playerController upgrade;
    private GameObject player;

    public static Upgrades upgrades;
    private playerController stats;

    
    // je verbindt naar playerController
    void Start()
    {
        player = GameObject.Find("Player");
        upgrade = player.GetComponent<playerController>();
    }

    //hier upgrade je je health
    // je voegt 1 punt toe aan de health
    public void UpgradeHealth()
    {
        playerController.health += 1;
        // probleem ik zie bij de onClick <Missing Upgrades.UpgradeHealth> geen iedee hoe dit komt.
    }

    //speed upgrade 
    //je voegt er een punt aan toe
    public void UpgradeSpeed()
    {
        playerController.speed += 1;
        //probleem ik zie bij de OnClick <Missing Upgrades.UpgradeSpeed> geen iedee hoe dit komt.
    }
}