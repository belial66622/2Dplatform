using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButton : MonoBehaviour
{
    [SerializeField]
    GameObject[] Button;
    // Start is called before the first frame update
    [SerializeField]
    bool OnaAndroid;
    void Start()
    {
        if (!OnaAndroid) return;
            foreach (GameObject obj in Button)
            {
                obj.SetActive(true);
            }
    }


}
