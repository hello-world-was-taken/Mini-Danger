using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerPosition;
    private float cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = 8;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((playerPosition.position.x + cameraOffset), transform.position.y, (playerPosition.position.z - 1));   
    }
}
