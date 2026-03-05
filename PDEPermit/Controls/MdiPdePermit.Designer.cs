namespace SbcapcdOrg.PdePermit.Forms
{
	partial class MdiPdePermit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiPdePermit));
            ((System.ComponentModel.ISupportInitialize)(this.dsConnectionStrings)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "FACE03.ICO");
            this.imageList1.Images.SetKeyName(1, "Users.ico");
            this.imageList1.Images.SetKeyName(2, "DROP1PG.ICO");
            // 
            // MdiPdePermit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(1050, 725);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MdiPdePermit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " PDE";
            this.Shown += new System.EventHandler(this.MdiPdePermit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dsConnectionStrings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion


    //private System.Windows.Forms.ImageList imageList1;
	}
}
