using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerEndScreenStats {

    public float FiredShots{ get; set; }
    public float LandedShots { get; set; }
    public float JunkPercentage { get; set; }
    public float HealthyPercentage { get; set; }
    public float DietPoints; 
  //  public Diet Diet { get; set; }

    public PlayerEndScreenStats(float firedShots, float landedShots, float junkPercentage, float healthyPercentage, float dietPoints)
    {
        FiredShots = firedShots;
        LandedShots = landedShots;
        JunkPercentage = junkPercentage;
        HealthyPercentage = healthyPercentage;
        DietPoints = dietPoints;
    }

    public float GetLandedShotPercentage()
    {
        return (LandedShots / FiredShots) * 100;
    }
}
