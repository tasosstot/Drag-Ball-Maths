using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private BallTrigger ballLauncher;

    private void Awake()
    {
        ballLauncher = FindObjectOfType<BallTrigger>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballLauncher.ReturnBall();
        collision.collider.gameObject.SetActive(false);
    }
}
