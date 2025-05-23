using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect; // FinishEffect ��ƼŬ �ý��� ����

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�����߽��ϴ�");

            if (finishEffect != null)
            {
                finishEffect.Play(); // ��ƼŬ �ý��� ���
            }

            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }


    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
