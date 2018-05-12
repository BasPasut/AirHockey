using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffPuck : SpecialPuckController
{
    public CountDownTimer cdt;
    public bool apPear = false;

    public override void BuffAction(GameObject player)
    {
            audioController.playDebuffSound();
            apPear = false;
            ResetPuck();
        if (player.transform.localScale.x >= 1)
        {
            player.transform.localScale /= 2;
        }
    }

    public override void SpawnSPPuck(int currentTime)
    {
        if (currentTime % 20 == 0)
        {
            if (SPPuck.active == false)
            {
                SpecialPuckController.IsAppear = true;
                apPear = true;
                SPPuck.SetActive(true);
                rb.position = new Vector2(Random.Range(-2.08f, 2.16f), 0);
            }
        }
    }
}
