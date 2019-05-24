using UnityEngine;

public class spriteDirection : MonoBehaviour
{
    SpriteRenderer targetSprite;
    public Sprite[] spritesArray; //Stores the 8 sprites needed for all 8 directions
    Transform target;
    public string targetName; //The tag of the target

    void Start()
    {
        //Stores the Gameobject with the given tag in target
        target = transform.parent.Find(targetName);

        targetSprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //Checkes for the state of the players rotation
        //Changes the sprite according to the direction of the target
        var angle = target.transform.eulerAngles.z;
        if (angle < 0)
            angle += 360;

        if (angle <= 30 && angle >= 0 || angle <= 360 && angle >= 330)
            targetSprite.sprite = spritesArray[0];
        else if (angle > 30 && angle < 60)
            targetSprite.sprite = spritesArray[1];
        else if (angle <= 120 && angle >= 90 || angle <= 90 && angle >= 60)
            targetSprite.sprite = spritesArray[2];
        else if (angle > 120 && angle < 150)
            targetSprite.sprite = spritesArray[3];
        else if (angle <= 210 && angle >= 180 || angle <= 180 && angle >= 150)
            targetSprite.sprite = spritesArray[4];
        else if (angle > 210 && angle < 240)
            targetSprite.sprite = spritesArray[5];
        else if (angle <= 270 && angle >= 240 || angle <= 300 && angle >= 270)
            targetSprite.sprite = spritesArray[6];
        else if (angle > 300 && angle < 330)
            targetSprite.sprite = spritesArray[7];

    }
}
