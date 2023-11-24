using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    private Vector3 move;
    private Vector3 mousePosition;

    void Update()
    {
        if ((move.x = Input.GetAxis("Horizontal")) != 0
            || (move.z = Input.GetAxis("Vertical")) != 0)
        {
            var rayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayFromCamera, out var hit))
            {
                var hitPointWithCharY = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(hitPointWithCharY);
            }
        }
    }
}
