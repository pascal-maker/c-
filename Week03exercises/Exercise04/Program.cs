﻿namespace animal.models;
public class Animal
{
    public string Name { get; set; }

    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void MakeSound()
    {
        Console.WriteLine("Unknown Sound");
    }
}