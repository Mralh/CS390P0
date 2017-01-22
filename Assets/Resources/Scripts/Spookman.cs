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

    void FixedUpdate()
    {
        if (hp <= 0)
            respawn();
        GetComponent<AudioSource>().pitch = speed / 4;

        if (Mathf.Abs((playerPos - transform.position).magnitude) > 15)
            GetComponent<Rigidbody>().velocity = (playerPos - transform.position).normalized * speed;
        else if (Mathf.Abs((playerPos - transform.position).magnitude) > 4)
        {
            GetComponent<Rigidbody>().velocity = (playerPos - transform.position).normalized * 12;
            GetComponent<AudioSource>().pitch = 3;
        }
        else
        {
            GetComponent<AudioSource>().pitch = 0;
        }
        transform.LookAt(new Vector3(playerPos.x, transform.position.y, playerPos.z));
        GetComponent<AudioSource>().volume = 0.6f * GetComponent<AudioSource>().pitch;
    }

    public void gaze()
    {
        if (Mathf.Abs((playerPos - transform.position).magnitude) > 8)
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
