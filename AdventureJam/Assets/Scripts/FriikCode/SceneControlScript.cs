using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControlScript : MonoBehaviour {

    private GameManagerScript GameManagerScript;
    public int thisSceneNumber;

	// Use this for initialization
	void Start () {
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.activeSelf)
        {
            GameManagerScript.SceneNumber = thisSceneNumber;
        }
	}
}
