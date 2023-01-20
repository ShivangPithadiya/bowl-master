using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forBallCollider : MonoBehaviour
{
    pinSetter pinsetter;
    DragLaunch draglaunch;
    private Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        pinsetter = FindObjectOfType<pinSetter>();
        draglaunch = FindObjectOfType<DragLaunch>();
        ball = FindObjectOfType<Ball>();
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("ball"))
    //    {
    //        ball.reset();
    //        draglaunch.TouchPanel.SetActive(true);
    //        pinsetter.pinfall();
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("ball"))
        {
            ball.reset();
            draglaunch.TouchPanel.SetActive(true);
            pinsetter.pinfall();
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
