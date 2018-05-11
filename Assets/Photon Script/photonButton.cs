using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class photonButton : MonoBehaviour
{
    public photonHandler pHandler;
    public InputField joinRoomInput, createRoomInput;



    public void onClickCreateRoom()
    {
        pHandler.createNewRoom();
    }

    public void onClickJoinRoom()
    {
        pHandler.joinRoom();
    }

    
}
