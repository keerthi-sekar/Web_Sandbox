using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public event Action<bool> OnGrab;
    public event Action<bool> OnHover; //For Highlight on Hover - use separate class with OnTriggerEnter, OnTriggerStay, OnTriggerExit (Colliders), and OnMouseDown

    private void OnMouseDown()
    {
        if (OnGrab != null)
        {
            OnGrab(true);
        }
    }

    private void OnMouseUp()
    {
        if (OnGrab != null)
        {
            OnGrab(false);
        }
    }

}