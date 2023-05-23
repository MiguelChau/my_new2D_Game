using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayAudioClips : MonoBehaviour
{
    public List<AudioClip> audioClipsList;
    public List<AudioSource> audioSourceList;

    private int _index = 0;

    public void PlayClips()
    {
        if (_index >= audioSourceList.Count) _index = 0;
        var audioSource = audioSourceList[_index];

        audioSource.clip = audioClipsList[Random.Range(0, audioClipsList.Count)];
        audioSource.Play();

        _index++;
    }
}
