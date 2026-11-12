using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ReadUIValues : MonoBehaviour
{
    public Text textVolumen;
    public Text textSens;

    public Slider slidervolumen;
    public Slider slidersens;


    public void OnSliderChanged()
    {
        textVolumen.text = (slidervolumen.value*100).ToString("F0") + "%";
        textSens.text = (slidersens.value*100).ToString("F0") + "%";


    }


}
    
