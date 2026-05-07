using JetBrains.Annotations;
using UnityEngine;

public class Agent_Stats : MonoBehaviour
{
    [Header("Agent stats (0-100)")]
    public float mood = 50f; //hvor glad eller negativ agenten er.
    public float addiction = 10f; //hvor afhængig agenten er.
    public float dopamine = 0f; //hvor meget reward/dopamin at agenten føler.



    public void ChangeMood(float amount)
    {
        mood = Mathf.Clamp(mood + amount, 0f, 100f);
    }

    public void ChangeAddiction(float amount)
    {
        addiction = Mathf.Clamp(addiction + amount, 0f, 100f);
    }

    public void ChangeDopamin(float amount)
    {
        dopamine = Mathf.Clamp(dopamine + amount, 0f, 100f);
    }

}
