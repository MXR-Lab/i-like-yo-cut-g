using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cuts;
    private int currentCutNum;
    private cutFrameworkV3 currentCut;
    // Start is called before the first frame update
    void Start()
    {
        if (cuts.Length > 0)
        {
            currentCutNum = 0;
            cuts[currentCutNum].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            currentCut = cuts[0].GetComponent<cutFrameworkV3>();
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
            cuts[currentCutNum].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            currentCut = cuts[0].GetComponent<cutFrameworkV3>();
        }
        else
        {
            Debug.Log("All cuts complete");
        }
    }
}
