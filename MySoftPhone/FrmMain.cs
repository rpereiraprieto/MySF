using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sipek.Common.CallControl;
using Sipek.Sip;
using System.Threading;
using Sipek.Common;
using WaveLib.AudioMixer;
using Datos;
using Datos.Control;

namespace MySoftPhone
{
    public partial class FrmMain : Form
    {
        private Mixers mMixers;
        int _lastMicVol;
        IStateMachine llamada;
        int acountId=-1;
        Config cnf = Globals.Cnf;

        CCallManager CallManager
        {
            get { return CCallManager.Instance; }
        }

        PhoneConfig PhConfig;

        public FrmMain()
        {
            InitializeComponent();
            CallManager.CallStateRefresh += CallManager_CallStateRefresh;
            CallManager.IncomingCallNotification += CallManager_IncomingCallNotification;
            pjsipRegistrar.Instance.AccountStateChanged += Instance_AccountStateChanged;
        }


        private void CallManager_IncomingCallNotification(int sessionId, string number, string info)
        {
            llamada = CallManager.getCall(sessionId);
            if (lblEstado.InvokeRequired)
                lblEstado.Invoke(new ThreadStart(delegate
                {

                    MuestraDatosLlamada();
                }));
            else
                MuestraDatosLlamada();
        }

        bool TestConnectDB()
        {

            using (AccesoDatosMySql adm = new AccesoDatosMySql(cnf.remoteServer, cnf.remoteDatabase, cnf.remoteUser, cnf.desencriptadaremotepass))
            {
                if (adm.Conectar())
                    return true;
                else
                    return false;
            }
        }

        string TestConnectCentral()
        {
            string error = "";
            try
            {
                PhConfig = new PhoneConfig(int.Parse(cnf.puerto));
                
                PhConfig.AnadeAcount(cnf.extension, cnf.desencriptadaSecret, cnf.extension, cnf.centralita, cnf.puerto);
                CallManager.StackProxy = pjsipStackProxy.Instance;

                CallManager.Config = PhConfig;
                pjsipStackProxy.Instance.Config = PhConfig;
                pjsipRegistrar.Instance.Config = PhConfig;
                int resultado = CallManager.Initialize();
                if (resultado != 0)
                    error = "Error de inicialización de cliente";
                else
                {
                    resultado = pjsipRegistrar.Instance.registerAccounts();
                    if (resultado != PhConfig.Accounts.Count)
                        error = "Error de registro";
                }
            }
            catch (Exception ex)
            {
                error = "Error: " + ex.Message;
            }
            return error;
        }

        private bool InicializaSip()
        {
            string texto= TestConnectCentral();
            if (texto != "")
            {
                MessageBox.Show("Error de conection a central telefónica:" + texto);
                return false;
            }
            else
                return true;

        }

        public bool InicializaAudio()
        {
            try
            {
                pjsipStackProxy.Instance.setSoundDevice(cnf.audioPlay,cnf.audioRec);

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("No se puede inicializar el audio " + e.Message, "Verifica la configuración de audio!");
                return false;
            } 
        }

        private void mMixer_MixerLineChanged(Mixer mixer, MixerLine line)
        {
            try
            {
                    int volume = 0;
                        volume = line.Volume;
                if ((MixerLine)chkMutein.Tag == line)
                {
                    chkMutein.Checked = line.Volume == 0 ? true : false;
                }
                else if ((MixerLine)chkMuteOut.Tag == line)
                {
                    chkMuteOut.Checked = line.Mute;
                }
            }
            finally
            {
            }
        }

        void Instance_AccountStateChanged(int accountId, int accState)
        {
            if (accState == 200)
            {
                acountId = accountId;
                if (this.InvokeRequired)
                    this.Invoke(new ThreadStart(delegate
                    {
                        this.Text = $"AdeaTel Conectada extension: {PhConfig.Accounts[accountId].AccountName}";
                    }));
                else
                    this.Text = $"AdeaTel Conectada extension: {PhConfig.Accounts[accountId].AccountName}";
            }
            else
            {
                acountId = -1;
                if (this.InvokeRequired)
                    this.Invoke(new ThreadStart(delegate {
                        this.Text = $"AdeaTel desconectado";
                    }));
                else
                    this.Text = $"AdeaTel desconectado";

            }
        }

        void CallManager_CallStateRefresh(int sessionId)
        {
            llamada=CallManager.getCall(sessionId);
            if (lblEstado.InvokeRequired)
                lblEstado.Invoke(new ThreadStart(delegate
                    {

                        MuestraDatosLlamada();
                    }));
            else
                MuestraDatosLlamada();
        }

        void MuestraDatosLlamada()
        {
            switch (llamada.StateId)
            {
                case EStateId.ACTIVE:
                    lblEstado.Text = "Llamada activa " + llamada.CallingNumber;
                    break;
                case EStateId.INCOMING:
                    lblEstado.Text = "Llamada entrante " + llamada.CallingNumber;
                    break;

                case EStateId.ALERTING:
                    lblEstado.Text = "Llamando saliente " + llamada.CallingNumber;
                    break;

                case EStateId.HOLDING:
                    lblEstado.Text = "Llamada en espera " + llamada.CallingNumber;
                    break;
                case EStateId.IDLE:
                case EStateId.NULL:
                case EStateId.TERMINATED:
                    lblEstado.Text = "Finalizada llamada " + llamada.CallingNumber;
                    break;
                default:
                    lblEstado.Text = "Estado sin reconocer: " + llamada.StateId;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConecta_Click(object sender, EventArgs e)
        {
            if (!CallManager.IsInitialized)
            {
                if (!InicializaSip())
                    MessageBox.Show("No se ha podido conectar");
                if (!InicializaAudio())
                    MessageBox.Show("No se pudo inicializar el audio");
            }
            else
                MessageBox.Show("Ya conectado");

        }

        private void btnLlama_Click(object sender, EventArgs e)
        {
             int id=acountId;
             if (CallManager.IsInitialized == true && id != -1)
             {
                 IStateMachine _call = CallManager.createOutboundCall(tbNumero.Text, id);
             }
        }

        private void btnColgar_Click(object sender, EventArgs e)
        {
            if (llamada != null) // && (llamada.StateId == EStateId.ACTIVE || llamada.StateId==EStateId.INCOMING)
            {
                CallManager.onUserRelease(llamada.Session);
            }

        }

        private void chkMuteOut_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
                MixerLine line = (MixerLine)chk.Tag;
                if (line.Direction == MixerType.Recording)
                {
                    //line.Selected = chkBox.Checked;
                    if (chk.Checked == true)
                    {
                        _lastMicVol = line.Volume;
                        line.Volume = 0;
                    }
                    else
                    {
                        line.Volume = _lastMicVol;
                    }
                }
                else
                {
                    line.Mute = chk.Checked;
                }


        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Control ctr=(Control)sender;
            tbNumero.Text += ctr.Tag.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmConfiguracion frmc = new FrmConfiguracion();
            frmc.ShowDialog();
        }
    }
}
