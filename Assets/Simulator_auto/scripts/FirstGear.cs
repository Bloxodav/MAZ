using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGear : MonoBehaviour
{
    public float newMotorForce = 300f;
    [SerializeField] private CarController carController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Joystick"))
        {

            if (carController != null)
            {
                carController.SetMotorForce(newMotorForce);
            }
        }
    }
}
