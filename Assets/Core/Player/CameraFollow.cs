using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject Target;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = Vector3.MoveTowards(this.transform.position, this.Target.transform.position, this.speed);

        movementVector.z = -10f;
        movementVector.y = 2.72f;

        this.transform.position = movementVector;
    }
}
