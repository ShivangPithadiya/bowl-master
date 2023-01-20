using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pinSetter : MonoBehaviour
{
    DragLaunch draglaunch;
    public Animator pinsetter_anim;
    public bool printValue = false;
    public int howManyTimeBallLaunched = 0;
    public int currentRound = 1;
    //public BoxCollider forballCollider;
    //public BoxCollider forRoundCollider;
    public int eachTurnScore;
    //private int curruntpinCount;
    //private int totalRound = 0;
    //private int ispinsettel = 3;
    public GameObject pinSet;
    public float distanceToRaise= 90f;
    private Ball ball;
    public int lastStandingCount = -1;
    public Text standingDisplay;

    private float lastChangeTime;
    private bool ballEnterBox = false;

    // Start is called before the first frame update
    void Start()
    {
        draglaunch = FindObjectOfType<DragLaunch>();
        ball = FindObjectOfType<Ball>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (printValue)
        {
            if (howManyTimeBallLaunched == 1)
            {
                Debug.Log("CurruntRound" + currentRound + " launchCount " + howManyTimeBallLaunched);
                printValue = false;
                //pinsetter_anim.SetTrigger("TidyTrigger");
            }
            else if (howManyTimeBallLaunched == 2)
            {
                Debug.Log("CurruntRound" + currentRound + " launchCount " + howManyTimeBallLaunched);
                printValue = false;
                //pinsetter_anim.SetTrigger("TidyTrigger");

            }
            else if (howManyTimeBallLaunched == 3)
            {
                Debug.Log("CurruntRound" + currentRound + " launchCount " + howManyTimeBallLaunched);


                Debug.Log(currentRound + "Completed.........");
                currentRound++;
                printValue = false;
                //pinsetter_anim.SetTrigger("ResetTrigger");


            }
            else if (howManyTimeBallLaunched == 4)
            {
                Debug.Log("CurruntRound" + currentRound + " launchCount " + howManyTimeBallLaunched);
                printValue = false;
                //pinsetter_anim.SetTrigger("TidyTrigger");


            }
            else if (howManyTimeBallLaunched == 5)
            {
                Debug.Log("CurruntRound" + currentRound + " launchCount " + howManyTimeBallLaunched);
                printValue = false;
                //pinsetter_anim.SetTrigger("TidyTrigger");


            }
            else if (howManyTimeBallLaunched == 6)
            {
                Debug.Log("CurruntRound" + currentRound + " launchCount " + howManyTimeBallLaunched);

                Debug.Log(currentRound + "Completed.........");
                currentRound++;
                printValue = false;
                //pinsetter_anim.SetTrigger("ResetTrigger");

            }
            else if (howManyTimeBallLaunched == 7)
            {
                Debug.Log("CurruntRound" + currentRound + " launchCount " + howManyTimeBallLaunched);
                printValue = false;
                //pinsetter_anim.SetTrigger("TidyTrigger");


            }
            else if (howManyTimeBallLaunched == 8)
            {
                Debug.Log("CurruntRound" + currentRound + " launchCount " + howManyTimeBallLaunched);
                printValue = false;
                //pinsetter_anim.SetTrigger("TidyTrigger");


            }
            else if (howManyTimeBallLaunched == 9)
            {
                Debug.Log("CurruntRound" + currentRound + " launchCount " + howManyTimeBallLaunched);

                Debug.Log(currentRound + "Completed.........");
                currentRound = 1;
                howManyTimeBallLaunched = 0;
                printValue = false;
                //pinsetter_anim.SetTrigger("ResetTrigger");
            }


        }


        standingDisplay.text = countStanding().ToString();
        if (ballEnterBox)
        {
            checkStanding();
        }
    }
    public int countStanding()
    {
        int standing = 0;
        foreach(pin Pin in FindObjectsOfType<pin>())
        {
            if (Pin.isStanding())
            {
                standing++;
            }
        }
        return standing;
    }
    public void RaisePins()
    {
        Debug.Log("Raise PIns");

        foreach (pin Pin in FindObjectsOfType<pin>())
        {
            if (Pin.isStanding())
            {
                //Debug.Log(Pin.name + "pin is standing");
                Pin.rb.useGravity = false;
                Pin.transform.Translate(new Vector3(0,90f,0),Space.World);
                //Debug.Log(Pin.name +  Pin.transform.position.y);
            }
        }
    }
    public void LowerPins()
    {
        Debug.Log("Lower PIns");
        foreach (pin Pin in FindObjectsOfType<pin>())
        {
            if (Pin.isStanding())
            {
                //Debug.Log(Pin.name + "pin is standing");
                Pin.transform.Translate(new Vector3(0, 0f, 0), Space.World);
                Pin.rb.useGravity = true;
                //Debug.Log(Pin.name +  Pin.transform.position.y);
            }
        }

    }
    public void RenewPins()
    {
         Instantiate(pinSet, new Vector3(0, 20, 1829), Quaternion.identity);
        
    }
    void checkStanding()
    {
        int curruntStanding = countStanding();
        if (curruntStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = curruntStanding;
            return;
        }
        float settelTime = 3f;
        if((Time.time - lastChangeTime) > settelTime)
        {
            pinsHaveSetteled();

        }
    }
    public void pinfall()
    {
        if (countStanding() == 0)
        {
            //points count is 20
            Debug.Log(howManyTimeBallLaunched + currentRound+" all Pins are fall..............");
            pinsetter_anim.SetTrigger("ResetTrigger");

        }
        else
        {
            //jetli pin padi etla points
            checkCountStanding();

            //curruntpinCount = 10;
        }
    }
    public void checkCountStanding()
    {
        if (countStanding() == 10)
        {
            Debug.Log(howManyTimeBallLaunched +" "+ currentRound + "Falling pin  = 0");
            pinsetter_anim.SetTrigger("TidyTrigger");

        }
        else if(countStanding() == 9)
        {
            Debug.Log(howManyTimeBallLaunched + " " + currentRound + "Falling pin  = 1");
            pinsetter_anim.SetTrigger("TidyTrigger");
        }
        else if (countStanding() == 8)
        {
            Debug.Log(howManyTimeBallLaunched + " " + currentRound + "Falling pin  = 2");
            pinsetter_anim.SetTrigger("TidyTrigger");
        }
        else if (countStanding() == 7)
        {
            Debug.Log(howManyTimeBallLaunched + " " + currentRound + "Falling pin  = 3");
            pinsetter_anim.SetTrigger("TidyTrigger");
        }
        else if (countStanding() == 6)
        {
            Debug.Log(howManyTimeBallLaunched + " " + currentRound + "Falling pin  = 4");
            pinsetter_anim.SetTrigger("TidyTrigger");
        }
        else if (countStanding() == 5)
        {
            Debug.Log(howManyTimeBallLaunched + " " + currentRound + "Falling pin  = 5");
            pinsetter_anim.SetTrigger("TidyTrigger");
        }
        else if (countStanding() == 4)
        {
            Debug.Log(howManyTimeBallLaunched + " " + currentRound + "Falling pin  = 6");
            pinsetter_anim.SetTrigger("TidyTrigger");
        }
        else if (countStanding() == 3)
        {
            Debug.Log(howManyTimeBallLaunched + " " + currentRound + "Falling pin  = 7");
            pinsetter_anim.SetTrigger("TidyTrigger");
        }
        else if (countStanding() == 2)
        {
            Debug.Log(howManyTimeBallLaunched + " " + currentRound + "Falling pin  = 8");
            pinsetter_anim.SetTrigger("TidyTrigger");
        }
        else if (countStanding() == 1)
        {
            Debug.Log(howManyTimeBallLaunched + " " + currentRound + "Falling pin  = 9");
            pinsetter_anim.SetTrigger("TidyTrigger");
        }
        else if (countStanding() == 0)
        {
            Debug.Log(howManyTimeBallLaunched + " " + currentRound + "Falling pin  = 10");
            pinsetter_anim.SetTrigger("TidyTrigger");
        }
    }
    void pinsHaveSetteled()
    {
        //if(ispinsettel != 1) 
        //{
            //ispinsettel--;
            //curruntpinCount = countStanding();
            ball.reset();
            draglaunch.TouchPanel.SetActive(true);
            pinfall();
            lastStandingCount = -1;
            ballEnterBox = false;
            standingDisplay.color = Color.green;
        //}
        //else
        //{
        //    Debug.Log("3 ATTEMPT IS COMPLETED");
        //    totalRound--;
        //    ispinsettel = 3;
        //    Debug.Log("second round is start");
        //}

        //if(totalRound == 0)
        //{
        //    Debug.Log("1 Match is over");
        //}
        
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    GameObject thingHit = collision.gameObject;
    //    if (thingHit.GetComponent<Ball>())
    //    {
    //        ballEnterBox = true;
    //        standingDisplay.color = Color.red;
    //        Debug.Log(collision.gameObject.name + "Entered in box");
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    GameObject thingLeft = collision.gameObject;
    //    if (thingLeft.GetComponent<pin>())
    //    {
    //        Destroy(thingLeft);
    //    }
    //}
   
    private void OnTriggerEnter(Collider other)
    {
        //GameObject thingHit = other.gameObject;
        if (other.gameObject.GetComponent<Ball>())
        {
            ballEnterBox = true;
            standingDisplay.color = Color.red;
            //Debug.Log(other.gameObject.name + "Entered in box");
        }

    }
    private void OnTriggerExit(Collider other)
    {

        GameObject thingLeft = other.gameObject;
        if (thingLeft.GetComponent<pin>())
        {
            //ballEnterBox = true;
            //standingDisplay.color = Color.red;
            Destroy(thingLeft);
        }
    }
}
