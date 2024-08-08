using Ganadores; 
using Start;
using MenuSeleccionable; 
using Musica; 

namespace Mensajes
{
    public static class TerminalMensajes
    {   
    public static class Animaciones
{
    public static void Intro()
    {
        Console.Title = "Animación de Los Simpsons";
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        Console.CursorVisible = false;

         string[] cartel = {
                                 @"___    _",
                                  @"| |_||_",
      @"sssSSSSSs                   | | ||_",
   @"sSSSSSSSSSSSs                           sSSSSs             nn   sSSSs",
  @"SSSS           ii  mM     mmm   pPPPPpp sSS           nn    nn sSSSSSS",
 @"SSSs           iII mMMMM  mMmmm pPP  PpppSs      oOoo  nNN   nN SS   SS",
 @"SSSs           iII mMMMMM mM Mm Pp     PPSSSSs  OOOOOO NNNn nNN SSSs",
 @"SSSSSSSssss    iIi mMM MMmM  Mm ppPPppPP  SSSSsoO   OO NNNNNNNN  SSSSss",
    @"SSSSSSSSSs  iIi MMM  MMM  Mm PPPPppP      sSOO   OO NN  nNNN     SSSs",
          @"SSSS IIi  mMM  MMm  Mm  Pp   sSSssSSSSOO ooOO nN   NN        SS",
           @"sSS III   MM       MMm pPp    SSSSSS  OOOOO          sssssSsSS",
@"sSSsssssSSSSS   II                                               SSSSSSS TM",
  @"SSSSSSSSS",
        };

        string subtitle = "Invasión Extraterrestre";
        string[] cloud = {
            "    .-~~~-.",
            " .- ~ ~-(       )_ _",
            "/                     ~ -.",
            "|                           \\",
            "\\                         .'",
            "   ~- . _____________ . -~"
        };

        int subtitlePosX = (windowWidth - subtitle.Length) / 2;
        int[][] cloudPositions = {
            new int[] { 0, 0 },
            new int[] { 40, 1 },
            new int[] { 80, 2 }
        };

        bool allCloudsOut = false;

        while (!allCloudsOut)
        {
            Console.Clear();

            allCloudsOut = true; 

            for (int i = 0; i < cloudPositions.Length; i++)
            {
                int cloudX = cloudPositions[i][0];
                int cloudY = cloudPositions[i][1];

                if (cloudX < windowWidth)
                {
                    allCloudsOut = false; 
                }

                if (cloudX >= -cloud[0].Length && cloudX < windowWidth)
                {
                    for (int j = 0; j < cloud.Length; j++)
                    {
                        int yPos = cloudY + j;
                        if (yPos < windowHeight)
                        {
                            Console.SetCursorPosition(cloudX, yPos);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(cloud[j]);
                        }
                    }
                }

                cloudPositions[i][0] += 2;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            int titlePosY = (windowHeight - cartel.Length) / 2;

            foreach (string linea in cartel)
            {
                CentradorDeTitulo(linea, titlePosY);
                titlePosY++;
            }

            Console.SetCursorPosition(subtitlePosX, titlePosY + 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(subtitle);

            Thread.Sleep(50);
        }
    }
    private static void CentradorDeTitulo(string texto, int posY)
    {
        int windowWidth = Console.WindowWidth;
        int posX = (windowWidth - texto.Length) / 2;
        Console.SetCursorPosition(posX, posY);
        Console.WriteLine(texto);
    }
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

        Console.WriteLine("Iniciando pausa de 5 segundos...");
        Thread.Sleep(5000);  // Pausa de 5 segundos (5000 milisegundos)
        Console.WriteLine("Pausa terminada.");

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();  // Espera a que el usuario presione una tecla
        Console.WriteLine("Continuando...");
        Console.Clear(); 
        }
    public static void CentradorDeTexto(string texto){
                    int consoleWidth = Console.WindowWidth;
                    int marginLeft = (consoleWidth - texto.Length) / 2;
                    Console.SetCursorPosition(marginLeft, Console.CursorTop);
                    Console.WriteLine(texto);
        }
    public static void Niveles(int nivel){
        switch (nivel)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Blue; 
                    string[] cartel = {
                                @"▄▄    ▄ ▄▄▄ ▄▄   ▄▄ ▄▄▄▄▄▄▄ ▄▄▄        ▄▄▄▄",
                                @"█  █  █ █   █  █ █  █       █   █      █    █",
                                @"█   █▄█ █   █  █▄█  █    ▄▄▄█   █       █   █",
                                @"█       █   █       █   █▄▄▄█   █       █   █",
                                @"█  ▄    █   █       █    ▄▄▄█   █▄▄▄    █   █",
                                @"█ █ █   █   ██     ██   █▄▄▄█       █   █   █",
                                @"█▄█  █▄▄█▄▄▄█ █▄▄▄█ █▄▄▄▄▄▄▄█▄▄▄▄▄▄▄█   █▄▄▄█",  
        };
        foreach (string linea in cartel)
            {
                CentradorDeTexto(linea);
            }
            Thread.Sleep(3000);
            Console.ResetColor();
                    break;
                case 1:
                Console.ForegroundColor = ConsoleColor.Yellow;
                    string[] cartel1 = {
                                @"▄▄    ▄ ▄▄▄ ▄▄   ▄▄ ▄▄▄▄▄▄▄ ▄▄▄        ▄▄▄▄▄▄▄",
                                @"█  █  █ █   █  █ █  █       █   █      █       █",
                                @"█   █▄█ █   █  █▄█  █    ▄▄▄█   █      █▄▄▄▄   █",
                                @"█       █   █       █   █▄▄▄█   █       ▄▄▄▄█  █",
                                @"█  ▄    █   █       █    ▄▄▄█   █▄▄▄   █ ▄▄▄▄▄▄█",
                                @"█ █ █   █   ██     ██   █▄▄▄█       █  █ █▄▄▄▄▄",
                                @"█▄█  █▄▄█▄▄▄█ █▄▄▄█ █▄▄▄▄▄▄▄█▄▄▄▄▄▄▄█  █▄▄▄▄▄▄▄█",
        };
         foreach (string linea in cartel1)
            {
                CentradorDeTexto(linea);
            }
            Thread.Sleep(3000);
            Console.ResetColor();
                    break;
                case 2:
                Console.ForegroundColor = ConsoleColor.Magenta;
                    string[] cartel2 = {
                                @"▄▄    ▄ ▄▄▄ ▄▄   ▄▄ ▄▄▄▄▄▄▄ ▄▄▄        ▄▄▄▄▄▄▄",
                                @"█  █  █ █   █  █ █  █       █   █      █       █",
                                @"█   █▄█ █   █  █▄█  █    ▄▄▄█   █      █▄▄▄    █",
                                @"█       █   █       █   █▄▄▄█   █       ▄▄▄█   █",
                                @"█  ▄    █   █       █    ▄▄▄█   █▄▄▄   █▄▄▄    █",
                                @"█ █ █   █   ██     ██   █▄▄▄█       █   ▄▄▄█   █",
                                @"█▄█  █▄▄█▄▄▄█ █▄▄▄█ █▄▄▄▄▄▄▄█▄▄▄▄▄▄▄█  █▄▄▄▄▄▄▄█", 
        };
         foreach (string linea in cartel2)
            {
                CentradorDeTexto(linea);
            }
            Thread.Sleep(3000);
            Console.ResetColor();
                    break;
            }
    }
    }
}
 
//  string[] cartel = {
//                                  @"___    _",
//                                   @"| |_||_",
//       @"sssSSSSSs                   | | ||_",
//    @"sSSSSSSSSSSSs                           sSSSSs             nn   sSSSs",
//   @"SSSS           ii  mM     mmm   pPPPPpp sSS           nn    nn sSSSSSS",
//  @"SSSs           iII mMMMM  mMmmm pPP  PpppSs      oOoo  nNN   nN SS   SS",
//  @"SSSs           iII mMMMMM mM Mm Pp     PPSSSSs  OOOOOO NNNn nNN SSSs",
//  @"SSSSSSSssss    iIi mMM MMmM  Mm ppPPppPP  SSSSsoO   OO NNNNNNNN  SSSSss",
//     @"SSSSSSSSSs  iIi MMM  MMM  Mm PPPPppP      sSOO   OO NN  nNNN     SSSs",
//           @"SSSS IIi  mMM  MMm  Mm  Pp   sSSssSSSSOO ooOO nN   NN        SS",
//            @"sSS III   MM       MMm pPp    SSSSSS  OOOOO          sssssSsSS",
// @"sSSsssssSSSSS   II                                               SSSSSSS TM",
//   @"SSSSSSSSS",
//         };