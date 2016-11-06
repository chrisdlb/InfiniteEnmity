using UnityEngine;
using System.Collections;

public class ViewPort : MonoBehaviour {

    public Transform myTarget;
	
	// Update is called once per frame
	void LateUpdate () {
	    if(myTarget != null){
            Vector3 targPos = myTarget.position;
            targPos.z = transform.position.z;
            transform.position = targPos;
        }
	}
}
