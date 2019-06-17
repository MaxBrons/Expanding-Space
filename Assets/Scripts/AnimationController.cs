using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Animator Anim;
    private SpriteRenderer sr;

    //For the garage
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
        Destroy(gameObject);
    }

    public void onAnimationDone(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void triggerSet(string trigger)
    {
        Anim.SetTrigger(trigger);
    }

    public void MissionNumber()
    {
        missionNumber++;
    }


   public void PlayAnimationGA(int i)
    {
        if (i == 0)
            Instantiate(garageAnim);
        else if (i == 1)
            Instantiate(petAnim);
        else if (i == 2)
            Instantiate(garageAnim2);
        else if (i == 3)
            Instantiate(petAnim2);
    }

    public void Garage()
    {
        Instantiate(garageOpen);
        Instantiate(garageGO);
    }

    public void Pet()
    {
        Instantiate(garageOpen);
        Instantiate(petGO);
    }

    public void Exit(string tag)
    {
        Destroy(GameObject.FindGameObjectWithTag(tag));
        Instantiate(garageOpen);
    }
}
