using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class photonButton : MonoBehaviour
{
    public menuLogic mLogic;
    public InputField joinRoomInput, createRoomInput;



    public void onClickCreateRoom()
    {
        if (createRoomInput.text.Length >= 1)
            PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
    }

    public void onClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomInput.text);
    }

    private void OnJoinedRoom()
    {
        mLogic.disableMenu();
        Debug.Log("We are connected to Room");
        
        Debug.Log(PhotonNetwork.playerList.Length+"555");
    }
}
