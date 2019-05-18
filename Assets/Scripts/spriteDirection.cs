using UnityEngine;

public class spriteDirection : MonoBehaviour
{
    SpriteRenderer playerSprite;
    public Sprite[] spritesArray;
    GameObject target;
    public string targetName;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetName);
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var angle = target.transform.eulerAngles.z;
        if (angle <= 30 && angle >= 0 || angle <= 360 && angle >= 330)
            playerSprite.sprite = spritesArray[0];
        else if (angle > 30 && angle < 60)
            playerSprite.sprite = spritesArray[7];
        else if (angle <= 120 && angle >= 90 || angle <= 90 && angle >= 60)
            playerSprite.sprite = spritesArray[6];
        else if (angle > 120 && angle < 150)
            playerSprite.sprite = spritesArray[5];
        else if (angle <= 210 && angle >= 180 || angle <= 180 && angle >= 150)
            playerSprite.sprite = spritesArray[4];
        else if (angle > 210 && angle < 240)
            playerSprite.sprite = spritesArray[3];
        else if (angle <= 270 && angle >= 240 || angle <= 300 && angle >= 270)
            playerSprite.sprite = spritesArray[2];
        else if (angle > 300 && angle < 330)
            playerSprite.sprite = spritesArray[1];

    }
}
