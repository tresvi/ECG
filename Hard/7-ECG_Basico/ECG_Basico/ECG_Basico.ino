long valor=0;

void setup() {
    Serial.begin(115200);
    pinMode(A1, OUTPUT);
}

void loop() {
 valor = analogRead(A0);

  digitalWrite(A1, HIGH);
  Serial.println(valor);    //Imprimimos por el monitor serie
  digitalWrite(A1, LOW);
  
  delayMicroseconds(1000 - 135); //Calculado 173, medido: 158
}
