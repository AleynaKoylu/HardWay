using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void LSceneeButton(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public void Active(GameObject start)
    {
        start.SetActive(true);
    }
    public void Inactive(GameObject stop)
    {
        stop.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void Timee(int time)
    {
        Time.timeScale = time;
    }
}
