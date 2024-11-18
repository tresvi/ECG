long valor=0;

void setup() {
    Serial.begin(115200);
    pinMode(A1, OUTPUT);
}

void loop() {
  digitalWrite(A1, HIGH);
  valor = analogRead(A0);
  Serial.println(valor);    //Imprimimos por el monitor serie
  digitalWrite(A1, LOW);

  //Se envia una muestra cada 2 milisegundos, pero a ese tiempo se le resta lo que se demora la transmision por puerto serie mas la conversion AD. 
  //Es importante compensarlo, porque dicha demora es de un tamaño apreciable con respecto a 2 mS.
  //La duracion a compensar, se puede medir en el tiempo en alto del puslso de A1 (medir con osciloscopio)
  delayMicroseconds(2000 - 302); 
}
