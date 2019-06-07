using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{
    public Animator Anim;
    private SpriteRenderer sr;

    public void Start()
    {
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



}
