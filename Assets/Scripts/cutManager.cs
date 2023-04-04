using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cuts;
    private int currentCutNum;
    private cutFrameworkV3 currentCut;
    private Collider cutLine;

    // Start is called before the first frame update
    void Start()
    {
        if (cuts.Length > 0)
        {
            currentCutNum = 0;
            cuts[currentCutNum].SetActive(true);
            currentCut = cuts[0].GetComponent<cutFrameworkV3>();
            currentCut.Restart("test");
            Transform[] allChildren = cuts[0].transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {

                if (allChildren[i].tag == "BestCut")
                    cutLine = allChildren[i].GetComponent<Collider>();
            }
        }
        else
        {
            Debug.Log("No cuts found!");
        }
    }

    public cutFrameworkV3 getCut()
    {
        return currentCut;
    }

    public void nextCut()
    {
        currentCutNum++;
        if (currentCutNum < cuts.Length)
        {
            cuts[currentCutNum].SetActive(true);
            currentCut = cuts[currentCutNum].GetComponent<cutFrameworkV3>();


            Transform[] allChildren = cuts[currentCutNum].transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {
                if (allChildren[i].tag == "BestCut")
                    cutLine = allChildren[i].GetComponent<Collider>();
            }
        }
        else
        {
            Debug.Log("All cuts complete");
        }
    }

    public Collider getCutLine()
    {
        return cutLine;
    }
}
