using UnityEngine;
using System.Collections;

public class DoorFlipPlatform : MonoBehaviour
{
    public float flipDuration = 0.5f;     // Time it takes to flip
    public float flipInterval = 3f;        // Time between flips
    public float flipAngle = 90f;          // How much it swings (90 degrees)
    private Quaternion originalRotation;
    private Quaternion flippedRotation;
    private bool isFlipped = false;

    private void Start()
    {
        originalRotation = transform.rotation;
        flippedRotation = Quaternion.Euler(0, 0, flipAngle) * originalRotation; // Swing around Z-axis
        StartCoroutine(FlipRoutine());
    }

    private IEnumerator FlipRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(flipInterval);

            if (!isFlipped)
                yield return StartCoroutine(Flip(originalRotation, flippedRotation));
            else
                yield return StartCoroutine(Flip(flippedRotation, originalRotation));

            isFlipped = !isFlipped;
        }
    }

    private IEnumerator Flip(Quaternion fromRotation, Quaternion toRotation)
    {
        float timer = 0f;
        while (timer < flipDuration)
        {
            transform.rotation = Quaternion.Slerp(fromRotation, toRotation, timer / flipDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.rotation = toRotation;
    }
}

