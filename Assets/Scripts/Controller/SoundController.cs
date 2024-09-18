using UnityEngine;

namespace Controller
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
    
        public void PlaySfx(AudioClip clip)
        {
            source.PlayOneShot(clip);
        }

        public void PlayBgm(AudioClip clip)
        {
            source.Stop();
            source.Play();
        }
    }
}
