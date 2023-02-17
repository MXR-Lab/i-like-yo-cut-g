using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class hapticFeedback : GrabbableHaptics
{
    //public knifeCollisionV2 knife;
    //public ControllerHand touchingHand;
    public Grabber grab1, grab2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.CompareTag("Gate"))
            {
                input.VibrateController(0.3f, 0.4f, 0.2f, grab1.HandSide);
                input.VibrateController(0.3f, 0.4f, 0.2f, grab2.HandSide);
            }
            else if (collision.CompareTag("Border"))
            {
                input.VibrateController(0.7f, 0.7f, 0.5f, grab1.HandSide);
                input.VibrateController(0.7f, 0.7f, 0.5f, grab2.HandSide);
            }   
        }
    }

    /*void buzz(ControllerHand touchingHand)
    {
        input.VibrateController(0.3f, 0.5f, 0.2f, touchingHand);
    }*/
    // Update is called once per frame
    void Update()
    {

    }
}