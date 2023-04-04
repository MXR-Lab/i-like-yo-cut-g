using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class knifeCollisionV2 : MonoBehaviour
{
    private cutManager cutManager;
    private bool cutting = false;
    public GameObject cutPoint;
    public TMP_Text text;

    void Start()
    {
        if (GameObject.Find("CutManager") && !(GameObject.Find("CutManager").GetComponent<cutManager>() == null))
        {
            cutManager = GameObject.Find("CutManager").GetComponent<cutManager>();
        }
        else
        {
            Debug.Log("CutManager not found!");
        }
    }

    private void Update()
    {
        if(cutting)
        {
            if (cutManager.getCutLine() != null && cutManager.getCut().startedCutting())
            {
                Vector3 point = Physics.ClosestPoint(cutPoint.transform.position, cutManager.getCutLine(), cutManager.getCutLine().transform.position, cutManager.getCutLine().transform.rotation);
                point = point - cutPoint.transform.position;

                text.text = ("Error: " + Mathf.Sqrt(Mathf.Pow(point.x, 2) + Mathf.Pow(point.x, 2)) * 1000);
                //Debug.Log(Mathf.Sqrt(Mathf.Pow(point.x, 2) + Mathf.Pow(point.x, 2)) * 1000);
            }
            else
            {
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.CompareTag("Carcass"))
                cutting = true;
            if (collision.CompareTag("Gate"))
            {
                gateInfo gate = collision.gameObject.GetComponent<gateInfo>();
                cutManager.getCut().gatePassed(gate.getGateIndex());
            }
            
            if(collision.CompareTag("Border"))
            {
                cutManager.getCut().Restart("hit border");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject != null)
        {
            if (other.CompareTag("Carcass"))
            {
                cutting = false;
                cutManager.getCut().Restart("Left carcass");
            }
        }
    }
}
