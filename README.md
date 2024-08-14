# LOS SIMPSONS: INVASIÓN TERRESTRE

## Presentación del Juego

### Bienvenido a Springfield, ayúdanos a defender la ciudad de una invasión extraterrestre

Este juego te invita a unirte a los personajes de Los Simpsons para enfrentar una invasión alienígena en Springfield. A través de emocionantes desafíos y batallas, tendrás la oportunidad de salvar la ciudad de esta amenaza extraterrestre. ¡Prepárate para sumergirte en el mundo de Los Simpsons y demostrar tus habilidades!

**Nota: El juego está diseñado para funcionar únicamente en Windows (consulta la sección Implementación -> Requisitos para más detalles).**

## Funcionamiento del Juego

Al iniciar el juego, serás recibido con un menú principal donde podrás elegir entre jugar una nueva partida o ver el historial de ganadores. Una vez que comiences, deberás seleccionar tu personaje e iniciar la batalla contra los invasores alienígenas. Si sales victorioso, tu nombre y logros serán guardados en el historial de ganadores, donde podrás consultarlos más tarde.

El juego está basado en la suerte y las decisiones estratégicas que tomes durante cada batalla. Al enfrentarte a los extraterrestres, podrás elegir entre diferentes acciones como atacar, defenderte, o realizar un ataque especial. ¡Cada movimiento cuenta para salvar Springfield!

## Implementación

### Utilización de la API
En el juego, implementé una API de Los Simpsons que proporciona nombres de personajes, sus frases icónicas y una imagen de cada uno. Esto añade un elemento dinámico y entretenido al juego, permitiendo que todos los personajes de la serie sean seleccionables. Puedes explorar la API aquí: [Simpsons Quote API](https://thesimpsonsquoteapi.glitch.me/quotes). Para acceder a la API es necesario agregar esta línea de código a su llamada: client.DefaultRequestHeaders.Add("User-Agent", "C# App"); 

### Archivos JSON para Historial de Ganadores
Para almacenar y recuperar el historial de ganadores, se utiliza un archivo JSON. Cada vez que un jugador gana una partida, su información se guarda en este archivo, permitiendo su consulta posterior a través del menú principal. Este historial incluye el nombre del ganador, la fecha de la victoria, y el nivel alcanzado.

### Interfaz por Consola
El juego presenta una interfaz en consola, utilizando arte ASCII para el título y otros elementos visuales. Esto le da un toque retro en línea con la estética de la serie Los Simpsons.

### Animaciones
El título del juego se presenta con una animación en consola que utiliza efectos de desplazamiento y colores para resaltar la experiencia visual. Me inspiré en este video de Youtube para hacer la animación de las nubes: https://youtu.be/02V8ab8OrLw

### Música
El audio en nuestro programa juega un papel crucial para mejorar la experiencia del usuario, creando una atmósfera inmersiva. Para poder reproducir el sonido en este programa utilicé NAudio que es una poderosa librería de audio para .NET que facilita la manipulación y reproducción de archivos de audio en diversas aplicaciones. 


## Requisitos:
*1. Tener instalado .Net versión 8.0 en su PC. Si no lo tiene descargado puede hacerlo desde [aqui](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)*  
*2. Tener instalada la librería NAudio.Wave en su PC. Se instala abriendo la terminal y ejecutando este código Install-Package NAudio*  
*3. Clonar el repositorio actual desde una terminal de VisualStudioCode o desde la Bash de Git con el siguiente comando:*  
``` bash
    git clone https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-mainaessens
``` 
*De esta forma se descargará todo el juego en una carpeta con el nombre tl1-proyectofinal2024-mainaessens*  
*Luego debe abrir dicha carpeta con VisualStudioCode, abrir una nueva terminal y ejecutar el siguiente comando:*  
``` bash
    dotnet run
```

### Conclusión
Los Simpsons: Invasión Terrestre es un juego que combina estrategia, suerte y nostalgia en un entorno basado en la icónica serie de televisión. Gracias a su sencilla implementación en consola, el juego es fácil de jugar y ofrece una experiencia entretenida para los fanáticos de la serie y los videojuegos retro.