using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sipek.Common;

namespace MySoftPhone
{
          

    class PhoneConfig:Sipek.Common.IConfiguratorInterface
    {
        List<IAccount> _acclist = new List<IAccount>();
        private static List<string> _codec = new List<string>() { "PCMU/8000/1", "PCMA/8000/1", "G722/16000/1" };

        internal PhoneConfig(int puerto)
        {
            SIPPort = puerto;
        }

        public void AnadeAcount(string user,string pass,string extension,string host,string port)
        {
            AccountConfig ac = new AccountConfig(user, pass, extension, host, port, _acclist.Count);
            _acclist.Add(ac);
        }

        public bool AAFlag
        {
            get            {                return false;            }
            set            {                throw new NotImplementedException();            }
        }

        public IAccount  this[int index]
        {
            get
            {
                var item = from q in _acclist where q.Index == index select q;
                return item.FirstOrDefault();
            }
        }

        public List<IAccount> Accounts
        {
            get { return _acclist; }  
        }

        public bool CFBFlag
        {
            get {               throw new NotImplementedException();            } 
            set            {                throw new NotImplementedException();            }
        }

        public string CFBNumber
        {
            get            {                throw new NotImplementedException();            }
            set             {                throw new NotImplementedException();            }
        }

        public bool CFNRFlag
        {
            get            {                return false;            }
            set            {                throw new NotImplementedException();            }
        }

        public string CFNRNumber
        {
            get            {                throw new NotImplementedException();            }
            set            {                throw new NotImplementedException();            }
        }

        public bool CFUFlag
        {
            get            {                return false;            }            
            set            {                throw new NotImplementedException();            }
        }

        public string CFUNumber
        {
            get            {                throw new NotImplementedException();            }            
            set            {                throw new NotImplementedException();            }
        }

        public List<string> CodecList
        {
            get { return _codec; }
            set            {                throw new NotImplementedException();            }
        }



        public bool DNDFlag
        {
            get            {                return false;            }
            set            {                throw new NotImplementedException();            }
        }

        public int DefaultAccountIndex
        {
            get { return 0; }
        }

        public bool IsNull
        {
            get { return false; }
        }

        public bool PublishEnabled
        {
            get            {                throw new NotImplementedException();            }
            set            {                throw new NotImplementedException();            }
        }

        public int SIPPort
        {
            get;
            set;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }


    class AccountConfig : IAccount
    {

        public AccountConfig(string _user,string _password, string _extension, string _host,string _port,int _index)
        {
            AccountName = _extension;
            DisplayName = AccountName;
            DomainName = "*";
            HostName = _host + ":" + _port;
            Id = _extension;
            Index = _index;
            Password = _password;
            ProxyAddress = "";
            RegState = 0;
            TransportMode = ETransportMode.TM_UDP;
            UserName = _user;
        }



        public string AccountName        {            get;            set;        }

        public string DisplayName        {            get;            set;        }

        public string DomainName        {            get;            set;        }

        public string HostName        {            get;            set;        }

        public string Id        {            get;            set;        }

        public int Index        {            get;            set;        }

        public string Password        {            get;            set;        }

        public string ProxyAddress        {            get;            set;        }

        public int RegState        {            get;            set;        }

        public ETransportMode TransportMode        {            get;            set;        }

        public string UserName        {            get;            set;        }
    }
}
