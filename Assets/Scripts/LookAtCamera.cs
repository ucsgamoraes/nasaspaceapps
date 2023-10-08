using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform target; // The target object to look at

    void Update()
    {
        if (target != null)
        {
            // Make the camera look at the target
            transform.LookAt(target);
        }
    }
}