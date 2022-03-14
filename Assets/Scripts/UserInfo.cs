using System;
using System.Collections;
using System.Collections.Generic;
using MoralisWeb3ApiSdk;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using TMPro;
using UnityEngine;



    public class UserInfo : MonoBehaviour
    {
        public TextMeshProUGUI toUsername;
        public TextMeshProUGUI toAddress;

        public void SetInformation(string clickedUsername, string clickedWalletAddress)
        {
            toUsername.text = "Username: " + clickedUsername;
            toAddress.text = "Wallet Address: " + clickedWalletAddress;
        }

        
    }


