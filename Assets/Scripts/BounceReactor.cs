using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceReactor : AudioReaktor
{

    public float Intensity;
    public Transform Floor;
    public float DistanceFromFloor;

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void React()
    {
        if (Mathf.Abs(Floor.position.y - transform.position.y) < DistanceFromFloor)
        {
            rigidBody.velocity += new Vector3(Intensity * (Random.value - 0.5f), Intensity, Intensity * (Random.value - 0.5f));
        }
    }

    public override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Floor.position + new Vector3(0.0f, DistanceFromFloor, 0.0f), new Vector3(7f, 0.1f, 7f));
    }
}
