using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffPuck : SpecialPuckController
{
    public override void BuffAction(GameObject player)
    {
            audioController.playDebuffSound();
            ResetPuck();
        if (player.transform.localScale.x >= 1)
        {
            player.transform.localScale /= 2;
        }
    }

    public override void SpawnSPPuck(float timeRemaining)
    {
        if ((int)timeRemaining % 10 == 0)
        {
            if (SPPuck.active == false)
            {
                SpecialPuckController.IsAppear = true;
                SPPuck.SetActive(true);
                //rb.velocity = new Vector2(0, 0);
                rb.position = new Vector2(Random.Range(-2.08f, 2.16f), 0);
            }
        }
    }
}
