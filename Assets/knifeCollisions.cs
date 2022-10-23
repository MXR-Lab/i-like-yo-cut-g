using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeCollisions : MonoBehaviour
{
    public cutFrameworkV2 v2;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == v2.g1.name)
        {
            v2.crossGate1 = true;
            Debug.Log("Gate 1 crossed");
        }
        if (collision.gameObject.name == v2.g2.name)
        {
            v2.crossGate2 = true;
            Debug.Log("Gate 2 crossed");
        }
        if (collision.gameObject.name == "gate3")
        {
            v2.crossGate3 = true;
            Debug.Log("Gate 3 crossed");
        }
        if (collision.gameObject.name == "border1" || collision.gameObject.name == "border2")
        {
            v2.Restart();
        }
    }
}
