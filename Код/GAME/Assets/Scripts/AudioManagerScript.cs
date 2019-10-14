using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip playerHit, monsterHit, bearStanding, bearTeleporting;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHit = Resources.Load<AudioClip>("playerHit");
        monsterHit = Resources.Load<AudioClip>("monsterHit");
        bearStanding = Resources.Load<AudioClip>("bearStanding");
        bearTeleporting = Resources.Load<AudioClip>("bearTeleportation");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHit);
                break;
            case "monsterHit":
                audioSrc.PlayOneShot(monsterHit);
                break;
            case "bearStanding":
                audioSrc.PlayOneShot(bearStanding);
                break;
            case "bearTeleporting":
                audioSrc.PlayOneShot(bearTeleporting);
                break;
        }
    }
}
