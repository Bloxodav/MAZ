using UnityEngine;

public class Speedometr : MonoBehaviour
{
    [SerializeField] private Transform needle;
    [SerializeField] private float maxSpeed = 100f;
    [SerializeField] private float maxRotationAngle = 170f;

    [SerializeField] private CarController carController;

    

    private void Update()
    {
        float currentSpeed = carController.GetCurrentSpeed();
        float rotationAngle = Mathf.Lerp(-67.363f, maxRotationAngle, currentSpeed / maxSpeed * 3f);
        needle.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }
}