using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseDoor : MonoBehaviour
{
    [SerializeField] private Animator openandclose;
    [SerializeField] private Transform Player;
    [SerializeField] private float useDistance;

    private bool open;


    private void Start()
    {
        open = false;
    }

    private void Update()
    {
        if (Player)
        {   
            float dist = Vector3.Distance(Player.position, transform.position);
            if (dist < useDistance)
            {
                if (open == false)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        StartCoroutine(opening());

                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        StartCoroutine(closing());
                    }
                }
            }
        }
    }

    IEnumerator opening()
    {
        openandclose.Play("Opening");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
