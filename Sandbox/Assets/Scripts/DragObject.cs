using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToMove = null;
    [SerializeField]
    private Camera cameraToReference = null;

    private Vector3 offset;
    private float ZCoord;

    private void OnMouseDown()
    {
        ZCoord = cameraToReference.WorldToScreenPoint(objectToMove.transform.position).z;
        offset = objectToMove.transform.position - GetMouseOffset();
    }

    private Vector3 GetMouseOffset()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = ZCoord;

        return cameraToReference.WorldToScreenPoint(mousePosition);
    }

    private void OnMouseDrag()
    {
        objectToMove.transform.position = offset + GetMouseOffset();
    }
}
