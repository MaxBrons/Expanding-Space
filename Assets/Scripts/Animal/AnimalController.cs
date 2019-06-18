using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    public AudioManager audioManager;

    public GameObject AnimalAnim;

    public GameObject foxGO, koalaGO, pandaGO, penguinGO;
    public static bool fox = false, koala = false, panda = false, penguin = false;
    public Text[] AnimalText;
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
            audioManager.PlayAudio(0);
            Instantiate(AnimalAnim, transform.position, Quaternion.identity);
            fox = true;
            Destroy(transform.gameObject);
        }
    }

    void destructAnimalAnim()
    {
        Destroy(gameObject);
    }

    public void ShowAnimalText(int animalTextInt)
    {
        if(AnimalText.Length != 0)
        {
            for (int i = 0; i < AnimalText.Length; i++)
                AnimalText[i].GetComponent<Text>().enabled = false;

            AnimalText[animalTextInt].GetComponent<Text>().enabled = true;
        }
    }
}
