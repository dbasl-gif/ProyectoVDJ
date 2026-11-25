
using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    [Header("Configuracion")]
    public GameObject ballPrefab;
    public int numberOfBalls = 1000;
    public Vector3 poolSize = new Vector3(18, 3, 18);

    [Header("Aparicion de bolas")]
    public float spawnDelay;
    public float separation = 0.6f;
    int spawnedBalls = 0;

    [Header("Colores")]
    public Color[] ballColors;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(spawnDelay * Time.deltaTime);

        if (spawnedBalls < numberOfBalls)
        {
            GameObject ball = Instantiate(
                ballPrefab,
                new Vector3(
                    transform.position.x + Random.Range(0, separation),
                    transform.position.y + Random.Range(0, separation),
                    transform.position.z + Random.Range(0, separation)
                ),
                Quaternion.identity
            );

            Renderer ballRenderer = ball.GetComponentInChildren<Renderer>();

            if (ballRenderer != null && ballColors.Length > 0)
            {
                ballRenderer.material.color =
                    ballColors[Random.Range(0, ballColors.Length)];
            }

            spawnedBalls++;
        }
        else
        {
            Debug.Log("Todas las pelotas han sido generadas");
        }

        Debug.Log("Bolas generadas: " + spawnedBalls);

        StartCoroutine(Start());
    }
}
