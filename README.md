# ECG Viewer

ECG Viewer es un software de captura, manipulación, visualizacion, filtrado y sintesis de señales inicialmente pensado para señales electrocardiográficas, pero posteriormente adaptado a para aceptar todo tipo de señales, brindando herramientas para el desarrollo electrónico y la simulación en Proteus.  

![image](https://github.com/user-attachments/assets/08d9ec57-3848-43e0-8204-3f5dec5c4f16)  


# Funcionalidades


## Captura
La captura se realizará desde el puerto serie. Los datos que se capturarán del puerto deberán ser enviados como numeros enteros con un salto de linea despues del mismo (en arduino con Serial.println(valorEntero)) el valor no necesita tener ningun formato especial.
### Configuración del puerto
Antes de realizar la captura, deberá configurarse el puerto serie desde donde se realizará la misma. Para ello, debajo a la izquierda, se observará la sección de configuración de puerto. En ella se podrá seleccionar cualquier puerto disponible en Windows, seleccionar la velocidad de transmisión y seleccionar el intervalo de muestreo con el cual se enviará la muestra. Este ultimo es sumamente importante, porque en base a este intervalo de muestreo, el sistema calculará los valores de tiempo mostrados en el eje X.  

![image](https://github.com/user-attachments/assets/644a112c-60b3-483a-af2f-89eaa64f0fb6)  

### Inicio de captura
Para iniciar la lectura, presionar el boton "Iniciar Lectura". En ese momento, se borrará cualquier grafico presente en la grafica, y se comenzará a registrar los valores leidos por el puerto, utilizando la escala de eje Y que se haya elegido. Se recomienda utilizar al menos el principio, la escala automatica.
La visualizacion durante la captura solo mostrará un numero fijo maximo de muestras en pantalla (4000 por default), que iran avanzando conforme avance la captura. Durante la captura también podrá colocar marcadores (click derecho sobre el punto de interes) e ir guardando la captura si asi lo desea.

### Fin de captura
Para finalizar la captura, presionar el botón "Finalizar Lectura".


## Herramientas de visualización
Son las herramientas de mayor utilidad a la hora de analizar y modificar la gráfica.

### Zoom horizontal
El sistema cuenta unicamente con zoom horizontal y se encuentra habilitado por default. Para realizar zoom sobre una señal, alcanza sigtuarse sobre el lugar donde se quiere empezar a hacer zoom, presionar el boton izquierdo del mouse y sin soltar, desplazar hasta el final de la seccion a hacer zoom y soltar. 

### Reset Zoom
![image](https://github.com/user-attachments/assets/bf3bea98-9ce1-4428-b23b-9896dc4e26d2)  
Para deshacer el zoom, puede presionar el botón "Reset Zoom".  Permite deshacer el zoom, y mostrar toda la gráfica en una pantalla.

### Regla
![image](https://github.com/user-attachments/assets/5ef58ba3-0131-4918-b11e-10278c740235)  
Para activar la regla, deberá presionar el boton "Regla" en la barra de herramientas. El botón quedará presionado y mientras esté presionado, **la funcionalidad de Zoom permanecerá desactivada** para dejar paso a la de la regla.  
De manera similar al zoom, podrá seleccionar un area sobre el gráfico, en ella se visualizará un recuadro en donde se detallará con presición los valores del segmento de tiempo (horizontal) y de amplitud (vertical) encuadrada. Esta herramienta permitirá medir con mucha mayor precisión y rapidez estas variables que si se tratara de usar la escala del gráfico.
![image](https://github.com/user-attachments/assets/0bcbce39-1190-45cf-b2bc-47c223f85105)  

### Cursor
Con la función de regla, también se activa la función de Cursor. Si en lugar de seleccionar un area con el mouse, simplemente se hace clic en un punto de la gráfica, dicho punto de marcará con una interseccion de líneas y el valor exacto de dicho punto (tiempo y amplitud) se mostrará en la barra de herramientas.  
![image](https://github.com/user-attachments/assets/131a1514-c0f1-4bbd-8ac8-7f68dbb0f37a)  

### Marcadores
Para colocar marcas en el gráfico, dar **clic derecho** en la gráfica sobre el punto deseado. Esto colocará una linea punteada vertical marcando el lugar, y habilitará la posibilidad de ingresar un texto descriptivo sobre la marca.  
![image](https://github.com/user-attachments/assets/ad59da51-0a16-465e-859c-da38e1c15b4f)  
Dichos puntos quedarán fijos a la gráfica en la coordenada en la cual se creó.
Para editar/eliminar estos puntos, utilizar la función "Administrar Marcadores" de la barra de herramientas.  
![image](https://github.com/user-attachments/assets/b3f1c0f0-c44a-46ff-8d69-23f382bf49f2)

### Tijera
![image](https://github.com/user-attachments/assets/b8373be0-32d0-4e00-b460-7ec58e348629)  
La herramienta tijera sirve para recortar el gráfico en caso de querer conservar solo algun segmento de él. El recorte se hará en la porción visualizada del mismo, es decir, se deberá hacer zoom sobre la parte que se desee conservar, luego presionar el boton de la tijera para solo conservar dicha parte y descartar el resto. Al recortarlo, se preguntará si se desea reiniciar el tiempo a 0 en el comienzo del gráfico.

### Configuración de Ejes
![image](https://github.com/user-attachments/assets/be533484-1124-46a1-b46a-e31bfe62a9ad)  
Permite configurar si la escala en Y se configurará de manera automática, o bien, que escala se desea utilizar.  

![image](https://github.com/user-attachments/assets/bbddad3f-95af-430a-9fc0-cb6c06f2693b)  


## Herramientas de Importación y Exportación de datos  
En la barra de herramientas se encuentra la sección de herramientas de Importación y exportación de datos.  

![image](https://github.com/user-attachments/assets/d52e4166-11ff-4610-9b74-a109bb3ee0cd)  

Dichas herramientas se detallan a continuación

### 1-Importación desde archivo XLSX  
Permite importar datos desde archivos de Excel formato XLSX. Para que los archivos sean compatibles deben tener un formato determinado. 
* En la 1er columna de la izquierda, se deberán encontrar los valores de tiempo, con intervalos regulares entre celda y celda para que sea correctamente interpretado (es decir por ejemplo 1, 2, 3 o 0.5, 1.0, 1.5, etc).
* En la 2da columna se deberán encontrar los valores del eje Y. No se requiere nada en particular sobre estos valores.
A continuación se muestra un ejemplo.  
![image](https://github.com/user-attachments/assets/70e78bb9-0cd0-4d60-9787-7eca33d306e7)
* Adicionalmente de forma opcional si se desea, se puede poner **solo en cada celda de la primera fila** un titulo en la primer fila de cada columna, como por ejemplo "Tiempo" y "Valores". El programa simplemente los ignorará y cargará el resto de los datos normalmente.
Dicho archivo se interpretará como una señal capturada, lo cual después permitirá exportarla a Proteus para simularla, o bien a una tabla estilo C/C++ o assembler para sintetizarla.
### 2-Exportación a Excel formato XLSX
Permite exportar los datos capturados a formato excel para utilizarlo en otras aplicaciones. El formato de exportación es identico al solicitado en la "Importación de XLSX"
### 3-Exportación a tabla de C/C++
Esta función permite la sintesis de la señal en microcontroladores con compiladores escritos en C/C++ generando una tabla para incluir en el codigo fuente. La amplia mayoria de los microcontroladores comerciales poseen algun compilador en estos lenguajes. Mas adelante se dedicará una sección especial para esta herramienta.
### 4-Exportación a File generator de Proteus
Exporta la señal a un archivo compatible con el generador del tipo file de Proteus para poder incluirla en una simulación. Mas adleante se dedicará una sección epsecial a esta funcionalidad.

## Herramientas de Señal
En la parte inferior de la pantalla se encuentra la sección de "Análisis y filtrado de señal". En ellas se encuentran las herramientas fundamental para el estudio y el acondicionamiento de las mismas.  

### Filtro Pasabajo de 50Hz
![image](https://github.com/user-attachments/assets/9a5645d2-2bcd-45dc-b77f-893523b8e836)  
Dado que las frecuencias que mayor interferencias causan son las de red, las cuales normalmente suelen ser de 50Hz o 60Hz según el país, se dejan un acceso directo a un filtro pasa bajo de 49Hz, el cual descartará las frecuencias mayores a 49Hz, incluidas las mencionadas frecuencias.

### Filtros Avanzados
![image](https://github.com/user-attachments/assets/84db9460-2de0-49cb-a822-53cf61829dba)  
Permite acceder a la consola de filtros personalizados que se verá mas adelante.

### Vista de espectro
![image](https://github.com/user-attachments/assets/58efc593-cadb-4729-9af2-7d309107cfca)  
Permite visualizar el espectro de la señal, lo cual es de una gran utilidad para identificar señales de ruido que contaminan la señal original a analizar. A continuación se muestra el espectro de una señal ECG en la cual se observa una componente de 50Hz la cual es un claro ruido sobre la misma.
![image](https://github.com/user-attachments/assets/a70626df-9218-434a-adb7-cd47caf80782)  


# Consola de Filtros Avanzados
Como se mencionó en la sección [Filtros Avanzados](#Filtros Avanzados), la consola de filtros permite aplicar cualquier filtro que se necesite sobre la señal, permitiendo previsualizar sus resultados. El gran potencial de estos filtros radican en que se tratan de filtros digitales los cuales poseen una selectividad casi infinita, lo cual es imposible lograr con filtros analógicos (implementados a través del algoritmo de transformada rápida de Fourier).
![image](https://github.com/user-attachments/assets/a17fc2c9-6916-4ebe-86d6-2570afe26595)  

## Estructura de la ventana
En la parte superior de la ventana puede verse la señal original sin filtrar tal como se tomó de la ventana principal del programa. En la inferior se podrá ver como va quedando la señal luego de aplicarsele los filtros.
## Zoom
El zoom está siempre presente en el gráfico superior ("señal original"). Al aplicarse zoom sobre él, el grafico inferior ("señal filtrada") seguirá los mismos cambios de visualización y desplazamiento punto a punto para poder hacer una comparación exacta de los cambios.

## Barra de herramientas
En la barra de herramientas se encuentran todas las herramientas disponibles en esta versión
![image](https://github.com/user-attachments/assets/bc56fc0a-dea7-46f5-b35e-e74068647afa)  
1. Reset Zoom: Permite reestablecer el zoom para ver la señal completa en una sola pantalla.
2. Filtro Pasa Bajo: Permite aplicar un filtro pasa bajos a la señal, especificando la frecuencia de corte superior.
3. Filtro Pasa Alto: Permite aplicar un filtro pasa altos a la señal, especificando la frecuencia de corte inferior.
4. Filtro Pasa Banda: Permite aplicar un filtro pasa banda a la señal, especificando la frecuencia de corte inferior y superior.
5. Filtro Notch: Permite aplicar un filtro Notch a la señal, especificando la frecuencia de corte inferior y superior.
6. Reset Filtros: Permite deshacer los filtros aplicados y reestablecer la señal filtrada a como estaba originalmente cuando se abrió la consola.
7. Vista Tiempo/Frecuencia: Cambia las señales tanto original como filtrada por su espectro. Esta vista es de mucha utilidad para ver el resultado de los filtros y detectar anomalias a filtrar.
8. Aplicar: Permite aceptar todos los cambios realizados a la señal filtrada y aplicarla en la ventana principal del programa. Una vez aplicados los cambios, los mismos no tienen vuelta atras (excepto volviendo a capturar o a cargar nuevamente el archivo de la señal).
9. Cancelar: Permite abandonar la consola de filtros sin aplicar ningun cambio.

## Ejemplo de filtrado
En la siguiente imagen puede apreciarse la limpieza de la señal de ECG al notar la disminución del ruido en la señal filtrada. A la señal original se le aplicó un filtro pasabajos con frecuencia de corte de 49.5Hz y un pasa altos de 0.8Hz. Esta combinación permitió eliminar totalmente los ruidos de linea (arriba de 49.5Hz) y la ondulación de baja frecuencia (se observa como una ondulacion en el dibujo total de la señal) relacionada al movimiento del paciente (variación del potencial de hemipila sobre los electrodos).  

![image](https://github.com/user-attachments/assets/f026bac2-9567-42b3-a0e4-02a989daee6e)  

En la siguiente imagen pueden verse el espectro de dichas señales y apreciar el corte espectral que realizaron los filtros.  

![image](https://github.com/user-attachments/assets/af513284-c84c-488d-8c0d-c80dfddd1d0b)  


