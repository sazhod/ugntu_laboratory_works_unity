using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
    [SerializeField] private Button adventureGame;
    [SerializeField] private Button emergencyGame;
    [SerializeField] private Button examGame;
    private bool isOpen = false;

    public void AnimationsPlay()
    {
        if (isOpen)
            AnimationsCLosePlay();
        else
            AnimationsOpenPlay();
        isOpen = !isOpen;
    }

    private void AnimationsOpenPlay()
    {
        adventureGame.animator.Play("AdventureGameOpen");
        emergencyGame.animator.Play("EmergencyGameOpen");
        examGame.animator.Play("ExamGameOpen");
    }

    private void AnimationsCLosePlay()
    {
        adventureGame.animator.Play("AdventureGameClose");
        emergencyGame.animator.Play("EmergencyGameClose");
        examGame.animator.Play("ExamGameClose");
    }
}
