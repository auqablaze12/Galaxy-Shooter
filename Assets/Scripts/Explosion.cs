using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private AudioSource _explosionAudio;
    [SerializeField]
    private AudioClip _explosionClip;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource _explosionAudio = GetComponent<AudioSource>();

        _explosionAudio.clip = _explosionClip;
        _explosionAudio.Play();
        Destroy(this.gameObject, 3f);
    }

}
