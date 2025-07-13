using UnityEngine;

public class ObsticleRotate : MonoBehaviour
{
    //[SerializeField] Vector3 vetcorPoint;
    [SerializeField] Vector3 vectorAxis;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(vectorAxis, speed*Time.deltaTime);
    }
}
