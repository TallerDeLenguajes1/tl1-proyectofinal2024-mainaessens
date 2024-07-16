// using System;

// namespace CombateSimpson
// {
//     public class Combate
//     {
//         private Personaje jugador;
//         private Personaje enemigo;
//         private Random random = new Random();

//         public Combate(Personaje p1, Personaje p2)
//         {
//             jugador = p1;
//             enemigo = p2;
//             Console.WriteLine($"¡Comienza la batalla entre {jugador.Nombre} y {enemigo.Nombre}!");
//         }
//             Console.Clear();
//         public static void IniciarCombate(Personaje jugador, Personaje enemigo)
//         {

//             while (jugador.Salud > 0 && enemigo.Salud > 0)
//             {
//                 MostrarMenuCombate(jugador, enemigo);
//                 if (jugador.Salud <= 0 || enemigo.Salud <= 0)
//                     break;
//             }

//             if (jugador.Salud <= 0 && enemigo.Salud <= 0)
//             {
//                 Console.WriteLine("¡Es un empate!");
//             }
//             else if (jugador.Salud > 0)
//             {
//                 Console.WriteLine($"{jugador.Nombre} ha ganado la batalla!");
//             }
//             else
//             {
//                 Console.WriteLine($"{enemigo.Nombre} ha ganado la batalla!");
//             }
//         }

//         private static void MostrarMenuCombate(Personaje jugador, Personaje enemigo)
//         {
//             Console.WriteLine("Elige una opción:");
//             Console.WriteLine("1. Atacar");
//             Console.WriteLine("2. Defender");
//             Console.WriteLine("3. Rendirse");
//             Console.Write("Seleccione una opción: ");
//             string opcion = Console.ReadLine();

//             switch (opcion)
//             {
//                 case "1":
//                     Atacar(jugador, enemigo);
//                     break;
//                 case "2":
//                     Defender(jugador, enemigo);
//                     break;
//                 case "3":
//                     Console.WriteLine($"{jugador.Nombre} se ha rendido.");
//                     jugador.Salud = 0;
//                     break;
//                 default:
//                     Console.WriteLine("Opción no válida, intente nuevamente.");
//                     break;
//             }
//         }

//         private static void Atacar(Personaje atacante, Personaje defensor)
//         {
//             Random random = new Random();
//             int ataque = atacante.Destreza * atacante.Fuerza * atacante.Agresivo;
//             int efectividad = random.Next(1, 101);
//             int defensa = defensor.Inteligencia * defensor.Velocidad;
//             int dañoProvocado = ((ataque * efectividad) - defensa) / 500;
//             defensor.Salud -= dañoProvocado;
//             Console.WriteLine($"{atacante.Nombre} ha causado {dañoProvocado} de daño a {defensor.Nombre}. Salud restante de {defensor.Nombre}: {defensor.Salud}");
//         }

//         private static void Defender(Personaje defensor, Personaje atacante)
//         {
//             Random random = new Random();
//             int ataque = atacante.Destreza * atacante.Fuerza * atacante.Agresivo;
//             int efectividad = random.Next(1, 101);
//             int defensa = defensor.Inteligencia * defensor.Velocidad;
//             int dañoProvocado = ((ataque * efectividad) - defensa) / 500;
//             defensor.Salud -= dañoProvocado / 2;
//             Console.WriteLine($"{defensor.Nombre} se ha defendido. Ha recibido {dañoProvocado / 2} de daño. Salud restante: {defensor.Salud}");
//         }
//     }
// }
