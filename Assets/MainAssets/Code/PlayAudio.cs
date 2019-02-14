using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour
{
    public AudioClip[] AudioClips;

    public void Play(int num)
    {
        var audio = new GameObject().AddComponent<AudioSource>();
        audio.volume = OverallController.instance.volume;
        Debug.Log(AudioClips[num] + " " + AudioClips[num].length);
        audio.PlayOneShot(AudioClips[num]);
        Destroy(audio, AudioClips[num].length);
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
}