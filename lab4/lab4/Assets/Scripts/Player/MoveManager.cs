using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Vector3 move;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Text resultText;
    [SerializeField] private Canvas endCanvas;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if ((move.x = Input.GetAxis("Horizontal")) != 0
                    || (move.z = Input.GetAxis("Vertical")) != 0)
        {
            var moveDirection = new Vector3(move.x, 0, move.z);
            var movePosition = transform.position + moveDirection;
            navMeshAgent.speed = 30;
            navMeshAgent.SetDestination(movePosition);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            navMeshAgent.speed = 10;
            RaycastHit raycastHit;
            // получаем внутриигровые коорднаты в месте, где была нажата кнопка мыши
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity)) // получаем вектор направления туда, где была нажата кнопка мыши
            {
                Debug.Log("Move");
                // просчитываем паршрут до точки и перемещаемся туда
                navMeshAgent.SetDestination(raycastHit.point);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "SafeZone")
        {
            resultText.text = "Вы справились!";
            Time.timeScale = 0;
            endCanvas.enabled = true;
        }
    }
}
