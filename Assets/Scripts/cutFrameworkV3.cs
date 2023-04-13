using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class cutFrameworkV3 : MonoBehaviour
{
    private bool[] crossGates = new bool[1];
    private cutManager cutManager;
    private float sumError;
    public string cutName;
    public GameObject cutPart;

    void Start()
    {
        if (GameObject.Find("CutManager") && !(GameObject.Find("CutManager").GetComponent<cutManager>() == null))
        {
            cutManager = GameObject.Find("CutManager").GetComponent<cutManager>();
            int numGates = 0;
            Transform[] allChildren = this.transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {
                if (allChildren[i].tag == "Gate")
                    numGates++;
            }
            crossGates = new bool[numGates];
            for (int i = 0; i < crossGates.Length; i++)
                crossGates[i] = false;

            cutManager.setCut(this.gameObject);
            
        }
        else
        {
            Debug.Log("CutManager not found!");
        }  

    }

    public void gatePassed(int gateIndex)
    {
        Debug.Log(gateIndex);
        crossGates[gateIndex] = true;
        if (checkComplete())
        {
            cutManager.recordCut(cutName, getAvgError());
            instantiateCut();
            Destroy(this.gameObject);
        }
    }

    public void errorPoint(float distance)
    {
        sumError += distance;
    }

    public float getAvgError()
    {
        return sumError / crossGates.Length;
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
        Debug.Log("Split");
        cutPart.AddComponent<Rigidbody>();
        cutPart.AddComponent<Grabbable>();
    }

    public void Restart(string reason)
    {
        if (!checkComplete())
        {
            sumError = 0;
            for (int i = 0; i < crossGates.Length; i++)
            {
                crossGates[i] = false;
            }
            Debug.Log(reason);
            Debug.Log("Try again");
        }
    }
}