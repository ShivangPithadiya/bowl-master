using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    public GameObject TouchPanel;
    private pinSetter pinsetter;
    private Ball ball;
    private Vector3 dragstart, dragend;
    private float starttime, endtime;
    // Start is called before the first frame update
    void Start()
    {
        pinsetter = FindObjectOfType<pinSetter>();
        ball = GetComponent<Ball>();
    }


    public void dragStart()
    {
        dragstart = Input.mousePosition;
        starttime = Time.time;
    }

    public void dragEnd()
    {
        dragend = Input.mousePosition;
        endtime = Time.time;

        float dragduration = endtime - starttime;
        float launchspeedX = (dragend.x-dragstart.x) / dragduration;
        float launchspeedZ = (dragend.y - dragstart.y) / dragduration;

        Vector3 launchVelocity = new Vector3(launchspeedX, 0, launchspeedZ);
        ball.launch(launchVelocity);
        TouchPanel.SetActive(false);
        pinsetter.printValue = true;
        pinsetter.howManyTimeBallLaunched++;
       

    }

    public void movestart(float amount)
    {
        if (!ball.inPlay)
        {
            ball.transform.Translate(new Vector3(amount, 0, 0));

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
