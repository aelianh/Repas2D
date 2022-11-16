using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource _audioSource;
    public AudioClip Impacto;
    public AudioClip Estrella;
    
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);

    }

    public void SonidoImpacto()
    {
        _audioSource.PlayOneShot(Impacto);
        Debug.Log("a");
    }
    public void SonidoEstrella()
    {
        _audioSource.PlayOneShot(Estrella);
    }
}
