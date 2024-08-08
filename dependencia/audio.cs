using NAudio.Wave;
using Mensajes;
using MenuSeleccionable;

namespace Musica
{
    public class Audio
    {
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;
        private bool isMusicPlaying;

        public Audio(string audioFilePath)
        {
            try
            {
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader(audioFilePath);
                waveOut.Init(audioFileReader);
                isMusicPlaying = false;
            }
            catch (Exception ex)
            {
                TerminalMensajes.CentradorDeTexto($"Error al cargar el archivo de audio: {ex.Message}");
            }
        }

        public void PlayMusic()
        {
            if (waveOut == null || audioFileReader == null)
            {
                TerminalMensajes.CentradorDeTexto("No se ha cargado ningún archivo de audio.");
                return;
            }

            if (!isMusicPlaying)
            {
                waveOut.Play();
                isMusicPlaying = true;
            }
        }

        public void StopMusic()
        {
            if (waveOut == null || audioFileReader == null)
            {
                TerminalMensajes.CentradorDeTexto("No se ha cargado ningún archivo de audio.");
                return;
            }

            if (isMusicPlaying)
            {
                waveOut.Stop();
                isMusicPlaying = false;
            }
        }

        public static void MostrarOpcionesMusica()
        {
            Console.Clear();
            string audioFilePath = "recursos/path_to_your_simpsons_music.mp3"; // Asegúrate de tener el archivo WAV adecuado en la ruta especificada
            Audio audio = new Audio(audioFilePath);
            audio.PlayMusic();
            TerminalMensajes.Animaciones.Intro();
            string[] opciones = { "Mute", "Continuar"};
            int seleccion = Menu.MostrarMenu(opciones);

            switch (seleccion)
            {
                case 0:
                    audio.StopMusic();
                    break;
                case 1:
                    audio.PlayMusic();
                    break;
                default:
                    TerminalMensajes.CentradorDeTexto("Opción inválida. Intenta nuevamente.");
                    break;
            }
            TerminalMensajes.CentradorDeTexto("Presione una tecla para ir al menú principal");
            System.Threading.Thread.Sleep(2000);  // Pausa de 2 segundos (2000 milisegundos)
            Console.ReadKey();  // Espera a que el usuario presione una tecla
            Console.Clear();
        }
    }
}
