using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtFollow : MonoBehaviour
{
    public GameObject player;
    public new ParticleSystem particleSystem;
    PlayerControllerX playerControllerScript;
    public bool isTurbo;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>(); 
    }

    // Update is called once per frame
    void Update()
    {
        isTurbo = playerControllerScript.turboBoost;

        transform.position = new Vector3(player.transform.position.x, -0.75f,player.transform.position.z);
        // float verticalInput = Input.GetAxis("Vertical");
        if (/*Input.GetKey(KeyCode.Space)*/ isTurbo)
        {
            Debug.Log("Can Play Particle System");
            particleSystem.Play();
        } 
        /*else
        {
            particleSystem.Stop();
        }*/
            
    }
}
