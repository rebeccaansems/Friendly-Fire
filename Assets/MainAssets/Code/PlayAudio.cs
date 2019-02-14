using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour
{
    public AudioClip[] AudioClips;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void Play(int num)
    {
        audioSource.volume = OverallController.instance.volume;
        audioSource.PlayOneShot(AudioClips[num]);
    }

    public void Play()
    {
        Play(0);
    }

    public void PlayRandom()
    {
        Play(Random.Range(0, AudioClips.Length));
    }

    public void PlayRandom(int min, int max)
    {
        Play(Random.Range(min, max));
    }

    public void Stop()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

}