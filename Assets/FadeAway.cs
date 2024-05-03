using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeAway : MonoBehaviour
{
    public float fadeTime;
    public float alphaValue;
    public float fadeAwayPerSecond;
    private TextMeshProUGUI fadeAwayText;

    // Start is called before the first frame update
    void Start()
    {
        fadeAwayText = GetComponent<TextMeshProUGUI>();
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = fadeAwayText.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeTime > 0)
        {
            alphaValue -= fadeAwayPerSecond * Time.deltaTime;
            fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, alphaValue);
            fadeTime -= Time.deltaTime;
        }
    }
}
