using System.Collections.Generic;
using UnityEngine;

public class StartHidden : MonoBehaviour
{
    public List<GameObject> toHide;

    void Start()
    {
        foreach (GameObject go in toHide)
        {
            if (go != null)
                go.SetActive(false);
        }
    }
}
