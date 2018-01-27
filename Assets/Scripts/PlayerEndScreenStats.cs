using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerEndScreenStats {

    public float FiredShots{ get; set; }
    public float LandedShots { get; set; }
    public float JunkPercentage { get; set; }
    public float HealthyPercentage { get; set; }

    public PlayerEndScreenStats(float firedShots, float landedShots, float junkPercentage, float healthyPercentage)
    {
        FiredShots = firedShots;
        LandedShots = landedShots;
        JunkPercentage = junkPercentage;
        HealthyPercentage = healthyPercentage;
    }
}
