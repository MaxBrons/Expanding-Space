using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text allEnemiesInScene;
    private float enemyCounter = 0;
    public Sprite[] Feulbars;
    public Image feulbar;
    public static float feul = 100;
    public static float materials = 0;
    public Text materialText;
    public GameObject fadeOut;

    private void Start()
    {
        feul = 100;
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
        if (feul > 75)
            feulbar.sprite = Feulbars[0];
        else if (feul < 75 && feul > 50)
            feulbar.sprite = Feulbars[1];
        else if (feul < 50 && feul > 25)
            feulbar.sprite = Feulbars[2];
        else if (feul < 25 && feul > 0)
            feulbar.sprite = Feulbars[3];
        else if (feul <= 0)
        {
            feulbar.sprite = Feulbars[4];
            SceneManager.LoadScene(2);
        }
    }

}
