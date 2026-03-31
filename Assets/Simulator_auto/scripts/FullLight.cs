using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullLight : MonoBehaviour
{
    public GameObject dalni;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lepestok"))
        {
            dalni.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Lepestok"))
        {
            dalni.SetActive(false);
        }
    }
}
