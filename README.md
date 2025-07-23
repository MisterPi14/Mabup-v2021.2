\# Mabup-v2021.2



\## Descripción general



\*\*MABUP\*\* es una plataforma web educativa desarrollada en \*\*ASP.NET Core 3.1 (C# 8.0)\*\* que integra varias herramientas para apoyar a estudiantes en la gestión de tareas, el acceso a recursos multimedia por materia, y la colaboración mediante foros de discusión. El sistema permite a los usuarios registrarse, iniciar sesión, gestionar sus tareas académicas, participar en foros temáticos y acceder a videos educativos organizados por materias.



---



\## Funcionalidades principales



1\.  \*\*Autenticación y registro de usuarios\*\*

&nbsp;   \* Registro de nuevos usuarios con validación de datos y confirmación de contraseña.

&nbsp;   \* Inicio de sesión con validación contra base de datos.

&nbsp;   \* Estimación de tiempo promedio para tareas, usado para personalizar la experiencia.



2\.  \*\*Gestor de tareas\*\*

&nbsp;   \* Visualización de tareas pendientes por usuario.

&nbsp;   \* Agregar nuevas tareas con título, fecha/hora de entrega, materia, dificultad y tema.

&nbsp;   \* Marcar tareas como completadas.



3\.  \*\*Servicio de streaming educativo\*\*

&nbsp;   \* Panel de selección de materias (Matemáticas, Física, Química, Biología, Psicología Educativa, Geografía, Inglés, Cuidado del medio ambiente).

&nbsp;   \* Selección de temas específicos dentro de cada materia.

&nbsp;   \* Reproductor de videos educativos asociados a cada tema.



4\.  \*\*Foro de discusión\*\*

&nbsp;   \* Búsqueda y listado de foros existentes, mostrando tema, materia y autor.

&nbsp;   \* Creación de nuevos foros, asociando tema y materia.

&nbsp;   \* Acceso a foros para visualizar y participar en discusiones.

&nbsp;   \* Publicación de comentarios en los foros, con registro de autor y fecha/hora.



5\.  \*\*Navegación y experiencia de usuario\*\*

&nbsp;   \* Ventana principal personalizada tras el inicio de sesión, con acceso rápido a gestor de tareas, foros y streaming.

&nbsp;   \* Interfaz visual amigable y adaptada a estudiantes.



---



\## Estructura del proyecto



\* \*\*Controllers\*\*: Lógica de negocio y manejo de rutas para autenticación, gestor de tareas, foros y streaming.

\* \*\*Models\*\*: Modelos de datos para usuarios, tareas, foros, comentarios, materias y videos.

\* \*\*Views\*\*: Vistas Razor para cada funcionalidad, incluyendo formularios, paneles y reproductores.

\* \*\*wwwroot\*\*: Recursos estáticos como imágenes, CSS y librerías JS (Bootstrap, jQuery Validation).



---



\## Cómo instalar el software Mabup-v2021.2 localmente



Esta guía detalla el procedimiento para la instalación y configuración de \*\*Mabup-v2021.2\*\* para su ejecución en un entorno de máquina local. La operación de la aplicación en este modo es autónoma, no requiriendo de servicios externos o infraestructura de servidor remota. La funcionalidad y estabilidad de Mabup-v2021.2 están directamente condicionadas por la preexistencia y correcta configuración de diversas dependencias de software en el sistema operativo anfitrión.



\### Dependencias de Software



La correcta ejecución de Mabup-v2021.2 requiere la disponibilidad de los siguientes componentes en el sistema local:



\#### 1. Runtimes de .NET Core



Mabup-v2021.2 está construida sobre la plataforma .NET Core, por lo que requiere entornos de ejecución específicos para operar.



\* \*\*Microsoft.NETCore.App 3.1.0:\*\*

&nbsp;   Este es el runtime fundamental de .NET Core versión 3.1.0. Proporciona el entorno de ejecución (CoreCLR) y el conjunto de bibliotecas de clases base (BCL) que son esenciales para la carga y ejecución de cualquier aplicación .NET Core. Su función es similar a la de una máquina virtual ligera que interpreta y ejecuta el código compilado de la aplicación.

&nbsp;   \* \*\*Descarga:\*\* \[https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-3.1.0-windows-x64-installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-3.1.0-windows-x64-installer)



\* \*\*Microsoft.AspNetCore.App 3.1.0:\*\*

&nbsp;   Este runtime extiende el ambiente de .NET Core con componentes específicos de ASP.NET Core. Incluye bibliotecas para el desarrollo de aplicaciones web y servicios, lo que indica que Mabup-v2021.2 utiliza funcionalidades relacionadas con interfaces de usuario web (por ejemplo, Blazor o Razor Pages embebidos) o servicios de comunicación basados en el framework ASP.NET Core, incluso para su operación local.

&nbsp;   \* \*\*Descarga:\*\* \[https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-3.1.0-windows-x64-installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-3.1.0-windows-x64-installer)



\#### 2. Instancia de Base de Datos Local



Mabup-v2021.2 requiere una base de datos para la persistencia de datos operativos y de configuración.



\* \*\*Microsoft SQL Server 2019 LocalDB:\*\*

&nbsp;   LocalDB es una variante ligera del motor de base de datos SQL Server Express, optimizada para escenarios de desarrollo, pruebas y despliegues de aplicaciones locales que necesitan una base de datos relacional. Se ejecuta como un proceso de usuario bajo demanda, sin la complejidad de una instalación completa de SQL Server, lo que lo hace ideal para entornos de máquina local. Mabup-v2021.2 se conectará a esta instancia de LocalDB para almacenar y recuperar sus datos.

&nbsp;   \* \*\*Adquisición:\*\* LocalDB suele distribuirse como un componente seleccionable dentro de los instaladores de \*\*SQL Server Express\*\* o se incluye con la suite de herramientas de desarrollo de Microsoft, como \*\*Visual Studio 2022 Community\*\*.



\#### 3. Entorno de Desarrollo y Herramientas



La siguiente herramienta es fundamental para la adquisición de algunas dependencias y para el entorno general de trabajo.



\* \*\*Visual Studio 2022 Community:\*\*

&nbsp;   Este es el Entorno de Desarrollo Integrado (IDE) principal de Microsoft. Su instalación es crucial por varias razones:

&nbsp;   \* \*\*Adquisición de LocalDB:\*\* A menudo, Visual Studio proporciona la manera más sencilla de instalar y configurar SQL Server LocalDB y sus herramientas de administración asociadas (como SQL Server Object Explorer).

&nbsp;   \* \*\*SDKs y Herramientas:\*\* Puede incluir o facilitar la instalación de SDKs de .NET adicionales, herramientas de compilación y componentes que, aunque no sean estrictamente runtimes, pueden ser necesarios para el correcto funcionamiento o despliegue de Mabup-v2021.2, especialmente si la aplicación interactúa con otros servicios o componentes de la plataforma .NET que requieren herramientas específicas.



\### Verificación de la Instalación de Dependencias



Una vez ejecutados los instaladores correspondientes a cada dependencia, se recomienda verificar su correcta integración en el sistema:



\#### Verificación de Runtimes de .NET



Confirme la existencia de los siguientes directorios en el sistema de archivos, los cuales albergan los componentes del runtime:



\* `C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\3.1.0`

\* `C:\\Program Files\\dotnet\\shared\\Microsoft.AspNetCore.App\\3.1.0`



\#### Verificación de Microsoft SQL Server 2019 LocalDB



La presencia de Microsoft SQL Server 2019 LocalDB puede confirmarse mediante:



\* La lista de "Aplicaciones y características" en la configuración de Windows.

\* Intentando iniciar una conexión de base de datos a la instancia `(localdb)\\mssqllocaldb` a través de herramientas como SQL Server Management Studio (SSMS) o el Explorador de objetos de SQL Server dentro de Visual Studio.

\* La capacidad de la aplicación Mabup-v2021.2 para inicializar y conectarse a su base de datos local al ser ejecutada.



\#### Verificación de Visual Studio 2022 Community



Confirme la correcta instalación de Visual Studio 2022 Community mediante:



\* Su listado en "Aplicaciones y características" de Windows.

\* La capacidad de iniciar el IDE desde el menú de inicio y acceder a sus funcionalidades principales, incluyendo el Explorador de objetos de SQL Server si se instaló con el componente de desarrollo de datos.



Con todas estas dependencias correctamente instaladas y verificadas, el entorno estará configurado adecuadamente para la implementación y ejecución de Mabup-v2021.2.

