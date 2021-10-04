using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent playerDie;
    bool playerDieState;
    [SerializeField] UnityEvent pauseTheGame;
    bool pauseState;
    [SerializeField] UnityEvent finishGame;
    bool finishGameState;

    public void IsPlayerDie()
    {
        playerDie?.Invoke();
        if(!playerDieState)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        playerDieState = !playerDieState;
    }

    public void ifPauseGame()
    {
        pauseTheGame?.Invoke();
        if(!pauseState)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        pauseState = !pauseState;
    }

    public void IfFinishGame()
    {
        finishGame?.Invoke();
        if(!finishGameState)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        finishGameState = !finishGameState;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("MainMenu");
        //SceneManager.LoadScene("MainMenu");
    }
}
