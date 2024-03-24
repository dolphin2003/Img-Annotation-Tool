using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Media; // For SystemSounds

using Painter_DLL; // (20201019) Jeff Revised!

namespace Painter2.SaveSetting
{
    public partial class SaveSetting_Form : Form
    {
        private Dictionary<string, Label> Dictionary_Label { get; set; } = new Dictionary<string, Label>();

        /// <summary>
        /// ON 時，控制項啟用
        /// </summary>
        private Dictionary<string, List<Control>> Dict_ON_Enabled { get; set; } = new Dictionary<string, List<Control>>();
        /// <summary>
        /// OFF 時，控制項啟用
        /// </summary>
        private Dictionary<string, List<Control>> Dict_OFF_Enabled { get; set; } = new Dictionary<string, List<Control>>();

        private cls_SaveSetting saveSetting { get; set; } = new cls_SaveSetting();
        
        public SaveSetting_Form()
        {
            InitializeComponent();

            this.Dictionary_Label.Add("save_label", lbl_save_label);
            this.Dictionary_Label.Add("save_OrigImage", lbl_save_OrigImage);
            this.Dictionary_Label.Add("save_Image1", lbl_save_Image1);
            this.Dictionary_Label.Add("save_Image2", lbl_save_Image2);
            this.Dictionary_Label.Add("save_Image3", lbl_save_Image3);
            this.Dictionary_Label.Add("Load_AllImageFormat", lbl_Load_AllImageFormat);
            this.Dictionary_Label.Add("Save_SameImageFormat", lbl_Save_SameImageFormat);
            this.Dictionary_Label.Add("B_ColorList", lbl_B_ColorList);

            this.Dict_ON_Enabled.Add("save_label", new List<Control>() { this.label_FileName_label , this.textBox_FileName_label });
            this.Dict_ON_Enabled.Add("save_OrigImage", new List<Control>() { this.label_FileName_OrigImage, this.textBox_FileName_OrigImage });
            this.Dict_ON_Enabled.Add("save_Image1", new List<Control>() { this.label_FileName_Image1, this.textBox_FileName_Image1 });
            this.Dict_ON_Enabled.Add("save_Image2", new List<Control>() { this.label_FileName_Image2, this.textBox_FileName_Image2 });
            this.Dict_ON_Enabled.Add("save_Image3", new List<Control>() { this.label_FileName_Image3, this.textBox_FileName_Image3 });
            this.Dict_ON_Enabled.Add("B_ColorList", new List<Control>() { this.panel_ColorList });

            this.Dict_OFF_Enabled.Add("Load_AllImageFormat", new List<Control>() { this.label_ImageFormat_Load, this.cbx_ImageFormat_Load });
            this.Dict_OFF_Enabled.Add("Save_SameImageFormat", new List<Control>() { this.label_ImageFormat_Save, this.cbx_ImageFormat_Save });

            clsLanguage.clsLanguage.SetLanguateToControls(this, true, "false");
        }

        public void Set_saveSetting(cls_SaveSetting saveSetting_)
        {
            this.saveSetting = saveSetting_;
        }

        private void SaveSetting_Form_Load(object sender, EventArgs e)
        {
        