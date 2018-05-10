using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunWakeup : MonoBehaviour
{

    private ObjectControlScript ObjectControlScript;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in this.transform)
        {
            ObjectControlScript = child.transform.GetComponent<ObjectControlScript>();
            ObjectControlScript.WakeUp();
        }
    }
}

