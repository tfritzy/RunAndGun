using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.player.transform.position;
        position.z = -10;
        this.transform.position = position;
    }
}
