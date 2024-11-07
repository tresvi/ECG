# ECG Viewer

ECG Viewer es un software de manipulación, visualizacion y filtrado de señales inicialmente pensado para señales electrocardiográficas, pero posteriormente adaptado a para aceptar todo tipo de señales.

# Funcionalidades
## Captura
La captura se realizará desde el puerto serie. Los datos que se capturarán del puerto deberán ser enviados como numeros enteros con un salto de linea despues del mismo (en arduino con Serial.println(valorEntero)) el valor no necesita tener ningun formato especial.
### Configuración del puerto
