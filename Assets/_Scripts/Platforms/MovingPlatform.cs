using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public float speed = 2f;
    public float waitTime = 1f;

    private Transform[] points;
    private int currentPointIndex = 0;
    private bool isWaiting = false;

    void Start()
    {
        // Store points in an array for easy cycling
        points = new Transform[] { pointA, pointB, pointC };
        transform.position = points[0].position; // Start at point A
        currentPointIndex = 1; // Start moving toward pointB
    }

    void Update()
    {
        if (!isWaiting)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, points[currentPointIndex].position) < 0.1f)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentPointIndex = (currentPointIndex + 1) % points.Length; // Loop back to start
        isWaiting = false;
    }

    // Player Stick to Platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}




