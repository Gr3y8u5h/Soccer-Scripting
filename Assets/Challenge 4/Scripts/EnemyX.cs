using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    float speed = 100;
    Rigidbody enemyRb;
    GameObject playerGoal;
    SpawnManagerX spawnManagerScript;
    float waveCount;
    float updatedSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        spawnManagerScript = gameObject.AddComponent<SpawnManagerX>();
        
    }

    // Update is called once per frame
    void Update()
    {
        waveCount = spawnManagerScript.enemyCount * 25;
        updatedSpeed = speed + waveCount;
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * updatedSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
