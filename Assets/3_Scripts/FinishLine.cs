using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect; // FinishEffect 파티클 시스템 참조

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("완주했습니다");

            if (finishEffect != null)
            {
                finishEffect.Play(); // 파티클 시스템 재생
            }

            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }


    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
