using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class cutFrameworkV3 : MonoBehaviour
{
    private bool[] crossGates = new bool[2];
    [SerializeField] private GameObject newCut;

    void Start()
    {
        Debug.Log("Starting!!");
        crossGates = new bool[2]; // dynamically get number of gates next time, okay?
        for (int i = 0; i < crossGates.Length; i++)
            crossGates[i] = false;
    }

    public void gatePassed(int gateIndex)
    {
        Debug.Log(gateIndex);
        if (gateIndex > 0)
        {
            if (!crossGates[gateIndex - 1])
            {
                Debug.Log("Skipped a gate");
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
        for (int i = 0; i < crossGates.Length; i++)
        {
            if (!crossGates[i])
                complete = false;
        }
        return complete;
    }

    private void instantiateCut()
    {
        //Instantiate(cutSlice, transform.position, transform.rotation);
        Debug.Log("Split");
        //Destroy(gameObject);
        var mc = gameObject.AddComponent<MeshCollider>();
        mc.convex = true;
        gameObject.AddComponent<Rigidbody>();
        gameObject.AddComponent<Grabbable>();
        Destroy(gameObject.transform.GetChild(0).gameObject);
        newCut.transform.GetChild(0).gameObject.SetActive(true);
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