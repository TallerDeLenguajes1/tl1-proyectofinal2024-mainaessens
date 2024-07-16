using Fabrica;
using System.Diagnostics;
using CombateSimpson;
using MenuSeleccionable;

namespace Start
{
    public static class GameRun
    {
        public static async Task EmpezarAJugar(List<string> historialGanadores)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Obteniendo personajes de la API...");
                List<CitaAPI> citasAPI = await CitaAPI.ObtenerCitasAPI(5);

                Console.WriteLine("Selecciona tu personaje:");
                string[] personajes = new string[citasAPI.Count];
                for (int i = 0; i < citasAPI.Count; i++)
                {
                    personajes[i] = citasAPI[i].Character;
                    //Console.WriteLine($"{i + 1}. {citasAPI[i].Character}");
                }

                int seleccion = Menu.MostrarMenu(personajes);
                CitaAPI citaSeleccionada = citasAPI[seleccion];

                string url = citaSeleccionada.Image;
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

                Personaje personajeUsuario = FabricaDePersonajes.CrearPersonaje(citaSeleccionada.Character);
                Personaje personajeMaquina = FabricaDePersonajes.CrearEnemigo();

                Combate combate = new Combate(personajeUsuario, personajeMaquina);
                string ganador = combate.IniciarCombate();

                if (ganador == personajeUsuario.Nombre)
            {   
            Console.ForegroundColor = ConsoleColor.Blue; 
            string[] cartel = {
   @"********      **     ****     **     **     *******     *******   *******",
  @"**//////**    ****   /**/**   /**    ****   /**////**   **/////** /**////** ",
 @"**      //    **//**  /**//**  /**   **//**  /**    /** **     //**/**   /** ",
@"/**           **  //** /** //** /**  **  //** /**    /**/**      /**/*******  ",
@"/**    ***** **********/**  //**/** **********/**    /**/**      /**/**///**  ",
@"//**  ////**/**//////**/**   //****/**//////**/**    ** //**     ** /**  //** ",
 @"//******** /**     /**/**    //***/**     /**/*******   //*******  /**   //**",
  @"////////  //      // //      /// //      // ///////     ///////   //     //" 
            }; 
            foreach (string linea in cartel)
        {
            Console.WriteLine(linea);
        }

            }else{
                Console.ForegroundColor = ConsoleColor.Red; 
                string[] cartel = {
@"*******  ******** *******   *******   ******** *******     *******   *******  ",
@"/**////**/**///// /**////** /**////** /**///// /**////**   **/////** /**////** ",
@"/**   /**/**      /**   /** /**    /**/**      /**    /** **     //**/**   /** ",
@"/******* /******* /*******  /**    /**/******* /**    /**/**      /**/*******  ",
@"/**////  /**////  /**///**  /**    /**/**////  /**    /**/**      /**/**///**  ",
@"/**      /**      /**  //** /**    ** /**      /**    ** //**     ** /**  //** ",
@"/**      /********/**   //**/*******  /********/*******   //*******  /**   //**",
@"//       //////// //     // ///////   //////// ///////     ///////   //     // "
                };
                foreach (string linea in cartel)
        {
            Console.WriteLine(linea);
        }

            }

                historialGanadores.Add(ganador);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR FATAL. Se detuvo la ejecución. " + ex.Message);
            }
        }
    }
}