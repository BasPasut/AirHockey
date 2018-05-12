using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for create BuffPuck when player hit it in his goal that player will get bigger
 * 
 */
public class BuffPuck : SpecialPuckController
{
    /** check if BuffPuck is appear */
    public bool apPear = false;

    /**
     * make player whose hit BuffPuck to their goal bigger
     * 
     * @param player is the player that hit BuffPuck to his goal
     */
    public override void BuffAction(GameObject player)
    {
        audioController.playBuffSound();
        apPear = false;
        ResetPuck();
        if (player.transform.localScale.x <= 1)
        {
            player.transform.localScale *= 2;
        }
    }

    /**
     * make BuffPuck appear on scene
     * 
     * @param currentTime is overall of time of the game
     */
    public override void SpawnSPPuck(int currentTime)
    {
        if (currentTime % 30 == 0)
        {
            if (SPPuck.active == false)
            {
                SpecialPuckController.IsAppear = true;
                apPear = true;
                SPPuck.SetActive(true);
                //rb.velocity = new Vector2(0, 0);
                rb.position = new Vector2(Random.Range(-2.08f, 2.16f), 0);
            }
        }
    }
}
