# ECG Viewer

ECG Viewer es un software de manipulación, visualizacion y filtrado de señales inicialmente pensado para señales electrocardiográficas, pero posteriormente adaptado a para aceptar todo tipo de señales.

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


## Herramientas Zoom horizontal y Regla
Son las herramientas de mayor utilidad a la hora de analizar la gráfica. 

### Zoom horizontal
El sistema cuenta unicamente con zoom horizontal y se encuentra habilitado por default. Para realizar zoom sobre una señal, alcanza sigtuarse sobre el lugar donde se quiere empezar a hacer zoom, presionar el boton izquierdo del mouse y sin soltar, desplazar hasta el final de la seccion a hacer zoom y soltar. Para deshacer el zoom, puede presionar el botón "Reset Zoom".  
![image](https://github.com/user-attachments/assets/bf3bea98-9ce1-4428-b23b-9896dc4e26d2)

### Regla
![image](https://github.com/user-attachments/assets/5ef58ba3-0131-4918-b11e-10278c740235)  
Para activar la regla, deberá presionar el boton "Regla" en la barra de herramientas. El botón quedará presionado y mientras esté presionado, **la funcionalidad de Zoom permanecerá desactivada** para dejar paso a la de la regla.  
De manera similar al zoom, podrá seleccionar un area sobre el gráfico, en ella se visualizará un recuadro en donde se detallará con presición los valores del segmento de tiempo (horizontal) y de amplitud (vertical) encuadrada. Esta herramienta permitirá medir con mucha mayor precisión y rapidez estas variables que si se tratara de usar la escala del gráfico.
![image](https://github.com/user-attachments/assets/0bcbce39-1190-45cf-b2bc-47c223f85105)  

### Cursor
Con la función de regla, también se activa la función de Cursor. Si en lugar de seleccionar un area con el mouse, simplemente se hace clic en un punto de la gráfica, dicho punto de marcará con una interseccion de líneas y el valor exacto de dicho punto (tiempo y amplitud) se mostrará en la barra de herramientas. 
![image](https://github.com/user-attachments/assets/8076676e-cf4a-4fda-906f-574356e582d0)

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
![image](https://github.com/user-attachments/assets/5ef58ba3-0131-4918-b11e-10278c740235)  
Permite configurar si la escala en Y se configurará de manera automática, o bien, que estcala se desea utilizar.  
![image](https://github.com/user-attachments/assets/bbddad3f-95af-430a-9fc0-cb6c06f2693b)



