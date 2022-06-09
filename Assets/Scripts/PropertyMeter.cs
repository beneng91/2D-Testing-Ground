using UnityEngine;
using UnityEngine.UI;

// Renderer - Display graphic in Unity 
public class PropertyMeter : MonoBehaviour
{

    // Variables 
    public Slider meterSlider; //Slider is a known type to Unity 

    public void UpdateMeter(float value)
    {
        meterSlider.value = value;
    }
}