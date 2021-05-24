using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Qualquer objeto que seja associado a este script recebe um audio source
[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    // Referência ao audio source
    private AudioSource audioSource;

    private void Awake()
    {
        // Referência ao audio source
        audioSource = GetComponent<AudioSource>();

    }

    // Método que deve ser chamado toda vez que um som/audio for tocado
    public void PlaySound(AudioClip clip) 
    {
        // Defini o audio clip
        audioSource.clip = clip;

        // Toca o audioclip passado
        audioSource.Play();

        
    }


}























