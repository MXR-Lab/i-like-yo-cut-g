using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeCollisionV2 : MonoBehaviour
{
    public cutFrameworkV3 cutFramework;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != null)
        {
            if(collision.CompareTag("Gate"))
            {
                gateInfo gate = collision.gameObject.GetComponent<gateInfo>();
                cutFramework.gatePassed(gate.getGateIndex());
            }
            
            if(collision.CompareTag("Border"))
            {
                Debug.Log("hit border");
                cutFramework.Restart();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject != null)
        {
            if (other.CompareTag("Carcass"))
            {
                Debug.Log("Left carcass");
                cutFramework.Restart();
            }
        }
    }
}
