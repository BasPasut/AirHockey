using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDifficulty : Difficulty
{
    public void handleDifficulty()
    {
        AILevel.selector = AILevel.Level.normal;
        SpecialPuckController.IsAppear = false;
    }
}
