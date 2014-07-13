using UnityEngine;
using System.Collections;

public class PariclePos : MonoBehaviour {

	public string fingerName ;
	public float velocity = 50.0f ;
	public float flyTime = 1.0f ;

	private bool flying = false ;
	private float elaspedTime = 0.0f ;
	private Vector3 parmDir ;

	// Use this for initialization
	void Start () {
		//gameObject.SetActive(false) ;
	}
	
	// Update is called once per frame
	void Update () {
		if ( !flying ){
			GameObject finger = GameObject.Find( fingerName );
			if ( finger ){
				//gameObject.SetActive(true) ;
				Vector3 pos = new Vector3( finger.transform.position.x, finger.transform.position.y+0.3f, finger.transform.position.z);
				transform.position = pos ;
			}
		}else{
			Vector3 move = new Vector3( parmDir.x * velocity * Time.deltaTime,
			                            parmDir.y * velocity * Time.deltaTime,
			                            parmDir.z * velocity * Time.deltaTime );
			Vector3 pos = new Vector3( transform.position.x + move.x ,
			                          transform.position.y + move.y ,
			                          transform.position.z + move.z );
			transform.position = pos ;
			elaspedTime += Time.deltaTime ;
			if ( elaspedTime > flyTime ){
				flying = false ;
			}
		}

		if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A) )
		{
			flying = true ;
			elaspedTime = 0 ;
			GameObject parm = GameObject.Find( "rightHand" );

			if ( parm ){
				parmDir = parm.transform.rotation * Vector3.forward ;
				parmDir.Normalize();
			}

		}
	}

	public void fire(){
		if ( flying ){
			return ;
		}
		flying = true ;
		elaspedTime = 0 ;
		GameObject parm = GameObject.Find( "rightHand" );
		
		if ( parm ){
			parmDir = parm.transform.rotation * Vector3.forward ;
			parmDir.Normalize();
		}
	}

}
