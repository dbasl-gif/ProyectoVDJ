
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public int numberOfBalls = 200;
    public Vector3 poolSize = new Vector3(18, 3, 18);

    void Start()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            float x = Random.Range(-poolSize.x / 2f, poolSize.x / 2f);
            float y = Random.Range(0.5f, poolSize.y);
            float z = Random.Range(-poolSize.z / 2f, poolSize.z / 2f);

            Vector3 position = transform.position
                + new Vector3(x, y, z);

            Instantiate(ballPrefab, position, Random.rotation);
        }
    }
}
