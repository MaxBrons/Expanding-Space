using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Animator Anim;
    private SpriteRenderer sr;

    //All animal gameobjects for the garage
    public GameObject garageGO, petGO, garageAnim, garageAnim2, petAnim, petAnim2, garageOpen;
    public Text MissionText;
    public static float missionNumber = 1;

    public void Start()
    {
        if (MissionText)
            MissionText.text = "Mission " + missionNumber.ToString();

        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (sr)
        {
            //Sets the sorting layer of the engineburst to 0 if the player looks downwards
            //Else the engine burst will be on top of the sprite
            var angle = transform.eulerAngles.z;
            if (angle > 85 && angle < 265)
                sr.sortingOrder = 0;
            else
                sr.sortingOrder = 2;
        }
    }
    public void destruct()
    {
        //This is for the destuction of the animation gameobject
        if (transform.parent)
            Destroy(transform.parent.gameObject);
        else
            Destroy(gameObject);
    }

    public void onAnimationDone(int i)
    {
        //Loads the scene off the given index
        SceneManager.LoadScene(i);
    }

    public void triggerSet(string trigger)
    {
        //Sets the chosen trigger for the animations
        Anim.SetTrigger(trigger);
    }

    public void MissionNumber()
    {
        //Every time a mission is launched, the mission number goes up
        missionNumber++;
    }


   public void PlayAnimationGA(int i)
    {
        //Instantiates the garagedoor animations
        if (i == 0 && GameObject.FindGameObjectsWithTag("GarageDoor").Length < 1)
            Instantiate(garageAnim);
        else if (i == 1 && GameObject.FindGameObjectsWithTag("GarageDoor").Length < 1)
            Instantiate(petAnim);
        else if (i == 2 && GameObject.FindGameObjectsWithTag("GarageDoor").Length < 1)
            Instantiate(garageAnim2);
        else if (i == 3 && GameObject.FindGameObjectsWithTag("GarageDoor").Length < 1)
            Instantiate(petAnim2);
    }

    public void Garage()
    {
        //Instantiates the garagedoor open animation   
        GameObject garage = Instantiate(garageOpen);
        GameObject garageStation = Instantiate(garageGO);
    }

    public void Pet()
    {
        //Instantiates the garagedoor open animation for the petstation
        GameObject garage = Instantiate(garageOpen);
        GameObject petStation = Instantiate(petGO);
    }

    public void Exit(string tag)
    {
        //Destroys the garage or petstation and Instantiates the garagedoor open animation
        Destroy(GameObject.FindGameObjectWithTag(tag));
        GameObject garage = Instantiate(garageOpen);
    }
}
