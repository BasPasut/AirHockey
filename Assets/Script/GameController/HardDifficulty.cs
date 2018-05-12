using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDifficulty : Difficulty
{
    public void handleDifficulty()
    {
        AILevel.selector = AILevel.Level.hard;
    }
}
