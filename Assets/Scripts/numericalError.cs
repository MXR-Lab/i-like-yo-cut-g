using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numericalError : MonoBehaviour
{
    public GameObject cutPoint;
    public Collider cutLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = Physics.ClosestPoint(cutPoint.transform.position, cutLine, cutLine.transform.position, cutLine.transform.rotation);
        point = point - cutPoint.transform.position;
        Debug.Log("x: " + point.x + " y: " + point.y + " z: " + point.z);
    }
}
