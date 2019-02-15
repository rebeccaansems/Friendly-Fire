using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip[] AudioClips;

    public void Play(int num)
    {
        GameObject audio = new GameObject();
        audio.AddComponent<AudioSource>();

        audio.name = AudioClips[num].name;
        audio.GetComponent<AudioSource>().clip = AudioClips[num];
        audio.GetComponent<AudioSource>().playOnAwake = false;
        audio.GetComponent<AudioSource>().loop = false;
        audio.GetComponent<AudioSource>().volume = OverallController.instance.volume;

        audio.GetComponent<AudioSource>().Play();

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