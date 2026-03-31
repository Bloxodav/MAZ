using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class KeyStart : MonoBehaviour
{
    public XRKnob xrKnob;

    [SerializeField]
    private GameObject objectToActivate1;

    [SerializeField]
    private GameObject objectToActivate2;

    [SerializeField]
    private AudioClip soundClip;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField] private CarController carController;

    private bool siker = true;
  

    private void Update()
    {
        if (xrKnob.value == 1 && siker == true)
        {
            
            if (objectToActivate1 != null)
                objectToActivate1.SetActive(true);

            if (objectToActivate2 != null)
                objectToActivate2.SetActive(true);

            carController.enabled = true;
          
            if (audioSource != null && soundClip != null)
            {
                audioSource.clip = soundClip;
                audioSource.Play();
            }
            siker = false;
        }
      
    }
}
