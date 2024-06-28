using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 dragStartPoint;
    

    private void Awake()
    {
        //δημιουργούμε την γραμμή στόχευσης 
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPoint(Vector3 worldPoint)
    {
        //initiate the start point of line
        dragStartPoint = worldPoint;
        // ορίζουμε την τοποθεσία του lineRender
        lineRenderer.SetPosition(0, dragStartPoint);
    }

    public void SetEndPoint(Vector3 worldPoint)
    {
        //εδω ορίζουμε το offset σημείο, θέλουμε να τραβάμε τον στόχο και να εμφανίζεται απο την ανάποδη
        Vector3 pointOffset = worldPoint - dragStartPoint;
        //προσθέτουμε το offset στο position 
        Vector3 endPoint = transform.position + pointOffset;

        lineRenderer.SetPosition(1, endPoint);
    }


}

