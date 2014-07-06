using UnityEngine;
using System.Collections;

public class GetVolume : MonoBehaviour {

	public GameObject Thumb ;
	public GameObject Index ;
	public GameObject Middle ;
	public GameObject Ring ;
	public GameObject Pinky ;
	public float loudnessFire = 50.0f ;

	public GameObject audioInputObject;
	MicrophoneInput micIn;
	// Use this for initialization
	void Start () {
		audioInputObject = GameObject.Find("AudioInput");
		micIn = (MicrophoneInput) audioInputObject.GetComponent("MicrophoneInput");
	}
	
	// Update is called once per frame
	void Update () {
		float loudness = micIn.loudness;

		Vector3 scale = new Vector3(1.0f,1.0f,1.0f);
		scale.y = loudness ;
		transform.localScale = scale ;
		// Debug.Log( loudness ) ;

		if ( loudness > loudnessFire ){
			PariclePos ppos = Thumb.GetComponent<PariclePos>();
			ppos.fire();

			ppos = Index.GetComponent<PariclePos>();
			ppos.fire();

			ppos = Middle.GetComponent<PariclePos>();
			ppos.fire();

			ppos = Ring.GetComponent<PariclePos>();
			ppos.fire();

			ppos = Pinky.GetComponent<PariclePos>();
			ppos.fire();
		}
	}
}
