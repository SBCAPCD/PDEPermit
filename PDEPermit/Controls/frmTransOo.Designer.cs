namespace SbcapcdOrg.PdePermit.Forms
{
    partial class frmTransOo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransOo));
            this.usrTransOo = new SbcapcdOrg.PDEPermit.TransOo.usrTransOo();
            this.SuspendLayout();
            // 
            // usrTransOo
            // 
            this.usrTransOo.AutoScroll = false;
            this.usrTransOo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usrTransOo.ContactsReady = false;
            this.usrTransOo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrTransOo.drvPermit = null;
            this.usrTransOo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrTransOo.IsGetTransOoLetter = false;
            this.usrTransOo.LetterDataHasChanges = false;
            this.usrTransOo.LetterNo = 0;
            this.usrTransOo.Location = new System.Drawing.Point(0, 0);
            this.usrTransOo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usrTransOo.Name = "usrTransOo";
            this.usrTransOo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.usrTransOo.Size = new System.Drawing.Size(560, 510);
            this.usrTransOo.TabIndex = 1;
            this.usrTransOo.TransferIndex = null;
            this.usrTransOo.TransferType = null;
            this.usrTransOo.usrConnectionString = null;
            this.usrTransOo.ConString += new SbcapcdOrg.ControlLibrary.usrUserControl.ConStringEventHandler(this.usrTransOo_ConString);
            // 
            // frmTransOo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(560, 532);
            this.Controls.Add(this.usrTransOo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTransOo";
            this.ShowIcon = false;
            this.Text = "Transfer Owner/Operator";
            this.Shown += new System.EventHandler(this.frmTransOo_Shown);
            this.Controls.SetChildIndex(this.usrTransOo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SbcapcdOrg.PDEPermit.TransOo.usrTransOo usrTransOo;

    }
}