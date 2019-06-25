using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    public AudioManager FXAudioManager;

    public GameObject AnimalAnim;

    public GameObject foxGO, koalaGO, pandaGO, penguinGO;//Animal prefabs
    public static bool fox = false, koala = false, panda = false, penguin = false;//Bool for petstation
    public Text[] AnimalText;//Text for petstation facts

    [SerializeField] private bool notAnim = true;

    private void Start()
    {
        //Enables the animal in the petstation
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
            setAnimalBool();
            FXAudioManager.FXAudio(0);
            Instantiate(AnimalAnim, transform.position, Quaternion.identity);
            Destroy(transform.gameObject);
        }
    }

    void destructAnimalAnim()
    {
        Destroy(gameObject);
    }

    public void ShowAnimalText(int animalTextInt)
    {
        //Enables the petstation animal facts text
        if(AnimalText.Length != 0)
        {
            for (int i = 0; i < AnimalText.Length; i++)
                AnimalText[i].GetComponent<Text>().enabled = false;

            AnimalText[animalTextInt].GetComponent<Text>().enabled = true;
        }
    }

    void setAnimalBool()
    {
        //Enables the animal in petstation when caught
        if (foxGO)
            fox = true;
        else if (koalaGO)
            koala = true;
        else if (pandaGO)
            panda = true;
        else if (penguinGO)
            penguin = true;
    }
}
