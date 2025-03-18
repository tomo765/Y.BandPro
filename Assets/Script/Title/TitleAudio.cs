using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAudio : MonoBehaviour
{
    public GameObject TitleSound;
    public Slider VolumeSlider;
    public static float SliderValue = 1.0f;

    void Start()
    {
        // ƒV[ƒ““à‚©‚çSlider‚ğ’T‚µ‚Äæ“¾
        VolumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        // •Û‘¶‚³‚ê‚½‰¹—Ê‚ğ”½‰f
        SliderValue = VolumeSlider.value;
        TitleSound.GetComponent<AudioSource>().volume = SliderValue;

    }

    void Update()
    {
        // •Û‘¶‚³‚ê‚½‰¹—Ê‚ğ”½‰f
        SliderValue = VolumeSlider.value;
        TitleSound.GetComponent<AudioSource>().volume = SliderValue;
    }
}
