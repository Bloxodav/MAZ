using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGear : MonoBehaviour
{
    public float newMotorForce = 600f;
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
