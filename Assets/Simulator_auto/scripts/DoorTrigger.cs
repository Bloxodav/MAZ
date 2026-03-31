using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject key;
    public GameObject key2;
    public Animator key2Animator;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Key"))
        {
            hasTriggered = true;
            key.SetActive(false);
            key2.SetActive(true);
            key2Animator.SetTrigger("open");
        }
    }

  
    public void ReverseVisibility()
    {
        key.SetActive(false);
        key2.SetActive(true);
    }
}
