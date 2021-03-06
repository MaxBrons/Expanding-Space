﻿using UnityEngine;
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
    [SerializeField] private float timeToSmooth = 0;

    bool mayMoveToBase = false;

    //Audiomanager
    public AudioManager AudioManager;

    //For the fade animation
    public GameObject FadeOut,FadeMainMenu;

    //Set the camera position to a set position when a specific button is pressed
    public static bool cameraPosBool = false;

    void Start()
    {
        //Set the camera position to a set position when a specific button is pressed
        if (cameraPosBool && cam)
        {
            var camPosition = cam.transform.position = new Vector3(cam.transform.position.x, BaseScene.transform.position.z + 8, cam.transform.position.z);
            if (cam.position == camPosition)
                cameraPosBool = false;
        }
    }

    //The timer for the death screen
    public void Update()
    {
        if (setTimer)
        {
            //If the timer runs out, the player will automatically to Main Menu
            //and the background sound changes
            Cursor.lockState = CursorLockMode.None;
            timer -= Time.deltaTime;
            if (timerTime)
                timerTime.text = Mathf.Round(timer).ToString();

            if (timer <= 0)
            {
                //You will return to Main Menu
                SetCamPos(false);
                SceneManager.LoadScene(0);
            }
        }

        if (cam && mayMoveToBase)
        {
            //Closes the gap between the first and the second position over a set duration
            float posY = Mathf.SmoothDamp(cam.transform.position.y, BaseScene.transform.position.z + 8, ref vel.y, timeToSmooth);

            //Changes the position of the object with the script on it to the position of the set Point
            cam.transform.position = new Vector3(cam.transform.position.x, posY, cam.transform.position.z);
        }
    }

    //Load the scene with the set index
    public void PlayGame(int i)
    {
        SceneManager.LoadScene(i);
    }

    //Exits the game to desktop
    public void Exit()
    {
        Application.Quit();
    }

    //spawns the fade animation canvas
    public void fadeAnimPlay()
    {
        if (FadeOut)
            Instantiate(FadeOut);
    }

    public void FadeToMainMenu()
    {
        if (FadeMainMenu)
            Instantiate(FadeMainMenu);
    }

    //Moves the camera down from Main Menu to the Base
    public void MoveToBase()
    {
        mayMoveToBase = true;
    }

    //Sets the camera's position to the position of the Base
    public void SetCamPos(bool boolean)
    {
        cameraPosBool = boolean;
    }

    //Sets all the variables of the game back to their standards
    public void NewGame()
    {
        UI.materials = 0;
        UI.TutorialText = true;
        AnimationController.missionNumber = 1;

        playerController.health = 3;
        playerController.speed = 1f;
        playerController.shield = 1;
        playerController.damage = 1;
    }
}
