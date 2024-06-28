using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 dragStartPoint;
    

    private void Awake()
    {
        //������������ ��� ������ ��������� 
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPoint(Vector3 worldPoint)
    {
        //initiate the start point of line
        dragStartPoint = worldPoint;
        // �������� ��� ��������� ��� lineRender
        lineRenderer.SetPosition(0, dragStartPoint);
    }

    public void SetEndPoint(Vector3 worldPoint)
    {
        //��� �������� �� offset ������, ������� �� ������� ��� ����� ��� �� ����������� ��� ��� �������
        Vector3 pointOffset = worldPoint - dragStartPoint;
        //����������� �� offset ��� position 
        Vector3 endPoint = transform.position + pointOffset;

        lineRenderer.SetPosition(1, endPoint);
    }


}

