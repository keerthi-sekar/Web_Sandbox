using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform playerCamera = null;
    [SerializeField]
    private PlayerInteraction playerInteraction = null;
    [SerializeField]
    private Transform destination = null;
    [SerializeField]
    private AnimationCurve animationCurve = null;

    private Vector3 currentPosition;
    private Quaternion currentRotation;
    private bool moving = false;
    private float time = 0.0f;

    protected void OnEnable()
    {
        playerInteraction.OnGrab += Travel;
    }

    protected void OnDisable()
    {
        playerInteraction.OnGrab -= Travel;
    }

    protected void LateUpdate()
    {
        if (!moving)
        {
            return;
        }
        playerCamera.position = Vector3.Slerp(currentPosition, destination.position, animationCurve.Evaluate(time));
        playerCamera.rotation = Quaternion.Slerp(currentRotation, destination.rotation, animationCurve.Evaluate(time));
        if (time <= animationCurve.keys[animationCurve.length - 1].time)
        {
            moving = true;
            time += Time.deltaTime;
        }
        else
        {
            moving = false;
        }
    }

    private void Travel(bool value)
    {
        if (!value)
        {
            return;
        }
        moving = true;
        currentPosition = playerCamera.position;
        currentRotation = playerCamera.rotation;
        time = 0;
    }
}
