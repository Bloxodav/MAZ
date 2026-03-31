using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class FastFullLight : MonoBehaviour
{
    [SerializeField] private XrLepestok lepestok;
    [SerializeField] private GameObject fullLight;
    public AudioSource audioSource;
    public AudioClip clickSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lepestok"))
        {
          fullLight.SetActive(true);
            if (lepestok != null)
            {
                lepestok.end = true;
            }
            PlayClickSound();
        }
        else
        {
            lepestok.end = false;
            fullLight.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Lepestok"))
        {
            if (lepestok != null)
            {
                fullLight.SetActive(false);
                lepestok.end = false;
            }
        }
    }


   
    void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.clip = clickSound;
            audioSource.Play();
        }
    }
}