using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform ballSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball")){
            StartCoroutine(spawnBall(other.gameObject));
        }
    }

    private IEnumerator spawnBall(GameObject ball)
    {
        ball.SetActive(false);
        ball.transform.position = ballSpawnPoint.position;
        yield return new WaitForSeconds(2f);
        ball.SetActive(true);
    }
}
