using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void launch()
    {

    }

    public void continueToPlay()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }

}
