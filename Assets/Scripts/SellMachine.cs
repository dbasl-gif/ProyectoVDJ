
using UnityEngine;

public class SellMachine : MonoBehaviour
{
    public void UseMachine(BallCollector player)
    {
        if (player == null)
        {
            return;
        }

        player.SellHeldBall();
    }
}
