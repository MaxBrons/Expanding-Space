using UnityEngine;

public class AnimalController : MonoBehaviour
{

    public GameObject AnimalAnim;

    public GameObject foxGO, koalaGO, pandaGO, penguinGO;
    public static bool fox = true, koala = true, panda = true, penguin = true;
    [SerializeField] private bool notAnim = true;

    private void Start()
    {
        if (foxGO && fox)
            foxGO.SetActive(true);
        if (koalaGO && koala)
            koalaGO.SetActive(true);
        if (pandaGO && panda)
            pandaGO.SetActive(true);
        if (penguinGO && penguin)
            penguinGO.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Spawns in the animation object of the animal
        if (collision.gameObject.tag == "Bullet" && notAnim && AnimalAnim)
        {
            Instantiate(AnimalAnim, transform.position, Quaternion.identity);
            fox = true;
            Destroy(transform.gameObject);
        }
    }

    void destructAnimalAnim()
    {
        Destroy(gameObject);
    }
}
