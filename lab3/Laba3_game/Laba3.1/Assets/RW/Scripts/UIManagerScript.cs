using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private Animator startButton;
    [SerializeField] private Animator settingsButton;
    [SerializeField] private Animator dialog;
    [SerializeField] private Animator slideMenu;
    [SerializeField] private Animator gear;
    public void ToggleMenu()
    {
        bool isHidden = slideMenu.GetBool("isHidden");
        slideMenu.SetBool("isHidden", !isHidden);
        gear.SetBool("isHidden", !gear.GetBool("isHidden"));
    }
    public void OpenSettings()
    {
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", true);
    }
    public void CloseSettings()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden", false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("RocketMouse");
    }
}
