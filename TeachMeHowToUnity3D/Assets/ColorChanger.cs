using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
    public Color[] colors;
    float nextSwitchTime;
    public float switchDelay = 1f;
    public int index = 0;

    Color nextColor;
    public Vector3 targetPosition;
    public float test = 0f;
    public float nextTest = 10f;
    void Start()
    {
        nextSwitchTime = Time.time + switchDelay;
        if (colors == null)
        {
            colors = new Color[1];
            colors[0] = Color.black;
        }
    }

    void Update()
    {
        test = Mathf.Lerp(test, nextTest, Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        renderer.material.color = Color.Lerp(renderer.material.color, nextColor, Time.deltaTime);

        if (Time.time > nextSwitchTime)
        {
            nextColor = colors[index];
            index++;
            if (index >= colors.Length) index = 0;
            nextSwitchTime += switchDelay;
        }
    }
}
