using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using MoralisWeb3ApiSdk;

using Nethereum.Util;
#if UNITY_WEBGL
using Moralis.WebGL.Platform.Objects;
using Moralis.WebGL.Hex.HexTypes;
using Moralis.WebGL.Models;
#else
using System.Threading.Tasks;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Moralis.Platform.Objects;
using Moralis.Web3Api.Models;
#endif


using TMPro;
using UnityEngine;



namespace Web3MultiplayerRPG
{

    public class BuyItem : MonoBehaviour
    {
        public TextMeshProUGUI toUsername;
       
        private string merchantAddress = "0x6d0cEAFFD8824D8E1B382B2cfB07cAfa955E4a65";

        


        private async void SendTransactionAsync()
        {
            // Retrieve from address, the address used to athenticate the user.
            var user = await MoralisInterface.GetUserAsync();
            string fromAddress = user.authData["moralisEth"]["id"].ToString();

            // Create purchase transaction request.
            TransactionInput txnRequest = new TransactionInput()
            {
                Data = String.Empty,
                From = fromAddress,
                To = merchantAddress,
                Value = new HexBigInteger(0)
            };

            try
            {
                // Execute the transaction.


               //string txnHash = await MoralisInterface.Web3Client.Eth.TransactionManager.SendTransactionAsync(txnRequest);

               // Debug.Log($"Transfered {0} WEI from {fromAddress} to {merchantAddress}.  TxnHash: {txnHash}");
            }
            catch (Exception exp)
            {
                Debug.Log($"Transfer of {0} WEI from {fromAddress} to {merchantAddress} failed!");
            }
        }

        public void SendTransaction()
        {
            SendTransactionAsync();
        }

    }

}


