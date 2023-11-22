using ConsoleApp4;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using Microsoft.VisualBasic;

List<string> osvenyek = new List<string>();
StreamReader sr = new StreamReader("osvenyek.txt");
while (!sr.EndOfStream)
{
    osvenyek.Add(sr.ReadLine());
}


string dobasokString = File.ReadAllText("dobasok.txt");
string[] dobasok = dobasokString.Split(" ");

Console.WriteLine("2. feladat");
Console.WriteLine($"Dobások száma: {dobasok.Length}");
Console.WriteLine($"Ösvények száma: {osvenyek.Count}");



Console.WriteLine("3. feladat");
var pair = osvenyek.Select((Value, Index) => new { Value, Index }).Single(p => p.Value.Length == osvenyek.MaxBy(x => x.Length).Length);
Console.WriteLine($"Az egyik leghosszab a(z): {pair.Index + 1}. ösvény, hossza: {pair.Value.Length}");

Console.WriteLine("4. feladat");
Console.Write("Adja meg egy ösvény sorszámát: ");
//int valasztottOsveny = Convert.ToInt16(Console.ReadLine());
int valasztottOsveny =9;
valasztottOsveny -= 1;

Console.Write("Adja meg a játékosok számát: ");
//int jatekosokSzama = Convert.ToInt16(Console.ReadLine());
int jatekosokSzama = 5;
int[] jatekosokPozicioi = new int[5];



Console.WriteLine("5. feladat");
int m = 0; int e = 0; int v = 0;
foreach (char mezo in osvenyek[valasztottOsveny])
{
	if (mezo == 'M') { m++; }
	else if (mezo == 'E') { e++; }
    else if (mezo == 'V') { v++; }
}
Console.WriteLine($"M: {m}");
Console.WriteLine($"V: {v}");
Console.WriteLine($"E: {e}");



//6. feladat
StreamWriter sw = new StreamWriter("kulonleges.txt", append: true);
for (int i = 0; i < osvenyek[valasztottOsveny].Length; i++)
{
	if (osvenyek[valasztottOsveny][i] == 'E')
	{
		sw.WriteLine($"E \t {i}");
	}
    if (osvenyek[valasztottOsveny][i] == 'V')
    {
        sw.WriteLine($"V \t {i}");
    }
}
sw.Close();


List<int> tovabbjutok = new List<int>();
int valasztottPalyaHossza = osvenyek[valasztottOsveny].Length;
bool vege = false;
int kör = 0;
int dobasId = 0;
while (!vege)
{
    jatekosokPozicioi[0] += Convert.ToInt32(dobasok[dobasId]);
    dobasId++;

    jatekosokPozicioi[1] += Convert.ToInt32(dobasok[dobasId]);
    dobasId++;

    jatekosokPozicioi[2] += Convert.ToInt32(dobasok[dobasId]);
    dobasId++;

    jatekosokPozicioi[3] += Convert.ToInt32(dobasok[dobasId]);
    dobasId++;

    jatekosokPozicioi[4] += Convert.ToInt32(dobasok[dobasId]);
    dobasId++;

    kör++;

    if (jatekosokPozicioi[0] >= valasztottPalyaHossza) { tovabbjutok.Add(1); }
    if (jatekosokPozicioi[1] >= valasztottPalyaHossza) { tovabbjutok.Add(2); }
    if (jatekosokPozicioi[2] >= valasztottPalyaHossza) { tovabbjutok.Add(3); }
    if (jatekosokPozicioi[3] >= valasztottPalyaHossza) { tovabbjutok.Add(4); }
    if (jatekosokPozicioi[4] >= valasztottPalyaHossza) { tovabbjutok.Add(5); }

    if(tovabbjutok.Count > 0) { vege = true; }
}
string tovabbjutokstring = "";
foreach (var item in tovabbjutok)
{
    tovabbjutokstring += $"{item} ";
}
Console.WriteLine("7. feladat");
Console.WriteLine($"A játék a(z) {kör}. körben ért véget. A legtávolabb jutó(k) sorszáma: {tovabbjutokstring}");



List<int> JatekosokPozicioi = new List<int>();
List<int> Nyertesek = new List<int>();
Dictionary<int, int> Vesztesek = new Dictionary<int, int>();
dobasId = 0;
kör = 0;
string jatekOsveny = osvenyek[valasztottOsveny];

bool rendesJatekVege = false;
while (!rendesJatekVege)
{
    jatekosokPozicioi[0] += Convert.ToInt32(dobasok[dobasId]);
    if (jatekOsveny[jatekosokPozicioi[0]] == 'E')
        jatekosokPozicioi[0] += Convert.ToInt32(dobasok[dobasId]);
    else if (jatekOsveny[jatekosokPozicioi[0]] == 'V')
        jatekosokPozicioi[0] -= Convert.ToInt32(dobasok[dobasId]);
    dobasId++;

    jatekosokPozicioi[1] += Convert.ToInt32(dobasok[dobasId]);
    if (jatekOsveny[jatekosokPozicioi[0]] == 'E')
        jatekosokPozicioi[1] += Convert.ToInt32(dobasok[dobasId]);
    else if (jatekOsveny[jatekosokPozicioi[0]] == 'V')
        jatekosokPozicioi[1] -= Convert.ToInt32(dobasok[dobasId]);
    dobasId++;

    jatekosokPozicioi[2] += Convert.ToInt32(dobasok[dobasId]);
    if (jatekOsveny[jatekosokPozicioi[0]] == 'E')
        jatekosokPozicioi[2] += Convert.ToInt32(dobasok[dobasId]);
    else if (jatekOsveny[jatekosokPozicioi[0]] == 'V')
        jatekosokPozicioi[2] -= Convert.ToInt32(dobasok[dobasId]);
    dobasId++;

    jatekosokPozicioi[3] += Convert.ToInt32(dobasok[dobasId]);
    if (jatekOsveny[jatekosokPozicioi[0]] == 'E')
        jatekosokPozicioi[3] += Convert.ToInt32(dobasok[dobasId]);
    else if (jatekOsveny[jatekosokPozicioi[0]] == 'V')
        jatekosokPozicioi[3] -= Convert.ToInt32(dobasok[dobasId]);
    dobasId++;

    jatekosokPozicioi[4] += Convert.ToInt32(dobasok[dobasId]);
    if (jatekOsveny[jatekosokPozicioi[0]] == 'E')
        jatekosokPozicioi[4] += Convert.ToInt32(dobasok[dobasId]);
    else if (jatekOsveny[jatekosokPozicioi[0]] == 'V')
        jatekosokPozicioi[4] -= Convert.ToInt32(dobasok[dobasId]);
    dobasId++;

    kör++;

    if (jatekosokPozicioi[0] >= valasztottPalyaHossza) { Nyertesek.Add(1);}
    else { Vesztesek.Add(1)}
    if (jatekosokPozicioi[1] >= valasztottPalyaHossza) { Nyertesek.Add(2);}
    if (jatekosokPozicioi[2] >= valasztottPalyaHossza) { Nyertesek.Add(3);}
    if (jatekosokPozicioi[3] >= valasztottPalyaHossza) { Nyertesek.Add(4);}
    if (jatekosokPozicioi[4] >= valasztottPalyaHossza) { Nyertesek.Add(5);}

    if (Nyertesek.Count > 0)
    {
        rendesJatekVege = true;
    }
}

string nyertesekstring = "";
foreach (var item in tovabbjutok)
{
    nyertesekstring += $"{item} ";
}
Console.WriteLine("8. feladat");
Console.WriteLine($"Nyertes(ek): {nyertesekstring}");
Console.WriteLine("A többiek poziciója:");
foreach (var item in Vesztesek)
{
    Console.WriteLine($"{item}. játékos, {}. mező");
}