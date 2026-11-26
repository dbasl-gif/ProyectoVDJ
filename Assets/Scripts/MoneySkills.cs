
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneySkills : MonoBehaviour
{
    [Header("Jugador")]
    public BallCollector player;

    [Header("Botones de habilidades")]
    public Button skill1Button;
    public Button skill2Button;
    public Button skill3Button;
    public Button skill4Button;

    [Header("Texto de informacion")]
    public TMP_Text messageText;

    [Header("Precios")]
    public int skill1Price = 100;
    public int skill2Price = 250;
    public int skill3Price = 500;
    public int skill4Price = 1000;

    private bool skill1Purchased = false;
    private bool skill2Purchased = false;
    private bool skill3Purchased = false;
    private bool skill4Purchased = false;

    private Coroutine messageCoroutine;

    void Start()
    {
        if (messageText != null)
            messageText.gameObject.SetActive(false);

        UpdateButtons();
    }

    public void BuySkill1()
    {
        BuySkill(1);
    }

    public void BuySkill2()
    {
        BuySkill(2);
    }

    public void BuySkill3()
    {
        BuySkill(3);
    }

    public void BuySkill4()
    {
        BuySkill(4);
    }

    void BuySkill(int skill)
    {
        if (player == null)
        {
            ShowMessage("Error: jugador no asignado");
            return;
        }

        int price = 0;
        int multiplier = 1;

        switch (skill)
        {
            case 1:
                if (skill1Purchased) return;
                price = skill1Price;
                multiplier = 3;
                break;

            case 2:
                if (!skill1Purchased || skill2Purchased) return;
                price = skill2Price;
                multiplier = 5;
                break;

            case 3:
                if (!skill2Purchased || skill3Purchased) return;
                price = skill3Price;
                multiplier = 7;
                break;

            case 4:
                if (!skill3Purchased || skill4Purchased) return;
                price = skill4Price;
                multiplier = 10;
                break;
        }

        if (player.money < price)
        {
            ShowMessage("No tienes suficiente dinero");
            return;
        }

        player.money -= price;
        player.sellMultiplier = multiplier;

        if (player.moneyText != null)
        {
            player.moneyText.text = player.money + "$";
        }

        switch (skill)
        {
            case 1:
                skill1Purchased = true;
                break;

            case 2:
                skill2Purchased = true;
                break;

            case 3:
                skill3Purchased = true;
                break;

            case 4:
                skill4Purchased = true;
                break;
        }

        ShowMessage("¡Habilidad comprada!");

        UpdateButtons();
    }

    void ShowMessage(string message)
    {
        if (messageText == null)
        {
            Debug.LogWarning("No hay ningun texto asignado en MoneySkills");
            return;
        }

        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }

        messageText.gameObject.SetActive(true);
        messageText.enabled = true;
        messageText.text = message;
        messageText.color = Color.white;

        messageText.transform.SetAsLastSibling();

        messageCoroutine = StartCoroutine(HideMessage());
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(2f);

        messageText.gameObject.SetActive(false);
        messageCoroutine = null;
    }

    void UpdateButtons()
    {
        if (skill1Button != null)
            skill1Button.interactable = !skill1Purchased;

        if (skill2Button != null)
            skill2Button.interactable = skill1Purchased && !skill2Purchased;

        if (skill3Button != null)
            skill3Button.interactable = skill2Purchased && !skill3Purchased;

        if (skill4Button != null)
            skill4Button.interactable = skill3Purchased && !skill4Purchased;
    }
}
