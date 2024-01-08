using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool paused;

    //To be called from Input manager
    public delegate void PauseGame();
    public static PauseGame pause;
    /// <summary>
    /// Pauses the game when called, unpaused the game when called again
    /// </summary>
    public void Pause()
    {
        //Set paused bool to the opposite of itself
        paused = !paused;

        //Pause
        if (paused)
        {
            //Enable Pause menu
            pauseMenu.SetActive(true);

            //Pause game time
            Time.timeScale = 0f;

            //Disable look and movement
            InputManager.disableControls?.Invoke();

            //Unlock cursor from screen
            CursorLock.cursorLockHandler?.Invoke(false);
        }
        //Unpause
        else
        {
            //Disabled Pause menu
            pauseMenu.SetActive(false);

            //Sets game time back to normal
            Time.timeScale = 1f;

            //Re-enabled player controls
            InputManager.disableControls?.Invoke();

            //Lock cursor to screen
            CursorLock.cursorLockHandler?.Invoke(true);
        }
    }
    public void Quit() => Application.Quit();
    private void OnEnable()
    {
        pause += Pause;
    }
    private void OnDisable()
    {
        pause -= Pause;
    }
}
