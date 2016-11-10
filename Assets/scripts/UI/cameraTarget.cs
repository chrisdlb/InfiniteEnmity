using UnityEngine;
using System.Collections;

public class cameraTarget : MonoBehaviour {

    //camera & minimap target
    public Transform target;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targPos = target.position;
            targPos.z = transform.position.z;
            transform.position = targPos;
        }
    }
}
