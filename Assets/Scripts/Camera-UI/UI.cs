using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text allEnemiesInScene;
    private float enemyCounter = 0,AmountOfFeul = 100;
    private int SpriteArrayIndex = 12;
    public Sprite[] Feulbars;
    public Image feulbar;
    public static float feul = 100;
    public static float materials = 0;
    public Text materialText;
    public GameObject fadeOut;

    void Start()
    {
        SpriteArrayIndex = Feulbars.Length;
    }

    void FixedUpdate()
    {
        enemyCounter = GameObject.FindGameObjectsWithTag("Enemy").Length;
        allEnemiesInScene.text = "Enemies: " + enemyCounter.ToString();
        materialText.text = materials.ToString();

        if (enemyCounter == 0 && fadeOut)
        {
            Menu.cameraPosBool = true;
            Instantiate(fadeOut);
        }

        if (Feulbars.Length != 0)
            FeulDrainage();
    }

    //Changes the sprite of the feulbar when the fuel drops below a point
    public void FeulDrainage()
    {
        if(feul <= AmountOfFeul)
        {
            SpriteArrayIndex -= 1;
            AmountOfFeul -= 7.7f;
            feulbar.sprite = Feulbars[SpriteArrayIndex];
        }
        if (feul <= 0)
        {
            feulbar.sprite = Feulbars[Feulbars.Length];
            Instantiate(fadeOut);
        }
    }
}
