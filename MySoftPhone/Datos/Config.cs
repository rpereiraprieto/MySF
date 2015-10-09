using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace Datos.Control
{
    public class Config
    {
        public string audioRec { get; set; }
        public string audioPlay { get; set; }
        public bool log { get; set; }
        public string remoteServer { get; set; }
        public string remoteDatabase { get; set; }
        public string remoteUser { get; set; }
        public string puerto { get; set; }
        public string desencriptadaremotepass;
        public string remotePass
        {
            get {return  Cifrados.Encriptar(desencriptadaremotepass); }
            set { desencriptadaremotepass = Cifrados.Desencriptar(value); }
        }

        public string centralita { get; set; }
        public string extension { get; set; }
        public string desencriptadaSecret;
        public string secret
        {
            get { return Cifrados.Encriptar(desencriptadaSecret); }
            set { desencriptadaSecret =Cifrados.Desencriptar(value); }
        }

        //add key = "servidorCorreo" value="mail.adealoxica.com"/>
        //<add key = "usuarioCorreo" value="rpereira@adealoxica.com"/>
        //<add key = "passCorreo" value=""/>
        //<add key = "destinatarioCorreo" value="rpereira@adealoxica.com"/>

        public string servidorCorreo { get; set; }
        public string usuarioCorreo { get; set; }
        public string destinatarioCorreo { get; set; }

        public string  desencriptadaPassCorreo;

        public string  passCorreo
        {
            get { return Cifrados.Encriptar( desencriptadaPassCorreo); }
            set { desencriptadaPassCorreo = Cifrados.Desencriptar(value); }
        }
        public string puertoCorreo { get; set; }
        public bool activarCorreo { get; set; }

        public Config()
        {
            audioPlay = "";
            audioRec = "";
                PropertyInfo[] pi = typeof(Config).GetProperties();
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //Configuration config = ConfigurationManager.OpenExeConfiguration("ConnectPrestashopSQl.exe");
                AppSettingsSection app = config.AppSettings;
                foreach (var item in pi)
                {
                    if (item.PropertyType == typeof(string))
                        item.SetValue(this, app.Settings[item.Name].Value , null);
                    if (item.PropertyType == typeof(int))
                        item.SetValue(this, int.Parse(app.Settings[item.Name].Value), null);
                    if (item.PropertyType == typeof(bool))
                        item.SetValue(this, app.Settings[item.Name].Value == "1", null);
                }
        }

        public void SaveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //Configuration config = ConfigurationManager.OpenExeConfiguration("ConnectPrestashopSQl.exe");
            AppSettingsSection app = config.AppSettings;
           // app.Settings.Add("x", "this is X");

            PropertyInfo[] pi = typeof(Config).GetProperties();

            foreach (var item in pi)
            {
                if (item.PropertyType == typeof(bool))
                    app.Settings[item.Name].Value=(((bool)item.GetValue(this, null))?"1":"0");
                else
                    app.Settings[item.Name].Value= item.GetValue(this, null).ToString();
             }
            config.Save(ConfigurationSaveMode.Modified);        
        }


    }
}
