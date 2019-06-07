using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text timerTime;
    private float timer = 10f;
    public bool setTimer = false;
<<<<<<< HEAD:Assets/Scripts/Camera-UI/Menu.cs
    public GameObject FadeOut;
=======
    
>>>>>>> 47d8df74c7e61290069826bd3e1cbcc207dc267c:Assets/Scripts/Menu.cs

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void sceneChange(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void fadeAnimPlay()
    {
        //if(FadeOut)
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
