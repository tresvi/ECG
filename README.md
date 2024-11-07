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
![image](https://github.com/user-attachments/assets/2f69ce08-8a8c-489b-9578-659d15728e9a)  

### Regla
Para activar la regla, deberá presionar el boton "Regla" en la barra de herramientas. El botón quedará presionado y mientras esté presionado, **la funcionalidad de Zoom permanecerá desactivada** para dejar paso a la de la regla.  
![image](https://github.com/user-attachments/assets/5b14f28d-1919-4342-845e-cb66457fb9ac)
De manera similar al zoom, podrá seleccionar un area sobre el gráfico, en ella se visualizará un recuadro en donde se detallará con presición el area horizontal y vertical encuadrada. Esta herramienta permitirá medir con mucha mayor precisión y rapidez el tiempo seleccionado y la amplitud.  
![image](https://github.com/user-attachments/assets/0bcbce39-1190-45cf-b2bc-47c223f85105)  






