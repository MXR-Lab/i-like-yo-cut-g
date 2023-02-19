using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutFramework : MonoBehaviour
{
    [SerializeField] private GameObject objDestroyed;
    [SerializeField] private Transform cutSlice;
    bool crossGate1 = false;
    bool crossGate2 = false;
    bool crossGate3 = false;

    public void Awake()
    {
        if ((crossGate1 && crossGate2 && crossGate3) == true)
                {
                    Destroy(objDestroyed);
                    Instantiate(cutSlice, objDestroyed.transform.position, objDestroyed.transform.rotation);
                    Debug.Log("Split");
                }
        if (crossGate1 == false && (crossGate2 || crossGate3) == true) Restart();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "gate1")
        {
            crossGate1 = true;
            Debug.Log("Gate 1 crossed");
        }
        if (collision.gameObject.name == "gate2")
        {
            crossGate2 = true;
            Debug.Log("Gate 2 crossed");
        }
        if (collision.gameObject.name == "gate3")
        {
            crossGate3 = true;
            Debug.Log("Gate 3 crossed");
        }
        if (collision.gameObject.name == "border1" || collision.gameObject.name == "border2")
        {
            Restart();
        }
    }
    private void Restart()
    {
        crossGate1 = false;
        crossGate2 = false;
        crossGate3 = false;
        Debug.Log("Try again");
    }
}
