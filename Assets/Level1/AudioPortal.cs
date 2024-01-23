using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPortal : MonoBehaviour
{
    public Transform player;
    public float soundDistance = 5.0f;
    public AudioClip portalSound;
    public float volume = 0.15f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = portalSound;
        audioSource.volume = volume;
        audioSource.loop = false;
    }


    void Update()
    {
        if (player == null)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Afspelen van het geluid als de speler dichtbij genoeg is en het geluid niet al aan het afspelen is
        if (distanceToPlayer <= soundDistance && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        // Stop het geluid als de speler te ver weg is of als het geluid aan het afspelen is
        if (distanceToPlayer > soundDistance && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
