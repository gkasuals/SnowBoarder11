using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        
        {if(other.CompareTag("Player"))
            {
                Debug.Log("완주했습니다");
            }
            
        }
    }
}
