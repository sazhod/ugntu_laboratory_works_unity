using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    [SerializeField] private Text message;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")
        {
            message.text = "Нажмите <E> чтобы открыть/закрыть дверь";
        }
        else if (other.tag == "Teleport1" || other.tag == "Teleport2")
        {
            message.text = "Нажмите <T> чтобы переместиться";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            message.text = "";
        }
        else if (other.tag == "Teleport1" || other.tag == "Teleport2")
        {
            message.text = "";
        }
    }
}
