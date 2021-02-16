using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public enum SFXType {
        Hurt, 
        Collect,
        Destroy
    };
    public List<AudioClip> sfxList;
    public static AudioSource audioSource;
    
    //Load sound clips at start
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Play specified FX
    public void PlaySound(string clip)
    {
        switch(clip)
        {
            default:
                break;
            case "Hurt":
                audioSource.PlayOneShot(sfxList[(int)SFXType.Hurt]);
                break;
            case "Collect":
                audioSource.PlayOneShot(sfxList[(int)SFXType.Collect]);
                break;
            case "Destroy":
                audioSource.PlayOneShot(sfxList[(int)SFXType.Destroy]);
                break;
        }
    }
}
