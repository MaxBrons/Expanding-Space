using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    
    public Text allEnemiesInScene;

    private float enemyCounter = 0,AmountOfFeul = 100;
    private int SpriteArrayIndex = 12;
    public Sprite[] Feulbars;
    public Image feulbar, TutorialImage;

    public static float feul = 100, materials = 0;
    public Text materialText;
    public GameObject fadeOut,WinFadeOut;
    public static bool TutorialText = true;

    void Start()
    {
        SpriteArrayIndex = Feulbars.Length;
        feul = 100;
    }

    void FixedUpdate()
    {
        //Shows all the enemies in that are in the scene
        if(allEnemiesInScene)
        {
            enemyCounter = GameObject.FindGameObjectsWithTag("Enemy").Length;
            allEnemiesInScene.text = "Enemies: " + enemyCounter.ToString();
        }

        //Shows the amount of materials you have
        if(materialText)
            materialText.text = materials.ToString();

        //You won and will return to your Base
        if (enemyCounter == 0 && WinFadeOut)
        {
            Menu.cameraPosBool = true;
            Instantiate(WinFadeOut);
        }


        if (Feulbars.Length != 0)
            FeulDrainage();

        //Tutorial text is shown first time the game begins
        if(TutorialText && TutorialImage)
        {
            TutorialImage.enabled = true;
            if(Input.GetButtonDown("Fire1"))
            {
                TutorialImage.enabled = false;
                TutorialText = false;
            }
        }
    }

    //Changes the sprite of the feulbar when the fuel drops below a point
    public void FeulDrainage()
    {
        //Sets the proper sprite for the amount of feul that's left
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
