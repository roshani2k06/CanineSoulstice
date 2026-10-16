using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    public float rotateAngle = 90f;
    public float rotateSpeed = 200f;
    public float resetDelay = 2f;

    private Quaternion originalRotation;
    private Quaternion targetRotation;
    private bool isTriggered = false;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isTriggered && collision.gameObject.CompareTag("Player"))
        {
            // Find where the player touched
            Vector3 contactPoint = collision.GetContact(0).point;
            Vector3 localPoint = transform.InverseTransformPoint(contactPoint);

            if (localPoint.x < 0) // Left side
            {
                targetRotation = Quaternion.Euler(0f, 0f, rotateAngle);
            }
            else // Right side
            {
                targetRotation = Quaternion.Euler(0f, 0f, -rotateAngle);
            }

            isTriggered = true;
            StartCoroutine(RotateTrap());
        }
    }

    System.Collections.IEnumerator RotateTrap()
    {
        float time = 0f;
        Quaternion startRot = transform.rotation;

        while (time < 1f)
        {
            time += Time.deltaTime * rotateSpeed / rotateAngle;
            transform.rotation = Quaternion.Lerp(startRot, targetRotation, time);
            yield return null;
        }

        yield return new WaitForSeconds(resetDelay);

        StartCoroutine(ResetTrap());
    }

    System.Collections.IEnumerator ResetTrap()
    {
        float time = 0f;
        Quaternion startRot = transform.rotation;

        while (time < 1f)
        {
            time += Time.deltaTime * rotateSpeed / rotateAngle;
            transform.rotation = Quaternion.Lerp(startRot, originalRotation, time);
            yield return null;
        }

        isTriggered = false;
    }
}


