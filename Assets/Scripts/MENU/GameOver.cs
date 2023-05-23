using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class GameOver : MonoBehaviour
{
    public string tagToCompare = "Player";
    public GameObject gameOverScreen;
    public AudioSource audioSourceComplete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToCompare))
        {
            ShowGameOverScreen();
        }
    }

    public void ShowGameOverScreen()
    {
        if (audioSourceComplete != null) audioSourceComplete.Play();
        gameOverScreen.SetActive(true);
        gameObject.SetActive(true);
    }

    public void HideGameOverScreen()
    {
        gameObject.SetActive(false);
    }
}
