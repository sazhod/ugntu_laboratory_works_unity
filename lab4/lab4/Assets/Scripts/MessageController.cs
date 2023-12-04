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
            message.text = "������� <E> ����� �������/������� �����";
        }
        else if (other.tag == "Teleport1" || other.tag == "Teleport2")
        {
            message.text = "������� <T> ����� �������������";
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
