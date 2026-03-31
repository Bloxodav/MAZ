using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuzov : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isPlaying = false;
    public void PlaySound()
    {
        if (audioSource != null && !isPlaying)
        {
            audioSource.Play();
            isPlaying = true;
            StartCoroutine(WaitForSoundFinish());
        }
    }

    IEnumerator WaitForSoundFinish()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        isPlaying = false;
    }

}
