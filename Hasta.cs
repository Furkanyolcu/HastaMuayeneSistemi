using System; 

public class Hasta
{
	public int HastaNo { get; set; } 
	public string HastaAdi { get; set; }
	public int HastaYasi { get; set; }
	public char Cinsiyet { get; set; } 
	public bool MahkumlukDurumBilgisi { get; set; } 
	public int EngellilikOrani { get; set; }
	public string KanamaliHastaDurumBilgisi { get; set; } 
	public DateTime HastaKayitSaati { get; set; } 
	public DateTime? MuayeneSaati { get; set; } 
	public int MuayeneSuresi { get; set; } 
	public int OncelikPuani { get; set; }

	public Hasta(int hastaNo, string hastaAdi, int hastaYasi, char cinsiyet, bool mahkumlukDurumBilgisi, int engellilikOrani, string kanamaliHastaDurumBilgisi, DateTime hastaKayitSaati)
	{
		HastaNo = hastaNo;
		HastaAdi = hastaAdi; 
		HastaYasi = hastaYasi; 
		Cinsiyet = cinsiyet; 
		MahkumlukDurumBilgisi = mahkumlukDurumBilgisi; 
		EngellilikOrani = engellilikOrani; 
		KanamaliHastaDurumBilgisi = kanamaliHastaDurumBilgisi;
		HastaKayitSaati = hastaKayitSaati;
		OncelikPuani = oncelikPuaniHesapla(); 
		MuayeneSuresi = muayeneSuresiHesapla();
	}

	private int oncelikPuaniHesapla()
	{
		int yasPuani;

		if (HastaYasi < 5)
		{
			yasPuani = 20;
		}
		else if (HastaYasi < 45)
		{
			yasPuani = 0;
		}
		else if (HastaYasi < 65)
		{
			yasPuani = 15;
		}
		else
		{
			yasPuani = 25;
		}

		int engellilikPuani = EngellilikOrani / 4;
		int mahkumlukPuani = MahkumlukDurumBilgisi ? 50 : 0;

		int kanamaliHastaPuani;
		if (KanamaliHastaDurumBilgisi == "agirKanama")
		{
			kanamaliHastaPuani = 50;
		}
		else if (KanamaliHastaDurumBilgisi == "kanama")
		{
			kanamaliHastaPuani = 20;
		}
		else
		{
			kanamaliHastaPuani = 0;
		}

		return yasPuani + engellilikPuani + mahkumlukPuani + kanamaliHastaPuani;
	}

	private int muayeneSuresiHesapla()
	{
		int yasPuani = HastaYasi < 65 ? 0 : 15; 
		int engellilikPuani = EngellilikOrani / 5;

		int kanamaliHastaPuani;
		if (KanamaliHastaDurumBilgisi == "agirKanama")
		{
			kanamaliHastaPuani = 20; 
		}
		else if (KanamaliHastaDurumBilgisi == "kanama")
		{
			kanamaliHastaPuani = 10;
		}
		else
		{
			kanamaliHastaPuani = 0;
		}

		return yasPuani + engellilikPuani + kanamaliHastaPuani + 10;
	}
}
