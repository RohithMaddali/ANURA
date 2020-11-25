using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpText : MonoBehaviour
{
    //this script is only here to attach a string to a button
    public string myText;

    //wip vars
    public Canvas parentCanvas;
    public GameObject textBox;

    private void Update()
    {
        //wip code
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);

        Vector3 mousePos = parentCanvas.transform.TransformPoint(movePos);

        //Set fake mouse Cursor
        textBox.transform.position = mousePos;

        //Move the Object/Panel
    }

    public void MouseHover()
    {
        textBox.SetActive(true);
    }

    public void MouseLeave()
    {
        textBox.SetActive(false);
    }
}
