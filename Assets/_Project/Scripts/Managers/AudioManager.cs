using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootSFX;
    [SerializeField] [Range(0, 1)] float shootSFXVolume = 0.5f; // 0 = 0%, 1 = 100% of the volume

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageSFX;
    [SerializeField][Range(0, 1)] float damageSFXVolume;

    public void PlayShootingSFX()
    {
        if (shootSFX != null)
        {
            PlayAudioClip(shootSFX, shootSFXVolume);
        }
    }

    public void PlayDamageSFX()
    {
        if(damageSFX != null)
        {
            PlayAudioClip(damageSFX, damageSFXVolume);
        }
    }

    void PlayAudioClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);

        }
    }
}
