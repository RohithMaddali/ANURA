using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpText : MonoBehaviour
{
    //this script is only here to attach a string to a button
    public string myText;

    public Canvas parentCanvas;
    public GameObject textBox;

    private void Update()
    {
        //move textbox code
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);

        Vector3 mousePos = parentCanvas.transform.TransformPoint(movePos);

        //move textbox
        textBox.transform.position = mousePos;
    }

    public void MouseHover()
    {
        //textBox.SetActive(true);
        StartCoroutine(FadeImage(false));
    }

    public void MouseLeave()
    {
        //textBox.SetActive(false);
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= -1; i -= 0.05f)
            {
                // set color with i as alpha
                //textBox.GetComponent<RawImage>().color = new Color(1, 1, 1, i);
                textBox.GetComponent<CanvasGroup>().alpha += i;
                yield return new WaitForSecondsRealtime(0.05f);
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += 0.05f)
            {
                // set color with i as alpha
                //textBox.GetComponent<RawImage>().color = new Color(1, 1, 1, i);
                textBox.GetComponent<CanvasGroup>().alpha += i;
                yield return new WaitForSecondsRealtime(0.05f);
            }
        }
    }
}
