using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpossibleDifficulty : Difficulty
{
    public void handleDifficulty()
    {
        AILevel.selector = AILevel.Level.impossible;
        SpecialPuckController.IsAppear = false;
    }
}
