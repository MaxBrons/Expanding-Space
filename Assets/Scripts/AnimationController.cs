using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    private SpriteRenderer sr;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        var angle = transform.eulerAngles.z;
        if (angle > 90 && angle < 270)
            sr.sortingOrder = 0;
        else
            sr.sortingOrder = 2;       
    }

    public void trigger_destroy()
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
}
