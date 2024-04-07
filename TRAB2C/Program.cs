using System;

// DERECHOS DE AUTOR: VALENTINA YEPES
class Pokemon
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Salud { get; set; }
    public int[] Ataques { get; set; }
    public int[] Defensas { get; set; }
    private Random rand = new Random();

    public Pokemon(string nombre, string tipo)
    {
        Nombre = nombre;
        Tipo = tipo;
        Salud = 100;
        Ataques = new int[3];
        Defensas = new int[2];

        for (int i = 0; i < 3; i++)
        {
            Ataques[i] = rand.Next(0, 41);
        }

        for (int i = 0; i < 2; i++)
        {
            Defensas[i] = rand.Next(10, 36);
        }
    }

    public double Atacar()
    {
        int selectAttack = rand.Next(0, 3); 
        double multiplicador = (rand.Next(0, 2) == 0) ? 1.0 : 1.5;
        return Ataques[selectAttack] * multiplicador;
    }

    public double Defender()
    {
        int defense = rand.Next(0, 2); 
        double multiplicador = (rand.Next(0, 2) == 0) ? 1.0 : 0.5;
        return Defensas[defense] * multiplicador;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Creando Pokemon 1 ");
        Pokemon pokemon1 = CreatePokemon();

        Console.WriteLine("Creando Pokemon 2 ");
        Pokemon pokemon2 = CreatePokemon();

        Console.WriteLine("------------------------------ \nCOMIENZAAAA LA GRANNNN PELEAAA FINALLLL \n -----------------------------");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"--------------\nTurno {i + 1}:");
            Console.WriteLine($"{pokemon1.Nombre} da un gran ataque a {pokemon2.Nombre}.");
            double ataquePokemon1 = pokemon1.Atacar();
            Console.WriteLine($"{pokemon1.Nombre} hizo un daño total de: {ataquePokemon1}");
            double defensaPokemon2 = pokemon2.Defender();

            if (defensaPokemon2 >= ataquePokemon1)
            {
                pokemon2.Salud -= (int)(defensaPokemon2 - ataquePokemon1);
            }
            else
            {
                pokemon2.Salud -= (int)(ataquePokemon1 - defensaPokemon2);
            }

            Console.WriteLine($"{pokemon2.Nombre} contraataca haciendole daño a {pokemon1.Nombre}.");
            double ataquePokemon2 = pokemon2.Atacar();
            Console.WriteLine($"{pokemon2.Nombre} hizo un daño total de: {ataquePokemon2}");
            double defensaPokemon1 = pokemon1.Defender();

            if (defensaPokemon1 >= ataquePokemon2)
            {
                pokemon1.Salud -= (int)(defensaPokemon1 - ataquePokemon2);
            }
            else
            {
                pokemon1.Salud -= (int)(ataquePokemon2 - defensaPokemon1);
            }

            Console.WriteLine($"{pokemon1.Nombre} tiene {pokemon1.Salud} de salud.");
            Console.WriteLine($"{pokemon2.Nombre} tiene {pokemon2.Salud} de salud.");
        }

        if (pokemon1.Salud > pokemon2.Salud)
        {
            Console.WriteLine($"----------------\n{pokemon1.Nombre} es el ganador\n---------------");
        }
        else if (pokemon2.Salud > pokemon1.Salud)
        {
            Console.WriteLine($"----------------\n{pokemon2.Nombre} es el ganador\n---------------");
        }
        else
        {
            Console.WriteLine("---------------\nEs un empate entre los dos pokemones\n--------------");
        }
        Console.WriteLine($"Los ataques de {pokemon1.Nombre}:");
        foreach (var ataque in pokemon1.Ataques)
        {
            Console.WriteLine($"- {ataque}");

        }
        Console.WriteLine($"Las defensas de {pokemon1.Nombre}:");
        foreach (var defensa in pokemon1.Defensas)
        {
            Console.WriteLine($"- {defensa}");

        }
        Console.WriteLine($"Los ataques de {pokemon2.Nombre}:");
        foreach (var ataque in pokemon2.Ataques)
        {
            Console.WriteLine($"- {ataque}");
        }
        Console.WriteLine($"Las defensas de {pokemon2.Nombre}:");
        foreach (var defensa in pokemon2.Defensas)
        {
            Console.WriteLine($"- {defensa}");

        }
    }

    static Pokemon CreatePokemon()
    {
        Console.Write("Ingrese el nombre del Pokémon: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingresa el tipo del Pokémon: ");
        string tipo = Console.ReadLine();

        return new Pokemon(nombre, tipo);
    }
}
