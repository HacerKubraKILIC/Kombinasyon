using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Test
{

    public static void Main()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        int satir = 0;
        int enAz = 0;

        string yazi = null;
        string[] yaziSplit = null;

        List<List<String>> TabloList = new List<List<String>>();
        TabloList.Add(new List<String>());
        TabloList.Add(new List<String>());
        TabloList.Add(new List<String>());
        TabloList.Add(new List<String>());
        TabloList.Add(new List<String>());

        try
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("C:\\Users\\Hacer\\Desktop\\ornek_veri_a.csv", Encoding.Default);

            yazi = sr.ReadLine();

            while (yazi != null)
            {
                if (satir > 1)
                {

                    yaziSplit = yazi.Split(';');

                    if (!yaziSplit[0].Equals(""))
                        TabloList[0].Add(yaziSplit[0]);

                    if (!yaziSplit[1].Equals(""))
                        TabloList[1].Add(yaziSplit[1]);

                    if (!yaziSplit[2].Equals(""))
                        TabloList[2].Add(yaziSplit[2]);

                    if (!yaziSplit[3].Equals(""))
                        TabloList[3].Add(yaziSplit[3]);

                    if (!yaziSplit[4].Equals(""))
                        TabloList[4].Add(yaziSplit[4]);

                }

                yazi = sr.ReadLine();
                satir++;

            }

            enAz = TabloList[0].Count;
            for (int j = 0; j < 4; j++)
            {
                if (TabloList[j].Count > TabloList[j + 1].Count && TabloList[j + 1].Count != 0)
                    enAz = TabloList[j + 1].Count;
            }

            for (int i = 0; i < 5; i++)
            {
                if (TabloList[i].Count == 0)
                {
                    for (int k = 0; k < enAz; k++)
                        TabloList[i].Add("");
                }

            }

            //Console.WriteLine(TabloList[0].Count +","+ TabloList[1].Count + ","+ TabloList[2].Count + ","+ TabloList[3].Count + ","+ TabloList[4].Count + ",");
            //Console.WriteLine(TabloList[0][1] + ", " + TabloList[1][1] + ", " + TabloList[2][1] + ", " + TabloList[3][1] + ", " + TabloList[4][1]);

        }
        catch (IOException e)
        {
            Console.WriteLine("Dosya Okunamadı:");
            Console.WriteLine(e.Message);
        }

        yaz(TabloList);

        watch.Stop();
        var gecenZaman = watch.ElapsedMilliseconds;
        Console.WriteLine("Gecen Zaman : " + gecenZaman + " ms");

        Console.ReadLine();
    }

    public static void yaz(List<List<String>> TabloList)
    {
        int[] indis = new int[5] { 0, 0, 0, 0, 0 };
        int n = 5;
        int next = 0;

        while (true)
        {
            /*foreach (var item in indis)
            {
                Console.Write(item + "; ");
            }
            Console.Write(" // ");*/

            for (int sütun = 0; sütun < 5; sütun++)
            {
                Console.Write(TabloList[sütun][indis[sütun]] + ", ");
            }
            Console.WriteLine();

            next = n - 1;
            while (next >= 0 && (indis[next] + 1 >= TabloList[next].Count))
            {
                next -= 1;
            }

            // next degeri negatif olursa kombinasyonlar bitmistir. Ve döngüden cikilir. 
            if (next < 0)
                return;

            indis[next] += 1;

            for (int j = next + 1; j < n; j++)
            {
                indis[j] = 0;
            }
        }
    }
}