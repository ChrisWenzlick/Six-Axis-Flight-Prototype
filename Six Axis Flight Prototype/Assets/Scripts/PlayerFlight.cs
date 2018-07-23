using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlight : MonoBehaviour {

    public float playerSpeed = 90f;
    public float playerYawSpeed = 5f;
    public float playerPitchSpeed = 5f;
    public float playerRollSpeed = 5f;

	// Use this for initialization
	void Start () {
        Debug.Log("Player flight script added to " + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * playerSpeed;

        transform.Rotate(Input.GetAxis("Vertical") * playerPitchSpeed, 0.0f, -Input.GetAxis("Horizontal") * playerRollSpeed);

        float terrainHeightAtLocation = Terrain.activeTerrain.SampleHeight(transform.position);
        if(terrainHeightAtLocation > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,
                                             terrainHeightAtLocation,
                                             transform.position.z);
        }
	}
}
