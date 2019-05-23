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
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    
    float timer = 5.0f;

    void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
