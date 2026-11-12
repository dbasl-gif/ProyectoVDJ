using UnityEngine;
using UnityEngine.UI;

public class resolutioncontroller : MonoBehaviour
{
    public Button BotonIzq;
    public Button BotonDerech;
    public string[] Resolution;
    public Text Valores;

    public int Indice = 0;

    private void Update()
    {
        Valores.text = Resolution[Indice];
    }

    public void sumarvalor() 
    {

        if(Indice +1 < Resolution.Length) 
        { 
        
         Indice++;
        
        }
       
    
    }

    public void restarrvalor()
    {

        if (Indice > 0)
        {

            Indice--;

        }
      

    }




}
