using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that switches the color of an object to a random color.
/// Does not produce very pretty colors, but if you want completely
/// random colors they wont be.
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
public class ColorRandomizer : MonoBehaviour
{

    //How fast do we change
    public float changeTime;
    //How long do we wait before changing again
    public float waitTime;

    private Color color;
    private MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        StartCoroutine("ChangeColor");
    }

    IEnumerator ChangeColor()
    {
        //Save our initial color
        color = mr.material.color;

        //Get a random color to change to
        float r = Random.Range(0, 1.0f);
        float g = Random.Range(0, 1.0f);
        float b = Random.Range(0, 1.0f);

        Color newColor = new Color(r, g, b);

        float t = 0;

        while (t < 1)
        {
            //Set our color
            mr.material.color = Color.Lerp(color, newColor, t);
            //Update our t according to how much time has passed
            t += Time.deltaTime / changeTime;
            yield return null;
        }

        //If we have a waittime, wait and then start over
        yield return new WaitForSeconds(waitTime);
        StartCoroutine("ChangeColor");
    }

}
