using UnityEngine;

public class RGear : MonoBehaviour
{
    public float newMotorForce = -200f;
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
