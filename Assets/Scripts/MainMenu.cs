using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public AudioSource audioPlayer;
    public bool isMusicPlaying;
    public void musicOnOff()
    {
        if (isMusicPlaying == true)
        {
            isMusicPlaying = false;
            audioPlayer.enabled = false;
        }
        else
        {
            isMusicPlaying = true;
            audioPlayer.enabled = true;
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}