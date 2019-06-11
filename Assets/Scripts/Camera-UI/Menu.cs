using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text timerTime;
    private float timer = 10f;
    public bool setTimer = false;

    public GameObject FadeOut;

    public void PlayGame(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void sceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void fadeAnimPlay()
    {
        if(FadeOut)
            Instantiate(FadeOut);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Update()
    {
        if (setTimer)
        {
            Cursor.lockState = CursorLockMode.None;
            timer -= Time.deltaTime;
            if (timerTime)
                timerTime.text = Mathf.Round(timer).ToString();
            if (timer <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

   
}
