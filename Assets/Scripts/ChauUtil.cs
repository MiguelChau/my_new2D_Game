using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public static class ChauUtil 
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Chau/Teste")]
    public static void Test()
    {
        Debug.Log("Test");
    } 
    
    [UnityEditor.MenuItem("Chau/GameObject %#c")]
    public static void CreateGameObject()
    {
        GameObject obj = new GameObject("GameObject");
        
        Debug.Log("GameObject created");
    }
#endif

    public static void Scale(this Transform t, float size = 1f) 
    {
        t.localScale = Vector3.one * size;
    } 
    
    public static void Scale(this GameObject t, float size = 1f) 
    {
        t.transform.localScale = Vector3.one * size;
    }

#region Random Stuff
    public static T GetRandom<T>(this List<T> list)  
    {
        return list[Random.Range(0, list.Count)];
    }
    
    public static T GetRandom<T>(this T[] array)
    {
        if (array.Length == 0)
            return default(T);

        return array[Random.Range(0, array.Length)];   
    }

    public static T GetRandomButNotSame<T>(this List<T> list, T unique)
    {
        if (list.Count == 1)
            return unique;

        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }
    

#endregion
}
