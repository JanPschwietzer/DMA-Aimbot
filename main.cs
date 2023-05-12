using System.Numerics;
using System.Windows.Forms;
using vmmsharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Brookshook_DMA
{
    public partial class main : Form
    {
        private Point pictureBoxCenter { get; set; }

        public main()
        {
            InitializeComponent();
            if (!InitHack())
                return;

            Thread thread = new Thread(ShowPlayersOnRadar);
            thread.Start();
        }

        #region Initialization
        private bool InitHack()
        {
            pictureBoxCenter = new Point(
                pictureBox1.Left + pictureBox1.Width / 2,
                pictureBox1.Top + pictureBox1.Height / 2
            );
            Arrow1.Location = pictureBoxCenter;


            try
            {
                if (Data.VmmHandle == null)
                {
                    Data.VmmHandle = new("", "-device", "FPGA");
                }
                lblStatus.Text = "Status: VmmHandle.dll initilized!";

                if (!SetDllEntries())
                {
                    btnTryInitAgain.Enabled = true;
                    btnTryInitAgain.Visible = true;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Status: " + ex.Message;
                btnTryInitAgain.Enabled = true;
                btnTryInitAgain.Visible = true;
                return false;
            }
        }

        private bool SetDllEntries()
        {
            uint csgoPID = 0;
            if (!Data.VmmHandle.PidGetFromName("csgo.exe", out csgoPID))
            {
                lblStatus.Text = "Status: csgo.exe not found!";
                return false;
            }
            Data.CsgoPid = csgoPID;
            Data.ClientDll = (uint)Data.VmmHandle.Map_GetModuleFromName(Data.CsgoPid, "client.dll").vaBase;
            Data.EngineDll = (uint)Data.VmmHandle.Map_GetModuleFromName(Data.CsgoPid, "engine.dll").vaBase;

            if (Data.EngineDll == 0 || Data.ClientDll == 0)
            {
                lblStatus.Text = "Status: modules not found!";
                return false;
            }

            lblClient.Text = "client.dll: 0x" + Data.ClientDll.ToString("X") + " | engine.dll : 0x" + Data.EngineDll.ToString("X");
            lblStatus.Text = "Initilized!";
            return true;
        }

        private void btnTryInitAgain_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Status: Initilizing...";
            btnTryInitAgain.Enabled = false;
            btnTryInitAgain.Visible = false;
            InitHack();
        }

        #endregion

        #region Images
        private void cbMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbMaps.SelectedIndex)
            {
                case (int)Data.Maps.Ancient:
                    pictureBox1.Image = Properties.Resources.de_ancient_radar_spectate;
                    break;
                case (int)Data.Maps.Cache:
                    pictureBox1.Image = Properties.Resources.de_cache_radar_spectate;
                    break;
                case (int)Data.Maps.Dust2:
                    pictureBox1.Image = Properties.Resources.de_dust2_radar_spectate;
                    break;
                case (int)Data.Maps.Inferno:
                    pictureBox1.Image = Properties.Resources.de_inferno_radar_spectate;
                    break;
                case (int)Data.Maps.Mirage:
                    pictureBox1.Image = Properties.Resources.de_mirage_radar_spectate;
                    break;
                case (int)Data.Maps.Nuke:
                    pictureBox1.Image = Properties.Resources.de_nuke_radar_spectate;
                    break;
                case (int)Data.Maps.Overpass:
                    pictureBox1.Image = Properties.Resources.de_overpass_radar_spectate;
                    break;
                case (int)Data.Maps.Train:
                    pictureBox1.Image = Properties.Resources.de_train_radar_spectate;
                    break;
                case (int)Data.Maps.Vertigo:
                    pictureBox1.Image = Properties.Resources.de_vertigo_radar_spectate;
                    break;
            }
        }

        #endregion

        #region Radar

        private async void ShowPlayersOnRadar()
        {
            while (true)
            {
                if (!Hack.IsIngame() || !Hack.IsEntityValid(0))
                    continue;
                var health = Hack.GetEntityHealth(0);
                Vector3 viewAngles = Hack.GetViewAngle();

                MethodInvoker action = delegate
                {
                    lblInfo.Text += string.Format("current Health: {0} Viewangles X: {1} Y: {2} Z: {3}, ", health, viewAngles.X, viewAngles.Y, viewAngles.Z);
                };
                lblInfo.BeginInvoke(action);

                await Task.Delay(5);
            }
        }

        #endregion
    }
}