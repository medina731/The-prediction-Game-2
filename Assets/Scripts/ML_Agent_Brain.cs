using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class ML_Agent_Brain : Agent
{
    public Agent_Behaviour behaviour;

    // her gemmer jeg de tidligere stats, så man kan måle ændringerne og give reward.
    float prevMood;
    float prevAddiction;
    float prevDopamine;

    public override void Initialize()
    {
        // gemmer startværdierne for stats
        prevMood = behaviour.stats.mood;
        prevAddiction = behaviour.stats.addiction;
        prevDopamine = behaviour.stats.dopamine;
    }


    public override void CollectObservations(VectorSensor sensor)
    {
        // obersvationer bliver hentet fra Agent_behavior ( post features + stats)
        float[] obs = behaviour.GetObservations();

        //tilføjer hver observation til ml-agenten input
        foreach (float o in obs)
            sensor.AddObservation(o);
    }

    // Ml-agenten har valgt en action og her skal vi reagere på den
    public override void OnActionReceived(ActionBuffers actions)
    {
        //Action 0 , Neutral 1, Dislike 2 
        int action = actions.DiscreteActions[0];
        //sender action videre til Agent_Reactions via Agent_behaviour
        behaviour.ApplyAction(action);

        //henter de nye stats efter agentens handling
        float mood = behaviour.stats.mood;
        float addiction = behaviour.stats.addiction;
        float dopamine = behaviour.stats.dopamine;

        //reward baseret på ændringer i stats
        float reward = 0f;
        reward += (mood - prevMood) / 100f; // her stiger mood = godt
        reward -= (addiction - prevAddiction) / 100f; //Addiction stiger = dårligt
        reward += (dopamine - prevDopamine) / 100f; //Dopamin stiger = godt

        //her får ML-agenten reward
        AddReward(reward);

        // her bliver tidligere stats opdateret til næste frame
        prevMood = mood;
        prevAddiction = addiction;
        prevDopamine = dopamine;
    }

    //her bruges til at teste agenten manuelt uden træning
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var a = actionsOut.DiscreteActions;
        //Default action > Neutral
        a[0] = 0;
        // tryk 1 neutral, 2 like, 3 dislike
        if (Input.GetKey(KeyCode.Alpha1)) a[0] = 0;
        if (Input.GetKey(KeyCode.Alpha2)) a[0] = 1;
        if (Input.GetKey(KeyCode.Alpha3)) a[0] = 2;
    }
}
