using UnityEngine;
using TMPro;
using System.Collections;

public class PointsPopup : MonoBehaviour
{
    public float popupDuration = 1.5f;
    public Vector3 randomOffsetRange = new Vector3(0.5f, 0.5f, 0f); // Adjust the range as needed
    private TextMeshProUGUI popupText;
    private Vector3 randomOffset; // Declare the variable here

    private void Start()
    {
        popupText = GetComponent<TextMeshProUGUI>();
    }

    public void ShowPopup(int points)
    {
        popupText.text = "+ " + points;

        // Generate a random offset within the specified range
        randomOffset = new Vector3(
            Random.Range(-randomOffsetRange.x, randomOffsetRange.x),
            Random.Range(-randomOffsetRange.y, randomOffsetRange.y),
            Random.Range(-randomOffsetRange.z, randomOffsetRange.z)
        );

        // Apply the random offset to the position
        transform.position += randomOffset;

        StartCoroutine(PopupCoroutine());
    }

    private IEnumerator PopupCoroutine()
    {
        popupText.enabled = true;
        yield return new WaitForSeconds(popupDuration);
        popupText.enabled = false;
        transform.position -= randomOffset; // Reset the position after the popup
    }
}
