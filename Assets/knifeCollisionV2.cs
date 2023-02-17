using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeCollisionV2 : MonoBehaviour
{
    private cutManager cutManager;

    void Start()
    {
        if (GameObject.Find("CutManager") && !(GameObject.Find("CutManager").GetComponent<cutManager>() == null))
        {
            cutManager = GameObject.Find("CutManager").GetComponent<cutManager>();
        }
        else
        {
            Debug.Log("CutManager not found!");
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != null)
        {
            if(collision.CompareTag("Gate"))
            {
                gateInfo gate = collision.gameObject.GetComponent<gateInfo>();
                cutManager.getCut().gatePassed(gate.getGateIndex());
            }
            
            if(collision.CompareTag("Border"))
            {
                cutManager.getCut().Restart("hit border");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject != null)
        {
            if (other.CompareTag("Carcass"))
            {
                cutManager.getCut().Restart("Left carcass");
            }
        }
    }
}
