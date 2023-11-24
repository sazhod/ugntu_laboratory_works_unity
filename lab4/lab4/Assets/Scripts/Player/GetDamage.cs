using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDamage : MonoBehaviour
{
    [SerializeField] private float damagePerSecond;
    [SerializeField] private float hp ;
    [SerializeField] private Text text;
    [SerializeField] private GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = hp.ToString();
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.name == fire.name);

        if (other.gameObject.tag == "Fire")
        {
            hp -= damagePerSecond * Time.deltaTime;

            Debug.Log(hp);

        }
    }

    private IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
