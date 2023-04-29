using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [SerializeField]GameObject spike;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            spike.SetActive(true);
        }
    }
}
