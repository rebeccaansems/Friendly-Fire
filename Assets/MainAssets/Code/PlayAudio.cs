using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip[] AudioClips;

    public void Play(int num)
    {
        GameObject audio = new GameObject();
        audio.AddComponent<AudioSource>();

        audio.name = AudioClips[num].name;
        audio.GetComponent<AudioSource>().playOnAwake = false;
        audio.GetComponent<AudioSource>().loop = false;
        audio.GetComponent<AudioSource>().volume = OverallController.instance.sfxVolume;

        audio.GetComponent<AudioSource>().PlayOneShot(AudioClips[num]);

        Destroy(audio, AudioClips[num].length * 2.5f);
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