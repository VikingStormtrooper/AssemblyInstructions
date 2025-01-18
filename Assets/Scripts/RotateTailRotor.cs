using UnityEngine;

public class RotateTailRotor : MonoBehaviour
{
    float rotationSpeed = 1000.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime, Space.Self);
    }
}