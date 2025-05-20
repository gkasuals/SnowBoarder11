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
        // �÷��̾� ����
        player = GameObject.CreatePrimitive(PrimitiveType.Cube);
        player.transform.position = new Vector3(0, -3, 0);
        player.transform.localScale = new Vector3(1, 1, 1);
        player.GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update()
    {
        if (gameOver) return;

        // �÷��̾� �¿� �̵�
        float move = Input.GetAxis("Horizontal") * 7f * Time.deltaTime;
        player.transform.Translate(move, 0, 0);

        // ȭ�� ������ �� ������ ����
        float clampedX = Mathf.Clamp(player.transform.position.x, -4.5f, 4.5f);
        player.transform.position = new Vector3(clampedX, player.transform.position.y, 0);

        // ��ֹ� ����
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

        // ��ֹ� �̵� �� �浹 üũ
        for (int i = obstacles.Count - 1; i >= 0; i--)
        {
            obstacles[i].transform.Translate(0, -5f * Time.deltaTime, 0);

            // �浹 üũ
            if (Vector3.Distance(obstacles[i].transform.position, player.transform.position) < 1f)
            {
                gameOver = true;
                Debug.Log("Game Over! Score: " + score);
            }

            // ȭ�� �Ʒ��� ������ ���� �� ���� ����
            if (obstacles[i].transform.position.y < -6)
            {
                Destroy(obstacles[i]);
                obstacles.RemoveAt(i);
                score++;
            }
        }
    }
}
