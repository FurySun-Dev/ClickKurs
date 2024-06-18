using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLock : MonoBehaviour
{
    [SerializeField] GameObject AchP;
    [SerializeField] GameObject ShoplP;
    [SerializeField] GameObject LockP;

    void Update()
    {
        
    }
    public void AchivPan()
    {
        if (AchP.activeSelf)
        {
            AchP.SetActive(false);
        }
        else
        {
            LockP.SetActive(false);
            ShoplP.SetActive(false);
            AchP.SetActive(true);
        }
    }
    public void ShopPan()
    {
        if (ShoplP.activeSelf)
        {
            ShoplP.SetActive(false);
        }
        else
        {
            AchP.SetActive(false);
            LockP.SetActive(false);
            ShoplP.SetActive(true);
        }
    }
    public void LockPan()
    {
        if (LockP.activeSelf)
        {
            LockP.SetActive(false);
        }
        else
        {
            AchP.SetActive(false);
            ShoplP.SetActive(false);
            LockP.SetActive(true);
        }
    }
}
