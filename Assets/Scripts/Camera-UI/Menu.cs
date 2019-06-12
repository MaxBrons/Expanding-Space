using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //For the death screen timer
    public Text timerTime;
    private float timer = 10f;
    [SerializeField] private bool setTimer = false;

    //For the camera that moves to the base
    public Transform cam;
    public GameObject BaseScene;
    Vector3 vel = Vector3.zero;
    [SerializeField] private float timeToSmooth = 0.3f;

    bool mayMoveToBase = false;

    //For the fade animation
    public GameObject FadeOut;

    //The timer for the death screen
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

        if (cam && mayMoveToBase)
        {
            
            //Closes the gap between the first and the second position over a set duration
            float posY = Mathf.SmoothDamp(cam.transform.position.y, BaseScene.transform.position.z+8, ref vel.y, timeToSmooth);

            //Changes the position of the object with the script on it to the position of the set Point
            cam.transform.position = new Vector3(cam.transform.position.x, posY, cam.transform.position.z);
        }
    }

    //Load the scene with the set index
    public void PlayGame(int i)
    {
        SceneManager.LoadScene(i);
    }

    //spawns the fade animation canvas
    public void fadeAnimPlay()
    {
        if(FadeOut)
            Instantiate(FadeOut);
    }

    //Exits the game to desktop
    public void Exit()
    {
        Application.Quit();
    }

    //Moves the camera down from Main Menu to the Base
    public void MoveToBase()
    {
        mayMoveToBase = true;
    }   
}
