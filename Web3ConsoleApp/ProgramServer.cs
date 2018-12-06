using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.Quorum;
using Nethereum.RPC.TransactionReceipts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace Web3ConsoleApp
{
    public class ProgramServer
    {
        static void Main(string[] args)
        {
            //GetAccountBalance().Wait();
            Console.ReadLine();
        }

        public async Task<Bank> GetAccountBalance()
        {

            var web3Node1 = new Web3Quorum("http://192.168.20.51:8545");
            var password = "diana";

            var accounts = await web3Node1.Personal.ListAccounts.SendRequestAsync("finandina");
            var address = "0x274ab43196161928d04143cb6ee56429bbc38da1";
            var contractAdd = "0x88f4549c58d5dc8a8374272a999222a639daa149";
            var abi = "[{'constant':true,'inputs':[],'name':'totalSupply','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'issuers','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'accounts','outputs':[{'name':'bankAccount','type':'bytes12'},{'name':'id','type':'address'},{'name':'bankId','type':'address'},{'name':'balance','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'banks','outputs':[{'name':'id','type':'address'},{'name':'name','type':'bytes32'},{'name':'balance','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'inputs':[],'payable':false,'stateMutability':'nonpayable','type':'constructor'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_issuer','type':'address'},{'indexed':true,'name':'_bank','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'},{'indexed':false,'name':'_totalSupply','type':'uint256'}],'name':'Issued','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_id','type':'address'},{'indexed':false,'name':'_name','type':'string'}],'name':'BankCreated','type':'event'},{'anonymous':false,'inputs':[{'indexed':false,'name':'_bankAddress','type':'address'},{'indexed':false,'name':'_accountAddress','type':'address'}],'name':'AccountCreated','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_bankAddress','type':'address'},{'indexed':true,'name':'_accountAddress','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'}],'name':'CashedIn','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_accountAddress','type':'address'},{'indexed':true,'name':'_bankAddress','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'}],'name':'CashedOut','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_from','type':'address'},{'indexed':true,'name':'_to','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'}],'name':'Transfered','type':'event'},{'constant':true,'inputs':[{'name':'_id','type':'address'}],'name':'isIssuer','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_amount','type':'uint256'},{'name':'_bank_address','type':'address'}],'name':'issue','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_bankAddress','type':'address'},{'name':'_bankName','type':'string'}],'name':'createBank','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'_id','type':'address'}],'name':'getBank','outputs':[{'name':'','type':'address'},{'name':'','type':'string'},{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_bank_address','type':'address'}],'name':'getBankBalance','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_accountAddress','type':'address'},{'name':'_bankAccount','type':'string'}],'name':'createAccount','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'_id','type':'address'}],'name':'getAccount','outputs':[{'name':'','type':'address'},{'name':'','type':'uint256'},{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_bankAccount','type':'string'}],'name':'getAddressOfBankAccount','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_accountAddress','type':'address'}],'name':'getAccountBalance','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_accountAddress','type':'address'},{'name':'_amount','type':'uint256'}],'name':'cashIn','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_amount','type':'uint256'}],'name':'cashOut','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_to','type':'string'},{'name':'_amount','type':'uint256'}],'name':'transfer','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'}]";

            var transactionService = new TransactionReceiptPollingService(web3Node1.TransactionManager);
            var unlockAccountResult = await web3Node1.Personal.UnlockAccount.SendRequestAsync(address, password, 120);
            var gasPrice = await web3Node1.Eth.GasPrice.SendRequestAsync(address);

            var contract = web3Node1.Eth.GetContract(abi, contractAdd);

            var functionSet = contract.GetFunction("getBank");          

            var result = await functionSet.CallDeserializingToObjectAsync<Bank>(accounts[0].ToString());
            return result;

        }


        public async Task<string> CreateAccount(string cuenta)
        {

            var web3Node1 = new Web3Quorum("http://192.168.20.51:8545");
            var password = "diana";

            var accounts = await web3Node1.Personal.ListAccounts.SendRequestAsync("finandina");
            
            var address = "0x274ab43196161928d04143cb6ee56429bbc38da1";
            var contractAdd = "0x88f4549c58d5dc8a8374272a999222a639daa149";
            var abi = "[{'constant':true,'inputs':[],'name':'totalSupply','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'issuers','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'accounts','outputs':[{'name':'bankAccount','type':'bytes12'},{'name':'id','type':'address'},{'name':'bankId','type':'address'},{'name':'balance','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'banks','outputs':[{'name':'id','type':'address'},{'name':'name','type':'bytes32'},{'name':'balance','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'inputs':[],'payable':false,'stateMutability':'nonpayable','type':'constructor'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_issuer','type':'address'},{'indexed':true,'name':'_bank','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'},{'indexed':false,'name':'_totalSupply','type':'uint256'}],'name':'Issued','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_id','type':'address'},{'indexed':false,'name':'_name','type':'string'}],'name':'BankCreated','type':'event'},{'anonymous':false,'inputs':[{'indexed':false,'name':'_bankAddress','type':'address'},{'indexed':false,'name':'_accountAddress','type':'address'}],'name':'AccountCreated','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_bankAddress','type':'address'},{'indexed':true,'name':'_accountAddress','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'}],'name':'CashedIn','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_accountAddress','type':'address'},{'indexed':true,'name':'_bankAddress','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'}],'name':'CashedOut','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_from','type':'address'},{'indexed':true,'name':'_to','type':'address'},{'indexed':false,'name':'_amount','type':'uint256'}],'name':'Transfered','type':'event'},{'constant':true,'inputs':[{'name':'_id','type':'address'}],'name':'isIssuer','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_amount','type':'uint256'},{'name':'_bank_address','type':'address'}],'name':'issue','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_bankAddress','type':'address'},{'name':'_bankName','type':'string'}],'name':'createBank','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'_id','type':'address'}],'name':'getBank','outputs':[{'name':'','type':'address'},{'name':'','type':'string'},{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_bank_address','type':'address'}],'name':'getBankBalance','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_accountAddress','type':'address'},{'name':'_bankAccount','type':'string'}],'name':'createAccount','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'_id','type':'address'}],'name':'getAccount','outputs':[{'name':'','type':'address'},{'name':'','type':'uint256'},{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_bankAccount','type':'string'}],'name':'getAddressOfBankAccount','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_accountAddress','type':'address'}],'name':'getAccountBalance','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_accountAddress','type':'address'},{'name':'_amount','type':'uint256'}],'name':'cashIn','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_amount','type':'uint256'}],'name':'cashOut','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_to','type':'string'},{'name':'_amount','type':'uint256'}],'name':'transfer','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'}]";

            var transactionService = new TransactionReceiptPollingService(web3Node1.TransactionManager);
            var unlockAccountResult = await web3Node1.Personal.UnlockAccount.SendRequestAsync(address, password, 120);

            string nuevaCuentaBC = await web3Node1.Personal.NewAccount.SendRequestAsync(address);

            var contract = web3Node1.Eth.GetContract(abi, contractAdd);

            var functionSet = contract.GetFunction("createAccount");

            object[] myObjArray = { nuevaCuentaBC, cuenta };

            var transactionHash = await functionSet.SendTransactionAsync(accounts[0], new HexBigInteger(200000), myObjArray);


            return transactionHash;

        }

    }






    [FunctionOutput]
    public class Bank
    {
        [Parameter("address", "", 1)]
        public string BankAddress { get; set; }

        [Parameter("string", "", 2)]
        public string BankName { get; set; }

        [Parameter("uint256", "", 3)]
        public int Balance { get; set; }
    }


    [FunctionOutput]
    public class Account
    {
        [Parameter("address", "", 1)]
        public string BankAccount { get; set; }

        [Parameter("string", "", 2)]
        public string AccountAddress { get; set; }

        [Parameter("uint256", "", 3)]
        public int BankAddress { get; set; }

        [Parameter("uint256", "", 3)]
        public int Balance { get; set; }
    }

}
