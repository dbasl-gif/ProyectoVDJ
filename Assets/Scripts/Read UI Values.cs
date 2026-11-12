using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ReadUIValues : MonoBehaviour
{
    public Text textSlider;
    public Slider miSlider;

    public void OnSliderChanged()
    {
        textSlider.text = (miSlider.value*100).ToString("F0") + "%"; 

    }


}
    
