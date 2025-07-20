using UnityEngine;

public class UIArrow : MonoBehaviour
{
    public Transform target;
    public float arrowspeed;
    void Update()
    {
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;

    }
}
