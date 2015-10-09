using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using Datos.Control;
using Sipek.Common.CallControl;
using Outlook = Microsoft.Office.Interop.Outlook;
using Sipek.Sip;
using WaveLib.AudioMixer; // see http://www.codeproject.com/KB/graphics/AudioLib.aspx
using Datos.Entidades;
using Google.GData.Client;
using Google.Contacts;
using Google.GData.Extensions;
using Google.GData.Contacts;
using System.Net.Mail;

namespace MySoftPhone
{
    public partial class FrmConfiguracion : Form
    {
        private Mixers mMixers;
        BindingSource bsContactos = new BindingSource();
        BindingSource bsContactosGoogle = new BindingSource();

        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            InicializaAudio();
            InicializaCredentials();
            dgvContactos.DataSource = bsContactos;
           
        }

        private void InicializaCredentials()
        {
            tbServer.Text = Globals.Cnf.remoteServer;
            tbDatabase.Text = Globals.Cnf.remoteDatabase;
            tbusuario.Text = Globals.Cnf.remoteUser;
            tbPass.Text = Globals.Cnf.desencriptadaremotepass;
            tbCentralita.Text = Globals.Cnf.centralita;
            tbExtension.Text = Globals.Cnf.extension;
            tbSecret.Text = Globals.Cnf.desencriptadaSecret;
            tbPort.Text = Globals.Cnf.puerto;
            tbServidorCorreo.Text = Globals.Cnf.servidorCorreo;
            tbUserCorreo.Text = Globals.Cnf.usuarioCorreo;
            tbPasswordCorreo.Text = Globals.Cnf.desencriptadaPassCorreo;
            tbDestinatarioCorreo.Text = Globals.Cnf.destinatarioCorreo;
            tbPuertoCorreo.Text = Globals.Cnf.puertoCorreo;
            chkActivarCorreo.Checked = Globals.Cnf.activarCorreo;
        }

        bool InicializaAudio()
        {
            try
            {
                mMixers = new Mixers();
                //mMixers.Playback.MixerLineChanged += new WaveLib.AudioMixer.Mixer.MixerLineChangeHandler(mMixer_MixerLineChanged);
                //mMixers.Recording.MixerLineChanged += new WaveLib.AudioMixer.Mixer.MixerLineChangeHandler(mMixer_MixerLineChanged);
                LoadDeviceCombos(mMixers);

                return true;
            }
            catch (Exception ex)
            {
                ///report error
                MessageBox.Show("Error de inicialización de audio" + ex.Message, "Audio Mixer");
                return false;
            }
        }


        #region Audio
        private void comboBoxPlaybackDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadValues(MixerType.Playback);
        }

        private void comboBoxRecordingDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadValues(MixerType.Recording);
        }

        private void LoadValues(MixerType mixerType)
        {
            MixerLine line;

            //Get info about the lines
            if (mixerType == MixerType.Recording)
            {
                mMixers.Recording.DeviceId = ((MixerDetail)comboBoxRecordingDevices.SelectedItem).DeviceId;
                line = mMixers.Recording.UserLines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.SRC_MICROPHONE);
            }
            else
            {
                mMixers.Playback.DeviceId = ((MixerDetail)comboBoxPlaybackDevices.SelectedItem).DeviceId;
                line = mMixers.Playback.UserLines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.DST_SPEAKERS);
            }
        }

        private void LoadDeviceCombos(Mixers mixers)
        {
            //Load Output Combo
            MixerDetail mixerDetailDefault = new MixerDetail();
            mixerDetailDefault.DeviceId = -1;
            mixerDetailDefault.MixerName = "Default";
            mixerDetailDefault.SupportWaveOut = true;
            comboBoxPlaybackDevices.Items.Add(mixerDetailDefault);
            foreach (MixerDetail mixerDetail in mixers.Playback.Devices)
            {
                comboBoxPlaybackDevices.Items.Add(mixerDetail);
            }
            //comboBoxPlaybackDevices.SelectedIndex = 0;
            comboBoxPlaybackDevices.Text = Globals.Cnf.audioPlay;

            //Load Input Combo
            mixerDetailDefault = new MixerDetail();
            mixerDetailDefault.DeviceId = -1;
            mixerDetailDefault.MixerName = "Default";
            mixerDetailDefault.SupportWaveIn = true;
            comboBoxRecordingDevices.Items.Add(mixerDetailDefault);
            foreach (MixerDetail mixerDetail in mixers.Recording.Devices)
            {
                comboBoxRecordingDevices.Items.Add(mixerDetail);
            }
            //comboBoxRecordingDevices.SelectedIndex = 0;
            comboBoxRecordingDevices.Text = Globals.Cnf.audioRec;
        }
        #endregion Audio

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //SipekResources.StackProxy.setSoundDevice(mMixers.Playback.DeviceDetail.MixerName, mMixers.Recording.DeviceDetail.MixerName);
            //MessageBox.Show(mMixers.Playback.DeviceDetail.MixerName + "/" + comboBoxPlaybackDevices.Text);
            //MessageBox.Show(mMixers.Recording.DeviceDetail.MixerName + "/" + comboBoxRecordingDevices.Text);
            AplicarConfig();

            Close();
        }

        private void AplicarConfig()
        {
            if (!CompruebaTextBox(groupBox1))
            {
                MessageBox.Show("Faltan datos de configuración de base de datos");
                return;
            }
            if (!CompruebaTextBox(groupBox2))
            {
                MessageBox.Show("Faltan datos de configuración de centralita");
                return;
            }
            if (!TestConnectDB())
            {
                MessageBox.Show("No se ha podido conectar al servidor de datos");
                return;
            }
            if (TestConnectCentral() != "")
            {
                MessageBox.Show("No se ha podido conectar a la central telefónica");
                return;
            }
            if (chkActivarCorreo.Checked)
                if (!TestCorreo())
                {
                    MessageBox.Show("No se ha podido validar buzón correo");
                    return;
                }

            Globals.Cnf.audioPlay = comboBoxPlaybackDevices.Text;
            Globals.Cnf.audioRec = comboBoxRecordingDevices.Text;
            Globals.Cnf.remoteServer = tbServer.Text;
            Globals.Cnf.remoteDatabase = tbDatabase.Text;
            Globals.Cnf.remoteUser = tbusuario.Text;
            Globals.Cnf.desencriptadaremotepass = tbPass.Text;
            Globals.Cnf.centralita = tbCentralita.Text;
            Globals.Cnf.extension = tbExtension.Text;
            Globals.Cnf.desencriptadaSecret = tbSecret.Text;
            Globals.Cnf.puerto = tbPort.Text;
            Globals.Cnf.servidorCorreo=tbServidorCorreo.Text;
            Globals.Cnf.usuarioCorreo= tbUserCorreo.Text ;
            Globals.Cnf.desencriptadaPassCorreo=tbPasswordCorreo.Text ;
            Globals.Cnf.destinatarioCorreo=tbDestinatarioCorreo.Text ;
            Globals.Cnf.puertoCorreo=tbPuertoCorreo.Text  ;
            Globals.Cnf.activarCorreo = chkActivarCorreo.Checked;
            Globals.Cnf.SaveConfig();

        }

        private bool CompruebaTextBox(System.Windows.Forms.Control ct)
        {
        
            foreach (var item in ct.Controls)
                if (item is TextBox)
                    if ((item as TextBox).Text == "")
                        return false;
            return true;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if(!TestConnectDB())
                MessageBox.Show("No se ha podido conectar al servidor de datos");
            else
                MessageBox.Show("Conectado con éxito al servidor de datos");
        }

        bool TestConnectDB()
        {
            using (AccesoDatosMySql adm = new AccesoDatosMySql(tbServer.Text, tbDatabase.Text, tbusuario.Text, tbPass.Text))
            {
                if (adm.Conectar())
                    return true;
                else
                    return false;
            }
        }
        private void btnTestCentralita_Click(object sender, EventArgs e)
        {
            string error = TestConnectCentral();
            if (error == "")
            {
                MessageBox.Show("Conectado con éxito");
            }
            else
                MessageBox.Show("No se ha podido conectar: " + error);
        }


        string TestConnectCentral()
        {
            string error = "";
            try
            {
                PhoneConfig Config = new PhoneConfig(int.Parse(tbPort.Text));
                CCallManager CallManager = CCallManager.Instance;
                Config.AnadeAcount(tbExtension.Text, tbSecret.Text, tbExtension.Text, tbCentralita.Text, tbPort.Text);
                CallManager.StackProxy = pjsipStackProxy.Instance;

                CallManager.Config = Config;
                pjsipStackProxy.Instance.Config = Config;
                pjsipRegistrar.Instance.Config = Config;
                int resultado = CallManager.Initialize();
                if (resultado != 0)
                    error = "Error de inicialización de cliente";
                else
                {
                    resultado = pjsipRegistrar.Instance.registerAccounts();
                    if (resultado != Config.Accounts.Count)
                        error = "Error de registro";
                }
                //System.Threading.Thread.Sleep(2000);
                //CallManager.Shutdown();
                
            }
            catch (Exception ex)
            {
                error = "Error: " + ex.Message;
            }
            return error;
        }
        private void tcConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tcConfig.SelectedIndex==2)
            {
                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (Datos.AccesoDatosMySql adm = new AccesoDatosMySql())
            {
                bsContactos.DataSource = Datos.Entidades.Contacto.Listar();
                bsContactos.ResetBindings(false);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            AplicarConfig();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TestCorreo())
                MessageBox.Show("Correo enviado");
            else
                MessageBox.Show("No se ha podido enviar correo");

        }

        bool TestCorreo()
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port =int.Parse(tbPuertoCorreo.Text);
                client.Host = tbServidorCorreo.Text;
                client.EnableSsl = false;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(tbUserCorreo.Text, tbPasswordCorreo.Text);

                MailMessage mm = new MailMessage(tbUserCorreo.Text, tbDestinatarioCorreo.Text, "AdeaSoftPhone", "test correo");
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bsContactos.DataSource = Contacto.Listar().Where(q => q.nombre.Contains(textBox1.Text));
            bsContactos.ResetBindings(false);
        }
    }
}
