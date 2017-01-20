using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spookman : MonoBehaviour
{
    public Vector3 playerPos;

    float speed = 4;
    float maxSpeed = 8;

    int hp = 100;

    List<Vector3> spawnPoints = new List<Vector3>();

    void Start()
    {
        Transform points = GameObject.Find("spawnpoints").transform;
        foreach (Transform t in points)
        {
            if (t != points)
            {
                spawnPoints.Add(t.position);
            }
        }
    }

	void FixedUpdate ()
    {
		if (hp <= 0)
            respawn();

        if (GetComponent<Rigidbody>().velocity.y < 1 && Mathf.Abs((playerPos - transform.position).magnitude) > 3)
            GetComponent<Rigidbody>().velocity = (playerPos - transform.position).normalized * speed;
        transform.LookAt(new Vector3(playerPos.x, transform.position.y, playerPos.z));

	}

    public void gaze()
    {
        hp -= 5;
    }

    void respawn()
    {
        speed += 0.5f;
        if (speed > maxSpeed)
        {
            GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/spookyman"),
                spawnPoints[(int)Random.Range(0, (float)spawnPoints.Count - 0.1f)],
                Quaternion.identity);
            speed = 3;
        }
        
        hp = 100;
        
        transform.position = spawnPoints[(int)Random.Range(0, (float)spawnPoints.Count - 0.1f)];
    }
}
