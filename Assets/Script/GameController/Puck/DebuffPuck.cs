using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for create DebuffPuck when player hit it in his goal that player will get smaller
 * 
 */
public class DebuffPuck : SpecialPuckController
{
    public CountDownTimer cdt;
    /** check if DebuffPuck is appear */
    public bool apPear = false;

    /**
     * make player whose hit DebuffPuck to their goal bigger
     * 
     * @param player is the player that hit DebuffPuck to his goal
     */
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

    /**
    * make DebuffPuck appear on scene
    * 
    * @param currentTime is overall of time of the game
    */
    public override void SpawnSPPuck(int currentTime)
    {
        if (currentTime % 20 == 0)
        {
                SpecialPuckController.IsAppear = true;
            if (SPPuck.active == false)
            {
                apPear = true;
                SPPuck.SetActive(true);
                rb.position = new Vector2(Random.Range(-2.08f, 2.16f), 0);
            }
        }
    }
}
