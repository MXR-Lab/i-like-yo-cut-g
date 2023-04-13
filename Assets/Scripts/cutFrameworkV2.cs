using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutFrameworkV2 : MonoBehaviour
{

    [SerializeField] public GameObject g1;
    [SerializeField] public GameObject g2;
    [SerializeField] public GameObject g3;

    [SerializeField] private Transform cutSlice;
    public bool crossGate1 = false;
    public bool crossGate2 = false;
    public bool crossGate3 = false;

    public knifeCollisions kC;

    public void Update()
    {
        if ((crossGate1 && crossGate2 && crossGate3) == true)
        {
            Destroy(gameObject);
            Instantiate(cutSlice, transform.position, transform.rotation);
            Debug.Log("Split");
        }
        if (crossGate1 == false && (crossGate2 || crossGate3) == true) Restart();
    }
    
    public void Restart()
    {
        crossGate1 = false;
        crossGate2 = false;
        crossGate3 = false;
        Debug.Log("Try again");
    }
}