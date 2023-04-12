using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cuts;
    private int currentCutNum;
    private cutFrameworkV3 currentCut;
    private Collider cutLine;
    private List<CutRecord> finishedCuts;
    private bool isTest;
    private bool showResults;

    public GameObject testCow;
    public GameObject teachCow;
    public GameObject resultsMenu;

    public GameObject testRound;
    public GameObject teachRound;

    public GameObject testLoin;
    public GameObject teachLoin;

    public GameObject testRib;
    public GameObject teachRib;

    public GameObject testChuck;
    public GameObject teachChuck;

    public DisplayError errorController;

    // Start is called before the first frame update
    void Start()
    {
        isTest = false;
        showResults = false;
        finishedCuts = new List<CutRecord>();
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

    public void toggleTest()
    {
        isTest = !isTest;
        testCow.SetActive(isTest);
        teachCow.SetActive(!isTest);
    }

    public void toggleResults()
    {
        showResults = !showResults;
        resultsMenu.SetActive(showResults);
    }

    public void enableRound()
    {
        testRound.SetActive(isTest);
        teachRound.SetActive(!isTest);

        testRib.SetActive(false);
        teachRib.SetActive(false);

        testLoin.SetActive(false);
        teachLoin.SetActive(false);

        testChuck.SetActive(false);
        teachChuck.SetActive(false);
    }

    public void enableLoin()
    {
        testRound.SetActive(false);
        teachRound.SetActive(false);

        testRib.SetActive(false);
        teachRib.SetActive(false);

        testLoin.SetActive(isTest);
        teachLoin.SetActive(!isTest);

        testChuck.SetActive(false);
        teachChuck.SetActive(false);
    }

    public void enableRib()
    {
        testRound.SetActive(false);
        teachRound.SetActive(false);

        testRib.SetActive(isTest);
        teachRib.SetActive(isTest);

        testLoin.SetActive(false);
        teachLoin.SetActive(false);

        testChuck.SetActive(false);
        teachChuck.SetActive(false);
    }

    public void enableChuck()
    {
        testRound.SetActive(false);
        teachRound.SetActive(false);

        testRib.SetActive(false);
        teachRib.SetActive(false);

        testLoin.SetActive(false);
        teachLoin.SetActive(false);

        testChuck.SetActive(isTest);
        teachChuck.SetActive(!isTest);
    }
}
