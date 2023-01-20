using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour
{
    public Rigidbody rb;
    public float standingTreshold = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(name + isStanding());
        
    }
    public bool isStanding()
    {
        Vector3 rotationInEular = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Floor(-90 - rotationInEular.x );
        float tiltInZ = Mathf.Floor(rotationInEular.z);
        if(tiltInX<standingTreshold && tiltInZ < standingTreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
