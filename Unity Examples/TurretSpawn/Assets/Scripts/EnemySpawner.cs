using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private float SpawnCountdown = 5;

    public GameObject Enemy;
    private GameObject player;
    public Text Countdown;
    bool spawned = false;
    SpawnTurret Turret2;
    //  Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawned == false)
        {
            HUD();
            player = GameObject.Find("Turret2(Clone)");
            SpawnCountdown -= Time.deltaTime;
            if (SpawnCountdown <= 0)
            {
                Instantiate(Enemy, new Vector3((player.transform.position.x + 20), player.transform.position.y, player.transform.position.z), Quaternion.Euler(0, 0, 0));
                spawned = true;
                Debug.Log("Success. Enemy Spawned at " + Enemy.transform.position);
            }
        }
    }

    void HUD()
    {
        Countdown.text = "Enemy Spawn In: " + SpawnCountdown.ToString("f1");
    }
}
