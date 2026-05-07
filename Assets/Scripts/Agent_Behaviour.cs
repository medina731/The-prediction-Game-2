using UnityEngine;

public class Agent_Behaviour : MonoBehaviour
{
    public Agent_Stats stats;
    public Agent_Reactions reactions;
    public Agent_Algorithm algorithm;

    private float[] currentPostFeatures;

    //kaldes af UI
    public void ReceievePost(float[] postFeatures)
    {
        currentPostFeatures = postFeatures;
    }

    //skal bruges af ML-agenten til at få hentet observationer
    public float[] GetObservations()
    {
        return algorithm.BuildObservations(currentPostFeatures, stats);
    }

    public void ApplyAction(int action)
    {
        reactions.ApplyAction(action);
    }

}