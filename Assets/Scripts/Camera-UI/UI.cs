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
    public GameObject fadeOut,WinFadeOut,ExitFadeOut;
    public static bool TutorialText = true;

    bool minimap = false, EscapeMenu = false,IsFadingOut = false;
    public GameObject MinimapObject, MinimapObject_Small, escapeText;
    public Camera cam;

    void Start()
    {
        SpriteArrayIndex = Feulbars.Length;
        feul = 100;

        if (SceneManager.GetActiveScene().buildIndex.Equals(3))
            TutorialText = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            minimap = true;
        else if (Input.GetKeyUp(KeyCode.S))
            minimap = false;

        if (Input.GetKeyDown(KeyCode.Escape) && !IsFadingOut && !EscapeMenu)
            EscapeMenu = true;
        else if (Input.GetKeyDown(KeyCode.Escape)&& !IsFadingOut && EscapeMenu)
            EscapeMenu = false;

        if (minimap && cam)
        {
            cam.orthographicSize = 150;
            MinimapObject.SetActive(true);
            MinimapObject_Small.SetActive(false);
        }
        else if (!minimap && cam && escapeText)
        {
            cam.orthographicSize = 50;
            MinimapObject.SetActive(false);
            MinimapObject_Small.SetActive(true);
        }

        if (EscapeMenu && escapeText)
        {
            GetComponent<Canvas>().enabled = false;
            escapeText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Y) && ExitFadeOut)
            {
                IsFadingOut = true;
                escapeText.SetActive(false);
                Instantiate(ExitFadeOut);
            }
        }
        else if (!EscapeMenu && escapeText)
        {
            GetComponent<Canvas>().enabled = true;
            escapeText.SetActive(false);
        }
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
        if (enemyCounter < 1 && WinFadeOut)
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
