namespace Mensajes
{
    public static class TerminalMensajes
    {
        public static void TituloJuego()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string[] letraASCII = {
                @"_____ .   . .___       __  . .    . .__   __   __  .   .  __",
                @"  |   |   | |         (__` | |\  /| |  \ (__` /  \ |\  | (__ ",
                @"  |   |---| |---         \ | | \/ | |__/    \ |  | | \ |    \",
                @"  |   |   | |___      \__/ | |    | |    \__/ \__/ |  \| \__/"
            };

            Console.WriteLine(letraASCII);
        }

        public static void GanaPierde(Personaje p1, string ganador){
            if (ganador == p1.Nombre)
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
        }
        public static void ErrorSalir()
        {
            Console.WriteLine("Ouch");
            Console.WriteLine("Saliendo del juego...");
            Environment.Exit(0);
        }
    }
}
