using UnityEngine;

public class DoorEnterTrigger : MonoBehaviour
{
    public GameObject enterTrigger; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            if (enterTrigger != null)
            {
                enterTrigger.SetActive(true);
            }
        }
        else
        {
            enterTrigger.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            if (enterTrigger != null)
            {
                enterTrigger.SetActive(false);
            }
        }
    }
}
