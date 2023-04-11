using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeCollisionV2 : MonoBehaviour
{
    private cutManager cutManager;
    private bool cutting = false;
    public GameObject cutPoint;

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
            if (cutManager.getCutLine() != null)
            {
                Vector3 point = Physics.ClosestPoint(cutPoint.transform.position, cutManager.getCutLine(), cutManager.getCutLine().transform.position, cutManager.getCutLine().transform.rotation);
                point = point - cutPoint.transform.position;

                //Debug.Log("x: " + point.x + " y: " + point.y + " z: " + point.z);
                Debug.Log(Mathf.Sqrt(Mathf.Pow(point.x, 2) + Mathf.Pow(point.x, 2)) * 1000);
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

                Vector3 point = Physics.ClosestPoint(cutPoint.transform.position, cutManager.getCutLine(), cutManager.getCutLine().transform.position, cutManager.getCutLine().transform.rotation);
                point = point - cutPoint.transform.position;
                cutManager.getCut().errorPoint(Mathf.Sqrt(Mathf.Pow(point.x, 2) + Mathf.Pow(point.x, 2)) * 1000);
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
