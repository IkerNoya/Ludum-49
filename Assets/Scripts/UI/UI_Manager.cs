using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] GameObject DieHUB;
    bool DieHUBState;
    [SerializeField] GameObject PauseHUB;
    bool pauseHUBState;
    [SerializeField] GameObject FinishHUB;
    bool finishHUBState;
    [SerializeField] UnityEvent resumeGame;
    [SerializeField] UnityEvent returnToMenu;
    [SerializeField] UnityEvent restartGame;

    private void Start() 
    {
        DieHUB.SetActive(false);
        PauseHUB.SetActive(false);
        FinishHUB.SetActive(false);
    }

    public void ActivateDieHub()
    {
        if(!DieHUBState)
            DieHUB.SetActive(true);
        else
            DieHUB.SetActive(false);
        DieHUBState = !DieHUBState;
    }

    public void ActivateWinHub()
    {
        if(!finishHUBState)
            FinishHUB.SetActive(true);
        else
            FinishHUB.SetActive(false);
        finishHUBState = !finishHUBState;
        ActivateDieHub();
    }

    public void ActivatePauseHub()
    {
        if(!pauseHUBState)
            PauseHUB.SetActive(true);
        else
            PauseHUB.SetActive(false);
        pauseHUBState = !pauseHUBState;
    }

    public void ReturnToMenu()
    {
        returnToMenu?.Invoke();
    }

    public void ResumeGame()
    {
        resumeGame?.Invoke();
    }

    public void RestartGame()
    {
        restartGame?.Invoke();
    }
}
