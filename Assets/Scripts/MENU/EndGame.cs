using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class EndGame : MonoBehaviour
{
    public string tagToCompare = "Player";
    public GameObject uiEndGame;
    public AudioSource audioSourceComplete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(tagToCompare))
        {
            CallEndGame();
        }
    }

    private void CallEndGame()
    {
        if (audioSourceComplete != null) audioSourceComplete.Play();
        uiEndGame.SetActive(true);
    }
}
