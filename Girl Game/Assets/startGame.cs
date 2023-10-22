using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkTextMesh : MonoBehaviour
{
    public TextMesh textMesh;
    public float blinkInterval = 0.5f; // Time interval for blinking in seconds

    private void Start()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        Material textMaterial = textMesh.GetComponent<Renderer>().material;

        while (true) // Infinite loop for continuous blinking
        {
            Color textColor = textMaterial.color;

            // Toggle the alpha channel to control visibility
            textColor.a = Mathf.Approximately(textColor.a, 0f) ? 1f : 0f;
            textMaterial.color = textColor;

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}

