using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutManager : MonoBehaviour
{
    private cutFrameworkV3 currentCut;
    private Collider cutLine;
    private List<CutRecord> finishedCuts;
    private bool isTest;
    private bool showResults;
    public GameObject resultsMenu;
    public GameObject cowContainer;
    public DisplayError errorController;

    // Start is called before the first frame update
    void Start()
    {
        isTest = false;
        showResults = false;
        finishedCuts = new List<CutRecord>();
    }

    public void recordCut(string name, float error)
    {
        foreach(CutRecord cutRec in finishedCuts)
        {
            if (cutRec.getName().Equals(name))
            {
                if (isTest)
                    cutRec.addTestError(error);
                else
                    cutRec.addTeachError(error);

                errorController.updateResultsDisplay(finishedCuts);
                return;
            }
        }

        CutRecord newCut = new CutRecord(name);
        if (isTest)
            newCut.addTestError(error);
        else
            newCut.addTeachError(error);
        finishedCuts.Add(newCut);
        errorController.updateResultsDisplay(finishedCuts);
    }

    public cutFrameworkV3 getCut()
    {
        return currentCut;
    }

    public void setCut(GameObject newCut)
    {
        currentCut = newCut.GetComponent<cutFrameworkV3>();
        Transform[] allChildren = newCut.transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
        {
            if (allChildren[i].tag == "BestCut")
                cutLine = allChildren[i].GetComponent<Collider>();
        }
    }

    public Collider getCutLine()
    {
        return cutLine;
    }

    public void toggleTest()
    {
        isTest = !isTest;
        toggleGuide();
    }

    private void toggleGuide()
    {
        GameObject[] guides = GameObject.FindGameObjectsWithTag("Guide");
        foreach (GameObject guide in guides)
        {
            MeshRenderer renderer = guide.GetComponent<MeshRenderer>();
            renderer.enabled = !isTest;
        }
    }

    public void toggleResults()
    {
        showResults = !showResults;
        resultsMenu.SetActive(showResults);
    }

    public void enableCut(GameObject cutPrefabe)
    {
        if (cowContainer.transform.childCount != 0)
            GameObject.Destroy(cowContainer.transform.GetChild(0).gameObject);
        Instantiate(cutPrefabe, cowContainer.transform);
        toggleGuide();
    }
}
