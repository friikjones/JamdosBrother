using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControlScript : MonoBehaviour {

    private GameManagerScript GameManagerScript;

    public int sceneItsIn;

	// Use this for initialization
	void Start () {
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WakeUp ()
    {
        if (sceneItsIn == GameManagerScript.SceneNumber)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
