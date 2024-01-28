using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] 
    private AudioSource audio;
    
    void Start()
    {
        audio.Play();
        DontDestroyOnLoad(this.gameObject);
    }
}
