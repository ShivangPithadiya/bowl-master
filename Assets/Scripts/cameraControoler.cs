using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControoler : MonoBehaviour
{
    public Ball ball;
    private Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {

        offSet = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ball.transform.position.z <= 1829)
        {
            transform.position = ball.transform.position + offSet;
        }
        
    }
}
