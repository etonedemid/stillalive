using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ammotext : MonoBehaviour
{
    TextMeshProUGUI text;
    fire fire;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        fire = GameObject.Find("firepoint").GetComponent<fire>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = fire.currentAmmo.ToString() + "/" + fire.maxAmmo.ToString();
        if (fire.currentAmmo == 0)
        {
            text.color = Color.red;
        }
        else
        {
            text.color = colorFromHex("00FFF6");
        }
    }

    public static Color colorFromHex(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }
}
