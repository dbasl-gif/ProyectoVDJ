
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TooltipHabilidad : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Panel de informacion")]
    public GameObject tooltipPanel;
    public TMP_Text tooltipText;

    [Header("Descripcion")]
    [TextArea(2, 5)]
    public string descripcion;

    void Start()
    {
        tooltipPanel.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipText.text = descripcion;
        tooltipPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPanel.SetActive(false);
    }
}
