using UnityEngine;

public class Agent_Algorithm : MonoBehaviour
{
    public float[] BuildObservations(float[] postFeatures, Agent_Stats stats)
    {
        float[] obs = new float[postFeatures.Length + 3];

        // Post features
        for (int i = 0; i < postFeatures.Length; i++)
            obs[i] = postFeatures[i];

        // Stats normaliseret 0-1
        obs[postFeatures.Length + 0] = stats.mood / 100f;
        obs[postFeatures.Length + 1] = stats.addiction / 100f;
        obs[postFeatures.Length + 2] = stats.dopamine / 100f;

        return obs;
    }
}