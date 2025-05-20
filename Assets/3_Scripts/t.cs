using UnityEngine;
using System.Collections.Generic;

public class t : MonoBehaviour
{
    GameObject player;
    List<GameObject> obstacles = new List<GameObject>();
    float spawnTimer = 0f;
    int score = 0;
    bool gameOver = false;

    void Start()
    {
        // 플레이어 생성
        player = GameObject.CreatePrimitive(PrimitiveType.Cube);
        player.transform.position = new Vector3(0, -3, 0);
        player.transform.localScale = new Vector3(1, 1, 1);
        player.GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update()
    {
        if (gameOver) return;

        // 플레이어 좌우 이동
        float move = Input.GetAxis("Horizontal") * 7f * Time.deltaTime;
        player.transform.Translate(move, 0, 0);

        // 화면 밖으로 못 나가게 제한
        float clampedX = Mathf.Clamp(player.transform.position.x, -4.5f, 4.5f);
        player.transform.position = new Vector3(clampedX, player.transform.position.y, 0);

        // 장애물 생성
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 1f)
        {
            spawnTimer = 0f;
            GameObject obs = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obs.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 6, 0);
            obs.transform.localScale = new Vector3(1, 1, 1);
            obs.GetComponent<Renderer>().material.color = Color.red;
            obstacles.Add(obs);
        }

        // 장애물 이동 및 충돌 체크
        for (int i = obstacles.Count - 1; i >= 0; i--)
        {
            obstacles[i].transform.Translate(0, -5f * Time.deltaTime, 0);

            // 충돌 체크
            if (Vector3.Distance(obstacles[i].transform.position, player.transform.position) < 1f)
            {
                gameOver = true;
                Debug.Log("Game Over! Score: " + score);
            }

            // 화면 아래로 나가면 제거 및 점수 증가
            if (obstacles[i].transform.position.y < -6)
            {
                Destroy(obstacles[i]);
                obstacles.RemoveAt(i);
                score++;
            }
        }
    }
}
