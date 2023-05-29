using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button play;
    public Button credits;
    public Button back;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene(6);
    }

    public void CloseCredits()
    {
        SceneManager.LoadScene(0);
    }

    public void Playground_Start()
    {
        SceneManager.LoadScene(1);

    }

    public void Hell()
    {
        SceneManager.LoadScene(2);
    }

    public void Cave()
    {
        SceneManager.LoadScene(3);
    }
    public void Dungeon()
    {
        SceneManager.LoadScene(4);
    }
    public void Playground_End()
    {
        SceneManager.LoadScene(5);
    }



}