using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadMenuScene()
    {
        ResumeTime();
        SceneManager.LoadScene("Menu");
    }

    public void LoadAdventureGameScene()
    {
        ResumeTime();
        SceneManager.LoadScene("AdventureGame");
    }

    public void LoadEmergencyGameScene()
    {
        ResumeTime();
        SceneManager.LoadScene("EmergencyGame");
    }

    public void LoadTrainingGameScene()
    {
        ResumeTime();
        SceneManager.LoadScene("TrainingGame");
    }

    private void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
