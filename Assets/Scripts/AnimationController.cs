using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public Animator animFade;
    private SpriteRenderer sr;

    public void Start()
    {
          sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (sr)
        {
            var angle = transform.eulerAngles.z;
            if (angle > 90 && angle < 270)
                sr.sortingOrder = 0;
            else
                sr.sortingOrder = 2;
        }     
    }
    public void destruct()
    {
        Destroy(gameObject);
    }
    public void move()
    {
        anim.SetTrigger("Move");
    }
    public void moving()
    {
        anim.SetTrigger("Moving");
    }
    public void stop()
    {
        anim.SetTrigger("Stop");
    }
    public void launch()
    {
        anim.SetTrigger("Deploy");
    }
    public void onAnimationDone(int i)
    {
        SceneManager.LoadScene(i);
    }

}
