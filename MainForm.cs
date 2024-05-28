using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using System.Linq;

public partial class MainForm : Form
{
	private MuayeneHeap muayeneHeap;
	private List<Hasta> hastalar;
	private DateTime muayeneBaslangicSaati;
	private int HastaIndex;
	private bool isMuayeneSirasiGosterildi;
	private bool isYeniHastaEklendi;
	private int muayeneSiraNumarasi;

	public MainForm()
	{
		InitializeComponent();
		muayeneHeap = new MuayeneHeap();
		hastalar = OkuHastaBilgileri(@"C:\Hasta\Hasta.txt");

		HastaNum(hastalar);

		if (hastalar.Any() && hastalar.First().HastaKayitSaati.Hour < 9)
		{
			hastalar.First().HastaKayitSaati = new DateTime(2024, 5, 9, 9, 0, 0);
		}

		hastalar = hastalar.OrderBy(h => h.HastaKayitSaati).ToList();

		muayeneBaslangicSaati = new DateTime(2024, 5, 9, 9, 0, 0);

		foreach (var hasta in hastalar.Where(h => h.HastaKayitSaati.Hour == 8))
		{
			muayeneHeap.Ekle(hasta);
		}

		HastaIndex = hastalar.FindIndex(h => h.HastaKayitSaati.Hour >= 9);
		isMuayeneSirasiGosterildi = false;
		isYeniHastaEklendi = false;
		muayeneSiraNumarasi = 1;
	}

	private void btnMuayeneSirasiGoster_Click(object sender, EventArgs e)
	{
		isMuayeneSirasiGosterildi = true;
		lstMuayeneSirasi.Items.Clear();
		var heapList = muayeneHeap.GetHeap();
		foreach (var hasta in heapList)
		{
			lstMuayeneSirasi.Items.Add($"{hasta.HastaAdi} - Öncelik Puanı: {hasta.OncelikPuani}");
		}

		pnlHeap.Invalidate();
	}

	private void btnMuayeneGonder_Click(object sender, EventArgs e)
	{
		if (!isMuayeneSirasiGosterildi)
		{
			MessageBox.Show("Muayene Sırasında hasta yok.");
			return;
		}

		var yeniHastalar = YıgınaYeniHastaEkle();

		if (yeniHastalar.Count > 0)
		{
			lstMuayeneSirasi.Items.Clear();
			var heapList = muayeneHeap.GetHeap();
			foreach (var h in heapList)
			{
				lstMuayeneSirasi.Items.Add($"{h.HastaAdi} - Öncelik Puanı: {h.OncelikPuani}");
			}

			string mesaj = "Geçmiş hasta muayenedeyken gelen hastalar:\n";
			foreach (var yeniHasta in yeniHastalar)
			{
				mesaj += $"{yeniHasta.HastaAdi} - Kayıt Saati: {yeniHasta.HastaKayitSaati.ToString("HH:mm")} - Öncelik Puanı: {yeniHasta.OncelikPuani}\n";
			}
			MessageBox.Show(mesaj);

			isYeniHastaEklendi = true;

			pnlHeap.Invalidate();
		}
		else
		{
			if (!muayeneHeap.BosMu())
			{
				SonrakiHasta();
				isYeniHastaEklendi = false;
			}
			else
			{
				MessageBox.Show("Muayene sırasına eklenmiş hasta yok.");
			}
		}

		pnlHeap.Invalidate();
	}

	private void SonrakiHasta()
	{
		var hasta = muayeneHeap.Cikar();

		if (hasta.HastaKayitSaati > muayeneBaslangicSaati)
		{
			muayeneBaslangicSaati = hasta.HastaKayitSaati;
		}

		hasta.MuayeneSaati = muayeneBaslangicSaati;
		muayeneBaslangicSaati = muayeneBaslangicSaati.AddMinutes(hasta.MuayeneSuresi);

		lstMuayeneSirasi.Items.Clear();
		var heapList = muayeneHeap.GetHeap();
		foreach (var h in heapList)
		{
			lstMuayeneSirasi.Items.Add($"{h.HastaAdi} - Öncelik Puanı: {h.OncelikPuani}");
		}

		dataGridViewMuayeneGonderilenler.Rows.Insert(0,
			hasta.HastaNo.ToString(),
			hasta.HastaAdi,
			hasta.HastaYasi.ToString(),
			hasta.Cinsiyet.ToString(),
			hasta.MahkumlukDurumBilgisi.ToString(),
			hasta.EngellilikOrani.ToString(),
			hasta.KanamaliHastaDurumBilgisi,
			hasta.HastaKayitSaati.ToString("HH:mm"),
			hasta.MuayeneSaati?.ToString("HH:mm"),
			hasta.MuayeneSuresi.ToString(),
			hasta.OncelikPuani.ToString());

		string cikisMesaji = $"{muayeneSiraNumarasi}. sırada {hasta.HastaNo} hasta numaralı {hasta.HastaAdi} adlı hasta muayene olmuştur - Öncelik Puanı: {hasta.OncelikPuani}, Muayene Süresi: {hasta.MuayeneSuresi} dakika, Muayene Giriş Saati: {hasta.MuayeneSaati?.ToString("HH:mm")}";
		lstMuayeneCikis.Items.Insert(0, cikisMesaji);

		muayeneSiraNumarasi++;

		pnlHeap.Invalidate();
	}

	private void DrawHeap(Graphics g, List<Hasta> heap, int index, int x, int y, int xOffset, Dictionary<Hasta, int> priorityMap)
	{
		if (index >= heap.Count) return;

		var hasta = heap[index];
		var nodeRect = new Rectangle(x - 50, y - 30, 100, 60);
		g.DrawEllipse(Pens.Black, nodeRect);
		string nodeText = $"{hasta.HastaAdi}\nÖncelik: {hasta.OncelikPuani}\nBekleme: {hasta.MuayeneSuresi} dk\nSıra: {priorityMap[hasta]}";

		var textSize = g.MeasureString(nodeText, this.Font);
		float textX = x - textSize.Width / 2;
		float textY = y - textSize.Height / 2;

		using (StringFormat sf = new StringFormat())
		{
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			g.DrawString(nodeText, this.Font, Brushes.Black, nodeRect, sf);
		}

		int leftChildIndex = 2 * index + 1;
		int rightChildIndex = 2 * index + 2;

		if (leftChildIndex < heap.Count)
		{
			var leftX = x - xOffset;
			var leftY = y + 80;
			g.DrawLine(Pens.Black, x, y + 30, leftX, leftY - 30);
			DrawHeap(g, heap, leftChildIndex, leftX, leftY, xOffset / 2, priorityMap);
		}

		if (rightChildIndex < heap.Count)
		{
			var rightX = x + xOffset;
			var rightY = y + 80;
			g.DrawLine(Pens.Black, x, y + 30, rightX, rightY - 30);
			DrawHeap(g, heap, rightChildIndex, rightX, rightY, xOffset / 2, priorityMap);
		}
	}

	private void pnlHeap_Paint(object sender, PaintEventArgs e)
	{
		if (!isMuayeneSirasiGosterildi) return;

		var heapList = muayeneHeap.GetHeap();
		var sortedHeapList = heapList.OrderByDescending(h => h.OncelikPuani).ToList();
		var priorityMap = new Dictionary<Hasta, int>();

		for (int i = 0; i < sortedHeapList.Count; i++)
		{
			priorityMap[sortedHeapList[i]] = i + 1;
		}

		int initialX = pnlHeap.Width / 2;
		int initialY = 40;
		DrawHeap(e.Graphics, heapList, 0, initialX, initialY, pnlHeap.Width / 4, priorityMap);
	}

	private List<Hasta> YıgınaYeniHastaEkle()
	{
		List<Hasta> yeniHastalar = new List<Hasta>();

		while (HastaIndex < hastalar.Count && hastalar[HastaIndex].HastaKayitSaati <= muayeneBaslangicSaati)
		{
			var hasta = hastalar[HastaIndex];
			muayeneHeap.Ekle(hasta);
			yeniHastalar.Add(hasta);
			HastaIndex++;
		}

		return yeniHastalar;
	}

	private List<Hasta> OkuHastaBilgileri(string x)
	{
		List<Hasta> hastalar = new List<Hasta>();
		string[] satirlar = File.ReadAllLines(x);

		foreach (var satir in satirlar)
		{
			if (string.IsNullOrWhiteSpace(satir)) continue;

			string[] bilgiler = satir.Split(',');

			if (bilgiler.Length < 11)
			{
				Console.WriteLine($"Hatalı satır: {satir}");
				continue;
			}

			try
			{
				string hastaAdi = bilgiler[1].Trim();
				int hastaYasi = int.Parse(bilgiler[2].Trim());
				char cinsiyet = char.Parse(bilgiler[3].Trim());
				bool mahkumlukDurumBilgisi = bool.Parse(bilgiler[4].Trim());
				int engellilikOrani = int.Parse(bilgiler[5].Trim());
				string kanamaliHastaDurumBilgisi = bilgiler[6].Trim();
				DateTime hastaKayitSaati;

				if (!DateTime.TryParseExact(bilgiler[7].Trim(), "HH.mm", null, System.Globalization.DateTimeStyles.None, out hastaKayitSaati))
				{
					Console.WriteLine($"Hatalı saat formatı: {bilgiler[7].Trim()}");
					continue;
				}

				Hasta yeniHasta = new Hasta(0, hastaAdi, hastaYasi, cinsiyet, mahkumlukDurumBilgisi, engellilikOrani, kanamaliHastaDurumBilgisi, hastaKayitSaati);
				hastalar.Add(yeniHasta);
			}
			catch (FormatException ex)
			{
				Console.WriteLine($"Hatalı format: {satir} - {ex.Message}");
			}
		}

		return hastalar;
	}

	private void HastaNum(List<Hasta> hastalar)
	{
		var HastalarSırala = hastalar.OrderBy(h => h.HastaKayitSaati).ToList();
		for (int i = 0; i < HastalarSırala.Count; i++)
		{
			HastalarSırala[i].HastaNo = i + 1;
		}
	}
}
