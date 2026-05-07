using UnityEngine;

public class Agent_Reactions : MonoBehaviour
{
    public Agent_Stats stats;

    public void ApplyAction(int action)
    {
        switch (action)
        {
            case 0: //negativ
                stats.ChangeMood(-10);
                stats.ChangeDopamin(-10);
                break;

            case 1://neutral
                stats.ChangeDopamin(+5);
                break;

            case 2://positiv
                stats.ChangeMood(+10);
                stats.ChangeAddiction(+5);
                stats.ChangeDopamin(+20);
                break;

        }
    }
}
