using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject UI_Credits;
    bool UI_CreditsState;

    private void Start() 
    {
        UI_Credits.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Hernan");
    }

    public void ActivateCredits()
    {
        if(!UI_CreditsState)
            UI_Credits.SetActive(true);
        else
            UI_Credits.SetActive(false);
        UI_CreditsState = !UI_CreditsState;
    }

    public void BackCredits()
    {
        UI_Credits.SetActive(false);
        UI_CreditsState = !UI_CreditsState;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
