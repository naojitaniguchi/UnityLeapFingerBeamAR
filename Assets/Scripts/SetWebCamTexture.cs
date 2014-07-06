using UnityEngine;
using System.Collections;

public class SetWebCamTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		WebCamTexture webcamTexture = new WebCamTexture();
		renderer.material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
