
using System;
using TMPro;
using UnityEngine;

public class BallCollector : MonoBehaviour
{
    public Transform playerCamera;
    public Transform ballHoldPoint;
    public float pickupDistance = 3f;

    public TMP_Text ballsText;
    public TMP_Text moneyText;

    public int money = 0;
    public Ball heldBall;

    void Start()
    {
        UpdateText();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            DropHeldBall();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(
                playerCamera.position,
                playerCamera.forward
            );

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, pickupDistance))
            {
                UpgradeMachine upgradeMachine =
                    hit.collider.GetComponentInParent<UpgradeMachine>();

                SellMachine sellMachine =
                    hit.collider.GetComponentInParent<SellMachine>();

                if (upgradeMachine != null)
                {
                    upgradeMachine.UseMachine(this);
                    return;
                }

                if (sellMachine != null)
                {
                    sellMachine.UseMachine(this);
                    return;
                }

                Ball ball = hit.collider.GetComponentInParent<Ball>();

                if (ball != null && heldBall == null)
                {
                    heldBall = ball;

                    heldBall.transform.SetParent(ballHoldPoint);
                    heldBall.transform.localPosition = Vector3.zero;
                    heldBall.transform.localRotation = Quaternion.identity;

                    Rigidbody ballRb = heldBall.GetComponent<Rigidbody>();

                    if (ballRb != null)
                    {
                        ballRb.isKinematic = true;
                    }

                    Collider ballCollider =
                        heldBall.GetComponent<Collider>();

                    if (ballCollider != null)
                    {
                        ballCollider.enabled = false;
                    }

                    UpdateText();
                }
            }
        }
    }
    
    public void DropHeldBall()
    {
        if (heldBall == null)
        {
            return;
        }

        heldBall.transform.SetParent(null);

        heldBall.transform.position =
            playerCamera.position + playerCamera.forward * 1.5f;

        Rigidbody ballRb = heldBall.GetComponent<Rigidbody>();

        if (ballRb != null)
        {
            ballRb.isKinematic = false;
        }

        Collider ballCollider = heldBall.GetComponent<Collider>();

        if (ballCollider != null)
        {
            ballCollider.enabled = true;
        }

        heldBall = null;

        UpdateText();
    }


    public void UpgradeHeldBall()
    {
        if (heldBall == null)
        {
            return;
        }

        if (heldBall.level >= 5)
        {
            return;
        }

        bool success = heldBall.Upgrade();

        if (!success)
        {
            Destroy(heldBall.gameObject);
            heldBall = null;
        }

        UpdateText();
    }


    public void SellHeldBall()
    {
        if (heldBall == null)
        {
            return;
        }

        money += heldBall.value;

        Destroy(heldBall.gameObject);
        heldBall = null;

        UpdateText();
    }

    void UpdateText()
    {
        if (ballsText != null)
        {
            ballsText.text = heldBall == null
                ? "Bolas: 0"
                : "Bolas: 1 | Valor: " + heldBall.value;
        }

        if (moneyText != null)
        {
            moneyText.text = money + "$";
        }
    }
}
