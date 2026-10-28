
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int value = 1;
    public int level = 1;

    public bool Upgrade()
    {
        // Si ya está al nivel 5, no se mejora ni se destruye
        if (level >= 5)
        {
            return true;
        }

        float chance = 0f;

        if (level == 1)
        {
            chance = 80f;
        }
        else if (level == 2)
        {
            chance = 60f;
        }
        else if (level == 3)
        {
            chance = 40f;
        }
        else if (level == 4)
        {
            chance = 25f;
        }

        float roll = Random.Range(0f, 100f);

        if (roll < chance)
        {
            level++;

            if (level == 2)
            {
                value = 5;
            }
            else if (level == 3)
            {
                value = 10;
            }
            else if (level == 4)
            {
                value = 15;
            }
            else if (level == 5)
            {
                value = 50;
            }

            Renderer ballRenderer = GetComponent<Renderer>();

            if (ballRenderer != null)
            {
                if (level == 2)
                    ballRenderer.material.color = Color.yellow;
                else if (level == 3)
                    ballRenderer.material.color = Color.green;
                else if (level == 4)
                    ballRenderer.material.color = Color.blue;
                else if (level == 5)
                    ballRenderer.material.color = new Color(1f, 0.5f, 0f);
            }

            return true;
        }

        return false;
    }
}
