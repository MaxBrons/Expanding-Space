using UnityEngine;

public class AnimalController : MonoBehaviour
{

    public GameObject AnimalAnim;
    public GameObject foxGO, koalaGO, pandaGO, penguinGO;
    public static bool fox = false, koala = false, panda = false, penguin = false;
    [SerializeField] private bool notAnim = true;

    private void start()
    {
        if (foxGO && fox == true)
            foxGO.SetActive(true);
        if (koalaGO && koala == true)
            koalaGO.SetActive(true);
        if (pandaGO && panda == true)
            pandaGO.SetActive(true);
        if (penguinGO && penguin == true)
            penguinGO.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Spawns in the animation object of the animal
        if (collision.gameObject.tag == "Bullet" && notAnim && AnimalAnim)
        {
            Instantiate(AnimalAnim, transform.position, Quaternion.identity);
            Destroy(transform.gameObject);
        }
    }

    void destructAnimalAnim()
    {
        Destroy(gameObject);
    }


}
