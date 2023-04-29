using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGreatBallSpaffing : MonoBehaviour
{
    [SerializeField] List<GameObject> ballPrefabs;
    [SerializeField] float ballSpawnHeight = 3f;
    [SerializeField] float ballSpawnDistance = 3f;
    [SerializeField] float ballSpawnForce = 100f;
    [SerializeField] float ballSpawnTorque = 100f;
    [SerializeField] float ballSpawnRate = 0.5f;
    [SerializeField] float ballSpawnMax = 100f;
    [SerializeField] float ballSpawnMaxDelay = 5f;
    [SerializeField] float ballSpawnMinDelay = 0.1f;
    [SerializeField] float ballSpawnDelayDecrease = 0.1f;
    [SerializeField] float ballSpawnMaxForce = 100f;
    [SerializeField] float ballSpawnMaxTorque = 100f;

    float ballSpawnTimer = 0f;

    private void Update()
    {
        if(ballSpawnTimer > 0f)
        {
            ballSpawnTimer -= Time.deltaTime;
        }
        SpawnBall();
    }

    GameObject PickBall()
    {
        return ballPrefabs[Random.Range(0, ballPrefabs.Count)];
    }

    public void SpawnBall()
    {
        if(ballSpawnTimer <= 0f)
        {
            ballSpawnTimer = ballSpawnRate;
            GameObject ball = Instantiate(PickBall(), transform.position + (transform.forward * ballSpawnDistance) + (transform.up * ballSpawnHeight), Quaternion.identity);
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * ballSpawnForce);
            ball.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * ballSpawnTorque);
            ball.GetComponent<Rigidbody>().maxAngularVelocity = Random.Range(0f, ballSpawnMaxTorque);
            ball.GetComponent<Rigidbody>().maxAngularVelocity = Random.Range(0f, ballSpawnMaxForce);
            ballSpawnRate = Mathf.Clamp(ballSpawnRate - ballSpawnDelayDecrease, ballSpawnMinDelay, ballSpawnMaxDelay);
        }
    }
}
