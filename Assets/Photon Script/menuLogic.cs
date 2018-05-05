using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuLogic : MonoBehaviour
{


    public void disableMenu()
    {
        PhotonNetwork.LoadLevel("MultiPlayer.P1");
    }


}
