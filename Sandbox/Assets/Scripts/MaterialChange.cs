using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{

    [SerializeField]
    private MeshRenderer materialToChange = null;

    [SerializeField]
    private Material oldMaterial = null;

    [SerializeField]
    private Material newMaterial = null;

    private void OnMouseDown()
    {
        materialToChange.material = newMaterial;
    }

    private void OnMouseUp()
    {
        materialToChange.material = oldMaterial;
    }
}
