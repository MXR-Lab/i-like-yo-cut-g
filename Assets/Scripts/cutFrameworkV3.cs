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
    //[SerializeField] private GameObject newCut;
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

            Debug.Log("Starting");
            Debug.Log(crossGates.Length);
            
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
            //cutManager.nextCut();
            cutManager.recordCut(cutName, getAvgError());
            instantiateCut();
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
        //Destroy(gameObject);
        //Instantiate(cutSlice, transform.position, transform.rotation);
        Debug.Log("Split");
        //Destroy(gameObject);
        //var mc = gameObject.AddComponent<MeshCollider>();
        //mc.convex = true;
        //gameObject.AddComponent<Rigidbody>();
        //gameObject.AddComponent<Grabbable>();
        cutPart.AddComponent<Rigidbody>();
        cutPart.AddComponent<Grabbable>();
        //Destroy(gameObject.transform.GetChild(0).gameObject);
        //newCut.transform.GetChild(0).gameObject.SetActive(true);
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