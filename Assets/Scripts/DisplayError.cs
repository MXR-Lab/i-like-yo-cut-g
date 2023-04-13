using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayError : MonoBehaviour
{
    public GameObject displayTemplate;

    public void updateResultsDisplay(List<CutRecord> results)
    {
        clearDisplay();
        //oldDisplay(results);
        newDisplay(results);

        
    }

    private void clearDisplay()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void newDisplay(List<CutRecord> results)
    {
        GameObject instantiated;
        foreach (CutRecord cutRec in results)
        {
            instantiated = Instantiate(displayTemplate, transform);
            string description = cutRec.getName() + ":";
            instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = description;

            List<float> teachErrors = cutRec.getTeachError();
            List<float> testErrors = cutRec.getTestErrors();
            int i = 0;
            while (i < teachErrors.Count || i < testErrors.Count)
            {
                if (i < teachErrors.Count)
                {
                    instantiated = Instantiate(displayTemplate, transform);
                    description = "    Teach Error " + (i + 1) + ": " + teachErrors[i].ToString("n2");
                    instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = description;
                }
                if(i < testErrors.Count)
                {
                    instantiated = Instantiate(displayTemplate, transform);
                    description = "    Test Error " + (i + 1) + ": " + testErrors[i].ToString("n2");
                    instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = description;
                }
                i++;
            }
        }
    }

    private void oldDisplay(List<CutRecord> results)
    {
        GameObject instantiated;
        foreach (CutRecord cutRec in results)
        {
            instantiated = Instantiate(displayTemplate, transform);
            string description = cutRec.getName() + ": \n";
            List<float> teachErrors = cutRec.getTeachError();
            List<float> testErrors = cutRec.getTestErrors();
            int i = 0;
            while (i < teachErrors.Count || i < testErrors.Count)
            {
                if (i < teachErrors.Count && i < testErrors.Count)
                {
                    description = description + "Teach Error " + (i + 1) + ": " + teachErrors[i].ToString("n2") + " | Test Error " + (i + 1) + ": " + testErrors[i].ToString("n2") + " \n";
                }
                else if (i < teachErrors.Count && i >= testErrors.Count)
                {
                    description = description + "Teach Error " + (i + 1) + ": " + teachErrors[i].ToString("n2") + " \n";
                }
                else if (i >= teachErrors.Count && i < testErrors.Count)
                {
                    description = description + "                  " + " | Test Error " + (i + 1) + ": " + testErrors[i].ToString("n2") + " \n";
                }
                i++;
            }
            instantiated.transform.GetChild(0).GetComponent<TMP_Text>().text = description;
        }
    }
}
