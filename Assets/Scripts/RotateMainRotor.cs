using UnityEngine;

public class RotateMainRotor : MonoBehaviour
{
    float rotationSpeed = 1000.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       gameObject.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
    }
}