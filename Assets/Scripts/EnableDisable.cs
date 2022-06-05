using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    public GameObject objectToHide;

    void Update()
    {
        Invoke("HideGameobject", 1);
        Invoke("ShowGameobject", 2);
    }

    void HideGameobject()
    {
        if (objectToHide.activeInHierarchy)
            objectToHide.SetActive(false);
        
    }

    void ShowGameobject()
    {
        if (!objectToHide.activeInHierarchy)
            objectToHide.SetActive(true);
    }
}
