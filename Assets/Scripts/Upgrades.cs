using UnityEngine;

public class Upgrades : MonoBehaviour
{
   
    //hier upgrade je je health
    // je voegt 1 punt toe aan de health
    // er wordt 1 van de Resources af gehaald
    public void UpgradeHealth()
    {
        if (UI.materials > 0)
        {
            playerController.health += 1;
            UI.materials -= 1;
        }
        else
            Debug.Log("You got no money");
    }

    //speed upgrade 
    //je voegt 1 punt toe aan de speed
    // er wordt 1 van de Resources af gehaald
    public void UpgradeSpeed()
    {
        if (UI.materials > 0)
        {
            playerController.speed += 1;
            UI.materials -= 1;
        }
        else
            Debug.Log("You got no money");      
    }


    //Shield upgrade 
    //je voegt 1 punt toe aan de shield
    // er wordt 1 van de Resources af gehaald
    public void UpgradeShield()
    {
        if(UI.materials > 0) {
            playerController.shield += 1;

            UI.materials -= 1;
        }
        else
            Debug.Log("You got no money");
    }
}