using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerSound : MonoBehaviour
{
    AudioSource source;

    SphereCollider soundTrigger;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<SphereCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        source.Play();
    }
}
