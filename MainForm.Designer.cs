partial class MainForm
{
	private System.ComponentModel.IContainer components = null;
	private System.Windows.Forms.Button btnMuayeneSirasiGoster;
	private System.Windows.Forms.Button btnMuayeneGonder;
	private System.Windows.Forms.ListBox lstMuayeneSirasi;
	private System.Windows.Forms.DataGridView dataGridViewMuayeneGonderilenler;
	private System.Windows.Forms.Label lblMuayeneGonderilenler;
	private System.Windows.Forms.Panel pnlHeap;
	private System.Windows.Forms.ListBox lstMuayeneCikis;

	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.btnMuayeneSirasiGoster = new System.Windows.Forms.Button();
		this.btnMuayeneGonder = new System.Windows.Forms.Button();
		this.lstMuayeneSirasi = new System.Windows.Forms.ListBox();
		this.dataGridViewMuayeneGonderilenler = new System.Windows.Forms.DataGridView();
		this.lblMuayeneGonderilenler = new System.Windows.Forms.Label();
		this.pnlHeap = new System.Windows.Forms.Panel();
		this.lstMuayeneCikis = new System.Windows.Forms.ListBox();
		((System.ComponentModel.ISupportInitialize)(this.dataGridViewMuayeneGonderilenler)).BeginInit();
		this.SuspendLayout();
		// 
		// btnMuayeneSirasiGoster
		// 
		this.btnMuayeneSirasiGoster.Location = new System.Drawing.Point(16, 15);
		this.btnMuayeneSirasiGoster.Margin = new System.Windows.Forms.Padding(4);
		this.btnMuayeneSirasiGoster.Name = "btnMuayeneSirasiGoster";
		this.btnMuayeneSirasiGoster.Size = new System.Drawing.Size(200, 28);
		this.btnMuayeneSirasiGoster.TabIndex = 0;
		this.btnMuayeneSirasiGoster.Text = "Muayene Sırasını Göster";
		this.btnMuayeneSirasiGoster.UseVisualStyleBackColor = true;
		this.btnMuayeneSirasiGoster.Click += new System.EventHandler(this.btnMuayeneSirasiGoster_Click);
		// 
		// btnMuayeneGonder
		// 
		this.btnMuayeneGonder.Location = new System.Drawing.Point(16, 50);
		this.btnMuayeneGonder.Margin = new System.Windows.Forms.Padding(4);
		this.btnMuayeneGonder.Name = "btnMuayeneGonder";
		this.btnMuayeneGonder.Size = new System.Drawing.Size(200, 28);
		this.btnMuayeneGonder.TabIndex = 1;
		this.btnMuayeneGonder.Text = "Muayeneye Gönder";
		this.btnMuayeneGonder.UseVisualStyleBackColor = true;
		this.btnMuayeneGonder.Click += new System.EventHandler(this.btnMuayeneGonder_Click);
		// 
		// lstMuayeneSirasi
		// 
		this.lstMuayeneSirasi.FormattingEnabled = true;
		this.lstMuayeneSirasi.ItemHeight = 16;
		this.lstMuayeneSirasi.Location = new System.Drawing.Point(16, 86);
		this.lstMuayeneSirasi.Margin = new System.Windows.Forms.Padding(4);
		this.lstMuayeneSirasi.Name = "lstMuayeneSirasi";
		this.lstMuayeneSirasi.Size = new System.Drawing.Size(345, 228);
		this.lstMuayeneSirasi.TabIndex = 2;
		// 
		// dataGridViewMuayeneGonderilenler
		// 
		this.dataGridViewMuayeneGonderilenler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewMuayeneGonderilenler.Location = new System.Drawing.Point(403, 86);
		this.dataGridViewMuayeneGonderilenler.Margin = new System.Windows.Forms.Padding(4);
		this.dataGridViewMuayeneGonderilenler.Name = "dataGridViewMuayeneGonderilenler";
		this.dataGridViewMuayeneGonderilenler.RowHeadersWidth = 51;
		this.dataGridViewMuayeneGonderilenler.Size = new System.Drawing.Size(1563, 229);
		this.dataGridViewMuayeneGonderilenler.TabIndex = 3;
		// 
		// Add columns to dataGridViewMuayeneGonderilenler
		// 
		this.dataGridViewMuayeneGonderilenler.Columns.Add("HastaNo", "Hasta No");
		this.dataGridViewMuayeneGonderilenler.Columns.Add("HastaAdi", "Hasta Adı");
		this.dataGridViewMuayeneGonderilenler.Columns.Add("HastaYasi", "Hasta Yaşı");
		this.dataGridViewMuayeneGonderilenler.Columns.Add("Cinsiyet", "Cinsiyet");
		this.dataGridViewMuayeneGonderilenler.Columns.Add("MahkumlukDurumBilgisi", "Mahkumluk Durumu");
		this.dataGridViewMuayeneGonderilenler.Columns.Add("EngellilikOrani", "Engellilik Oranı");
		this.dataGridViewMuayeneGonderilenler.Columns.Add("KanamaDurumu", "Kanama Durumu");
		this.dataGridViewMuayeneGonderilenler.Columns.Add("KayitSaati", "Kayıt Saati");
		this.dataGridViewMuayeneGonderilenler.Columns.Add("MuayeneSaati", "Muayene Saati");
		this.dataGridViewMuayeneGonderilenler.Columns.Add("MuayeneSuresi", "Muayene Süresi");
		this.dataGridViewMuayeneGonderilenler.Columns.Add("OncelikPuani", "Öncelik Puanı");
		// 
		// lblMuayeneGonderilenler
		// 
		this.lblMuayeneGonderilenler.AutoSize = true;
		this.lblMuayeneGonderilenler.Location = new System.Drawing.Point(400, 62);
		this.lblMuayeneGonderilenler.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblMuayeneGonderilenler.Name = "lblMuayeneGonderilenler";
		this.lblMuayeneGonderilenler.Size = new System.Drawing.Size(162, 16);
		this.lblMuayeneGonderilenler.TabIndex = 4;
		this.lblMuayeneGonderilenler.Text = "Muayeneye Gönderilenler";
		// 
		// pnlHeap
		// 
		this.pnlHeap.Location = new System.Drawing.Point(0, 321);
		this.pnlHeap.Name = "pnlHeap";
		this.pnlHeap.Size = new System.Drawing.Size(2109, 596);
		this.pnlHeap.TabIndex = 5;
		this.pnlHeap.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeap_Paint);
		// 
		// lstMuayeneCikis
		// 
		this.lstMuayeneCikis.FormattingEnabled = true;
		this.lstMuayeneCikis.ItemHeight = 16;
		this.lstMuayeneCikis.Location = new System.Drawing.Point(0, 825);
		this.lstMuayeneCikis.Margin = new System.Windows.Forms.Padding(4);
		this.lstMuayeneCikis.Name = "lstMuayeneCikis";
		this.lstMuayeneCikis.Size = new System.Drawing.Size(2270, 228);
		this.lstMuayeneCikis.TabIndex = 6;
		// 
		// MainForm
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(1924, 1055);
		this.Controls.Add(this.lstMuayeneCikis);
		this.Controls.Add(this.pnlHeap);
		this.Controls.Add(this.lblMuayeneGonderilenler);
		this.Controls.Add(this.dataGridViewMuayeneGonderilenler);
		this.Controls.Add(this.lstMuayeneSirasi);
		this.Controls.Add(this.btnMuayeneGonder);
		this.Controls.Add(this.btnMuayeneSirasiGoster);
		this.Margin = new System.Windows.Forms.Padding(4);
		this.Name = "MainForm";
		this.Text = "Hasta Muayene Sistemi";
		((System.ComponentModel.ISupportInitialize)(this.dataGridViewMuayeneGonderilenler)).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();
	}
}
