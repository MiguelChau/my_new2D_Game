using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delayOnLoad = 1f;

    public void LoadGameScene()
    {
        StartCoroutine(WaitAndLoadScene());
    }
    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(delayOnLoad);
        SceneManager.LoadScene(1);
    }
}
