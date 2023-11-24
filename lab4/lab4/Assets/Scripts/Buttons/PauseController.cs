using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas endCanvas;
    private bool isPaused = false;

    private void Start()
    {
        pauseCanvas.enabled = isPaused;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StateChange();
        }
    }

    public void StateChange()
    {
        if (endCanvas.enabled)
            return;
        if (!isPaused)
            StopTime();
        else
            ResumeTime();
        isPaused = !isPaused;
        pauseCanvas.enabled = isPaused;
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void ResumeTime()
    {
        Time.timeScale = 1;
    }


}
