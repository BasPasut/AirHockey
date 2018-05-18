using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {

    private readonly string PRIVATEKEY = "ddQHR6_f4keHMODEUgC8WgCh9Z1BQEiE2C3yMABEDrhg" ;

    public string PrivateKey {
        get {
            return PRIVATEKEY;
        }
    }

}
