// See https://aka.ms/new-console-template for more information
using System;

    try
    {
        Console.WriteLine("Masukan sebuah angka");
        int angka = int.Parse(Console.ReadLine());
        Console.WriteLine("Anda memasukkan : " + angka.ToString());
    }
    catch(Exception e)
    {
        Console.WriteLine("Error" + e.Message);
    }
    Console.ReadLine();