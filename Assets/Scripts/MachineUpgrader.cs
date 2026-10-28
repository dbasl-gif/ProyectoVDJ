
using UnityEngine;

public class UpgradeMachine : MonoBehaviour
{
    public void UseMachine(BallCollector player)
    {
        player.UpgradeHeldBall();
    }
}
