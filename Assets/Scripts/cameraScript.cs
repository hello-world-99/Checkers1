using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
 
    public float width ;
    public float height;
    public float diff;
    public float startwidth = Screen.width;
    public float startheight = Screen.height;
    public GameObject Score1;
    public GameObject Score2;
    public GameObject Interface;
    public void Update()
    {
        startwidth = Screen.width;
        startheight = Screen.height;
        diff = startwidth / startheight;
        float currentAspect = (float)Screen.width / (float)Screen.height;
        if (startwidth / startheight >=1.7 && startwidth / startheight <= 1.8)
        {
            Camera.main.orthographicSize = currentAspect * 2.25f;
            Score1.GetComponent<RectTransform>().localPosition = new Vector2(-0.7f, 0.32f);
            Score2.GetComponent<RectTransform>().localPosition = new Vector2(0.7f, 0.32f);
            Interface.GetComponent<RectTransform>().localPosition = new Vector2(0, 0.32f);
        }
        if (startwidth / startheight >= 1.99 && startwidth / startheight <= 2.01)
        {
            Camera.main.orthographicSize = currentAspect * 2;
            Score1.GetComponent<RectTransform>().localPosition = new Vector2(-0.7f, 0.32f);
            Score2.GetComponent<RectTransform>().localPosition = new Vector2(0.7f, 0.32f);
            Interface.GetComponent<RectTransform>().localPosition = new Vector2(0, 0.32f);
        }
        if (startwidth / startheight >= 0.49 && startwidth / startheight <=0.51)
        {
            Camera.main.orthographicSize = currentAspect * 16;
            Score1.GetComponent<RectTransform>().localPosition = new Vector2(-0.325f, -0.725f);
            Score2.GetComponent<RectTransform>().localPosition = new Vector2(0.325f, -0.725f);
            Interface.GetComponent<RectTransform>().localPosition = new Vector2(0, -0.73f);

            //Interface.GetComponent<SpriteRenderer>().size = new Vector2(2, -0.38f);
        }
        if (startwidth / startheight >= 0.56 && startwidth / startheight <= 0.57)
        {
            Camera.main.orthographicSize = currentAspect * 12.65f;
            Score1.GetComponent<RectTransform>().localPosition = new Vector2(-0.325f, -0.725f);
            Score2.GetComponent<RectTransform>().localPosition = new Vector2(0.325f, -0.725f);
            Interface.GetComponent<RectTransform>().localPosition = new Vector2(0, -0.73f);

            //Interface.GetComponent<SpriteRenderer>().size = new Vector2(2, -0.38f);
            //Score1.transform.position = new Vector2(-0.325f, -0.725f);
            //Score2.transform.position = new Vector2(0.325f, -0.725f);
        }
    }
}