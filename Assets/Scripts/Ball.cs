using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //private Rigidbody rb;
    public bool inPlay=false;
    public Vector3 launchVelocity;

    private Rigidbody rb;
    private Vector3 ballStartPos;
    private AudioSource ballAudio;
    // Start is called before the first frame update
    void Start()
    {
        ballStartPos = transform.position;
        rb = GetComponent<Rigidbody>();
        ballAudio = GetComponent<AudioSource>();
        rb.useGravity = false;
        //launch(launchVelocity);
        
    }
    public void launch(Vector3 velocity)
    {
        inPlay = true;
        rb.useGravity = true;
        rb.velocity = velocity;
        //rb.velocity = launchVelocity;
        ballAudio.Play();
    }
    public void reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
