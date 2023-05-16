using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        JUMP,
        RUN
    }

    public List<VFXManagerSetup> vfxSetup;

    public void PlayByTypeVFX(VFXType vFXType, Vector3 position)
    {
        foreach (var a in vfxSetup)
        {
            if(a.vFXType == vFXType)
            {
                var item = Instantiate(a.prefab);
                item.transform.position = position;
                Destroy(item.gameObject, 1f);
                break;
            }
        }
    }
}


[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vFXType;
    public GameObject prefab;
}
