using UnityEngine;

public class Translate : MonoBehaviour
{
    public float rotateSpeed = 1f;

    void Update()
    {
        // Rotate around the y-axis
        transform.Translate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}