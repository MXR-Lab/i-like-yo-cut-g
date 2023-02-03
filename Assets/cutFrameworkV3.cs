using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutFrameworkV3 : MonoBehaviour
{
    [SerializeField] private bool[] crossGates;
    [SerializeField] private GameObject cutSlice;

    public void Start()
    {
        crossGates = new bool[3]; // dynamically get number of gates next time, okay?
        for (int i = 0; i < crossGates.Length; i++)
            crossGates[i] = false;
    }

    public void gatePassed(int gateIndex)
    {
        if(gateIndex > 0)
        {
            if (!crossGates[gateIndex - 1])
            {
                Restart();
                return;
            }
        }
        crossGates[gateIndex] = true;
        if (checkComplete())
           instantiateCut();


    }

    public bool checkComplete()
    {
        bool complete = true;
        for(int i = 0; i < crossGates.Length; i++)
        {
            if (!crossGates[i])
                complete = false;
        }
        return complete;
    }

    private void instantiateCut()
    {
        Destroy(gameObject);
        Instantiate(cutSlice, transform.position, transform.rotation);
        Debug.Log("Split");
    }

    public void Restart()
    {
        for (int i = 0; i < crossGates.Length; i++)
        {
            crossGates[i] = false;
        }
        Debug.Log("Try again");
    }
}
