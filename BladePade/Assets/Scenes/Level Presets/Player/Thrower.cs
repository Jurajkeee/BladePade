using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
		
	}

    public void Throw(Vector3 aimCords)
    {
        Vector2 direction = (Vector2)(aimCords - transform.position);
        direction.Normalize();
        //Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
        float angle = direction. //Vector3.Angle(direction, transform.right);

        Debug.Log("Angle: " + angle);
    }

}
